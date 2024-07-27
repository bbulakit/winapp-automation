using WinApp.Automation.Timers;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WinApp.Automation.Controllers
{
    public enum ProcessScreen
    {
        NONE = 0,
        ORDER_PROCESSING,
        TASK_PROCESSOR
    }

    public class AutomationController
    {
        private CommonTimer _tabFocusMonitorTimer;
        private static ElementLocatorController _locatorController;
        public OrderProcessController OrderForm { get; private set; }
        public TaskProcessController TaskForm { get; private set; }
        public ProcessScreen CurrentProcessScreen { get; private set; }
        public event EventHandler OnScreenChanged;
        public AutomationController()
        {
            _locatorController = new ElementLocatorController("GP.UI.Win");            
            _locatorController.OnUpdateRootElement += _locatorController_OnUpdateRootElement;

            CurrentProcessScreen = ProcessScreen.NONE;

            OrderForm = new OrderProcessController(_locatorController);
            TaskForm = new TaskProcessController(_locatorController);

            _tabFocusMonitorTimer = new CommonTimer(2000);
            _tabFocusMonitorTimer.OnAppMonitorTimerElapsed += _tabFocusMonitorTimer_OnAppMonitorTimerElapsed;
            _tabFocusMonitorTimer.Start();
        }

        private void _tabFocusMonitorTimer_OnAppMonitorTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {            
            try
            {
                _tabFocusMonitorTimer.Stop();

                OrderForm.RefreshElements(OrderProcessElements.ORDER_TAB);
                TaskForm.RefreshElements(TaskProcessElements.TASK_TAB);

                ProcessScreen lastProcessScreen = CurrentProcessScreen;
                UpdateCurrentProcessScreen();

                if (lastProcessScreen != CurrentProcessScreen)
                {
                    OnScreenChanged?.Invoke(this, null);
                    if(CurrentProcessScreen != ProcessScreen.NONE)
                    {
                        RefreshElementsForCurrentScreen(delayBeforeRefresh: 2000);
                    }                    
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            finally
            {
                _tabFocusMonitorTimer.Start();
            }
        }

        private void _locatorController_OnUpdateRootElement(object sender, Models.UpdateRootElementArgs e)
        {
            try
            {
                RefreshElementsForCurrentScreen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
        }

        private void RefreshElementsForCurrentScreen(int delayBeforeRefresh = 0)
        {
            if (delayBeforeRefresh > 0)
                Thread.Sleep(delayBeforeRefresh);
            switch (CurrentProcessScreen)
            {
                case ProcessScreen.ORDER_PROCESSING:
                    OrderForm.RefreshElements();
                    break;

                case ProcessScreen.TASK_PROCESSOR:
                    TaskForm.RefreshElements();
                    break;

                case ProcessScreen.NONE:
                    break;
            }
        }

        private void UpdateCurrentProcessScreen()
        {
            if (OrderForm.IsOrderFormFocused)
            {
                CurrentProcessScreen = ProcessScreen.ORDER_PROCESSING;
            }
            else if (TaskForm.IsTaskFormFocused)
            {
                CurrentProcessScreen = ProcessScreen.TASK_PROCESSOR;
            }
            else
            {
                CurrentProcessScreen = ProcessScreen.NONE;
            }
        }

        #region Common Actions
        public static string ReadTextBox(AutomationElement element)
        {
            try
            {
                if (element == null) throw new InvalidOperationException("Element for reading not found");
                //SetForegroundWindow(_locatorController.HWnd);
                var valuePattern = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                return valuePattern.Current.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            return "";
        }

        public static void InputTextbox(AutomationElement element, string text, int duration = 500)
        {
            try
            {
                if (element == null) throw new InvalidOperationException("Element for input textbox not found");
                SetForegroundWindow(_locatorController.HWnd);
                var valuePattern = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                valuePattern?.SetValue(text);
                System.Threading.Thread.Sleep(duration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
        }

        public static void SelectTabItem(AutomationElement element)
        {
            try
            {
                if (element == null) throw new InvalidOperationException("Element for checking TabItem not found");
                SetForegroundWindow(_locatorController.HWnd);
                var siPattern = element.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                siPattern?.Select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
        }

        public static bool IsTabItemSelected(AutomationElement element)
        {
            try
            {
                if (element == null) throw new InvalidOperationException("Element for checking TabItem not found");
                //SetForegroundWindow(_locatorController.HWnd);
                return (bool)element.GetCurrentPropertyValue(AutomationElement.HasKeyboardFocusProperty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            return false;
        }

        public static void PressButton(AutomationElement element, int duration = 500)
        {
            try
            {
                if (element == null) throw new InvalidOperationException("Element for pressing button not found");
                SetForegroundWindow(_locatorController.HWnd);
                var invokePattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invokePattern?.Invoke();
                System.Threading.Thread.Sleep(duration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
        }

        public static void SendEnterKey(int duration = 500)
        {
            try
            {
                SetForegroundWindow(_locatorController.HWnd);
                System.Threading.Thread.Sleep(duration / 2);
                SendKeys.SendWait("{ENTER}");
                System.Threading.Thread.Sleep(duration / 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
        }

        public static void SendRefreshKey(int duration = 500)
        {
            try
            {
                SetForegroundWindow(_locatorController.HWnd);
                System.Threading.Thread.Sleep(duration / 2);
                SendKeys.SendWait("{F5}");
                System.Threading.Thread.Sleep(duration / 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion        
    }
}