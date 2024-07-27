using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.Automation.UserControls
{
    public partial class BaseTestPanel : UserControl
    {
        public Dictionary<int, TestPanelItem> dTpi;
        public string TestPanelHeader
        {
            get => lblHeader.Text;
            set => lblHeader.Text = value;
        }

        public Color BorderColor
        {
            get => this.BackColor;
            set => this.BackColor = value;
        }

        public bool EnableTest
        {
            get { return _enableTest; }
            set
            {
                _enableTest = value;
                foreach (TestPanelItem kvp in this.dTpi.Values)
                {
                    if (value)
                    {
                        kvp.TestButtonText = "Test";
                        kvp.TestButton.Enabled = true;
                    }
                    else
                    {
                        kvp.TestButtonText = "Not Found";
                        kvp.TestButton.Enabled = false;
                    }
                }
            }
        }

        private bool _enableTest = false;

        public BaseTestPanel()
        {
            InitializeComponent();
            flpController.Controls.Clear();
            dTpi = new Dictionary<int, TestPanelItem>();
        }

        public TestPanelItem TestPanelItemBuilder(string testName, bool isEnableParameter = true) => new TestPanelItem { TestName = testName, EnableParameter = isEnableParameter };
        public TestPanelItem TestPanelItemBuilder(string testName, string defaultParam) => new TestPanelItem { TestName = testName, ParameterValue = defaultParam };
        public string GetParameterValue(int testPanelIndex)
        {
            TestPanelItem ctrl = dTpi[testPanelIndex];
            if (ctrl != null)
                return ctrl.ParameterValue;
            return "";
        }
        public void ChangeParameterValue(int testPanelIndex, string value)
        {
            TestPanelItem ctrl = dTpi[testPanelIndex];
            if (ctrl != null)
                ctrl.ParameterValue = value;
        }
        public void AddTestPanelItem(TestPanelItem tpi)
        {
            dTpi.Add(flpController.Controls.Count, tpi);
            flpController.Controls.Add(tpi);
        }
    }
}
