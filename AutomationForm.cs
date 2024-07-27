using WinApp.Automation.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.Automation
{
    public partial class AutomationForm : Form
    {
        AutomationController _automationController;
        ProcessScreen LastScreen = ProcessScreen.NONE;
        public AutomationForm()
        {
            InitializeComponent();
            _automationController = new AutomationController();
            this.TopMost = true;
            orderTestPanel.Controller = _automationController;
            taskTestPanel.Controller = _automationController;
            _automationController.OnScreenChanged += WinApp_OnScreenChanged;
        }

        private void WinApp_OnScreenChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => WinApp_OnScreenChanged(sender, e)));
                }
                else
                {
                    var currentScreen = _automationController.CurrentProcessScreen;
                    if (this.LastScreen != currentScreen)
                    {
                        if (currentScreen == ProcessScreen.ORDER_PROCESSING)
                        {
                            ToggleOrderTestPanel(true);
                            ToggleTaskTestPanel(false);
                        }
                        else if (currentScreen == ProcessScreen.TASK_PROCESSOR)
                        {
                            ToggleOrderTestPanel(false);
                            ToggleTaskTestPanel(true);
                        }
                        else
                        {
                            ToggleOrderTestPanel(false);
                            ToggleTaskTestPanel(false);
                        }
                        this.LastScreen = currentScreen;
                    }
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ToggleOrderTestPanel(bool isEnable)
        {
            orderTestPanel.EnableTest = isEnable;
            orderTestPanel.BorderColor = Color.LightGray;
        }

        private void ToggleTaskTestPanel(bool isEnable)
        {
            taskTestPanel.EnableTest = isEnable;
            taskTestPanel.BorderColor = Color.LightGray;
        }
    }
}
