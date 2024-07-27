using WinApp.Automation.Models;
using WinApp.Automation.Timers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WinApp.Automation.Controllers
{
    public class ElementLocatorController : IDisposable
    {
        public delegate void UpdateRootElementHandler(object sender, UpdateRootElementArgs e);
        public event UpdateRootElementHandler OnUpdateRootElement;

        private CommonTimer _rootMonitorTimer;
        private CacheRequest _cacheRequest;
        public AutomationElement RootElement { get; private set; }
        public IntPtr HWnd { get; private set; }
        private readonly string _processName;

        public ElementLocatorController(string processName, double interval = 2000)
        {
            _processName = processName;
            _cacheRequest = new CacheRequest();
            _cacheRequest.Add(AutomationElement.NameProperty);
            _cacheRequest.Add(AutomationElement.ControlTypeProperty);

            _rootMonitorTimer = new CommonTimer(interval);
            _rootMonitorTimer.OnAppMonitorTimerElapsed += AppMonitorTimer_OnTimerElapsed;
            _rootMonitorTimer.Start();
        }

        private void AppMonitorTimer_OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _rootMonitorTimer.Stop();
                UpdateRootElement();
                GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            finally
            {
                _rootMonitorTimer.Start();
            }
        }

        #region Methods
        private void UpdateRootElement()
        {
            try
            {
                var newRootElement = GetRootElementByProcessName(_processName);
                if (newRootElement != null && !newRootElement.Equals(RootElement))
                {
                    RootElement = newRootElement;//.GetUpdatedCache(_cacheRequest);
                    HWnd = (IntPtr)RootElement.Current.NativeWindowHandle;
                    Console.WriteLine("Root element updated: " + RootElement.Current.Name);
                    UpdateRootElementArgs e = new UpdateRootElementArgs(newRootElement, HWnd);
                    OnUpdateRootElement?.Invoke(this, e);                    
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
        }
        private AutomationElement GetRootElementByProcessName(string processName)
        {
            try
            {
                var process = Process.GetProcessesByName(processName).FirstOrDefault();
                if (process == null)
                    throw new InvalidOperationException("Make sure the application is started.");

                return AutomationElement.FromHandle(process.MainWindowHandle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            return null;
        }

        public AutomationElement FindElementByInfo(ElementInfo info, AutomationElement searchRoot = null, TreeScope treeScope = TreeScope.Descendants)
        {
            try
            {
                var conditions = new List<Condition>();
                if (!string.IsNullOrEmpty(info.Name)) conditions.Add(new PropertyCondition(AutomationElement.NameProperty, info.Name));
                if (!string.IsNullOrEmpty(info.AutomationId)) conditions.Add(new PropertyCondition(AutomationElement.AutomationIdProperty, info.AutomationId));
                if (info.ControlType != null) conditions.Add(new PropertyCondition(AutomationElement.ControlTypeProperty, info.ControlType));

                Condition condition;
                if (conditions.Count > 1) condition = new AndCondition(conditions.ToArray());
                else condition = conditions[0];

                if(searchRoot == null)
                {
                    searchRoot = this.RootElement;
                    if (info.Parent != null)
                        searchRoot = FindElementByInfo(info.Parent);
                }

                if (searchRoot != null)
                    return searchRoot.FindFirst(treeScope, condition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            return null;
        }

        public AutomationElement[] FindElementsByParentElement(AutomationElement parent, object value, AutomationProperty property, TreeScope treeScope = TreeScope.Descendants)
        {
            /* Example */
            // FindElementsByParentElement(TreeOrders, ControlType.DataItem, AutomationElement.ControlTypeProperty);
            if (parent == null) return null;
            try
            {
                var condition = new PropertyCondition(property, value);
                var elements = parent.FindAll(treeScope, condition);
                var result = new AutomationElement[elements.Count];
                elements.CopyTo(result, 0);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            return null;
        }

        public AutomationElement FindElementByParentElement(AutomationElement parent, object value, AutomationProperty property, TreeScope treeScope = TreeScope.Descendants)
        {
            /* Example */
            // FindElementsByParentElement(TreeOrders, ControlType.DataItem, AutomationElement.ControlTypeProperty);
            if (parent == null) return null;
            try
            {
                var condition = new PropertyCondition(property, value);
                return parent.FindFirst(treeScope, condition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            return null;
        }

        #endregion       

        public void Dispose()
        {

        }
    }
}
