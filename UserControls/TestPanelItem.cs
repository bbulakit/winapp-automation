using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinApp.Automation.UserControls
{
    public partial class TestPanelItem : UserControl
    {       
        public class TestEventArgs : EventArgs
        {
            public string TestName;
            public string Parameter;
            public TestEventArgs(string testName, string parameter)
            {
                TestName = testName;
                Parameter = parameter;
            }
        }

        public delegate void TestEventHandler(object sender, TestEventArgs e);
        public event TestEventHandler OnTestClick;

        public Button TestButton => btnTest;
        public string TestName 
        {
            get => lblTestName.Text;            
            set => lblTestName.Text = value;
        }

        public string TestButtonText
        {
            get => btnTest.Text;
            set => btnTest.Text = value;
        }

        public string ParameterValue
        {
            get => tbParameter.Text;
            set => tbParameter.Text = value;
        }

        public Color TestBackColor
        {
            get => this.BackColor; 
            set => this.BackColor = value;
        }

        public bool EnableParameter
        {
            get => tbParameter.Enabled;
            set
            {               
                tbParameter.Enabled = value;
                tbParameter.Visible = value;
                
            }

        }               

        public TestPanelItem()
        {
            InitializeComponent();
            btnTest.Click += BtnTest_Click;            
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {                        
            TestEventArgs te = new TestEventArgs(TestName, ParameterValue);
            OnTestClick?.Invoke(this, te);
        }
    }
}
