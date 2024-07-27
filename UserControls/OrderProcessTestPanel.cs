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

namespace WinApp.Automation.UserControls
{
    public enum OrderPanelTestIndex : int
    {
        FIND_FORM = 0,
        INPUT_SEARCH,
        GET_CART_NAMES,
        PROCESS_BUTTON,
        FULL_TEST,
    }

    public partial class OrderProcessTestPanel : BaseTestPanel
    {
        public AutomationController Controller { get; set; }
        public OrderProcessTestPanel()
        {
            InitializeComponent();
            TestPanelHeader = "Order Processing";
            CreateFindOrderForm();
            CreateInputSearch();
            CreateGetCartNames();
            CreateProcessButton();
            CreateFullTest();
        }

        #region 0-Find Order Form
        private void CreateFindOrderForm()
        {
            var tpi = base.TestPanelItemBuilder("Find\nForm", isEnableParameter: false);
            tpi.OnTestClick += FindForm_Click;
            this.AddTestPanelItem(tpi);
        }

        private void FindForm_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            FindOrderForm();
        }

        private void FindOrderForm()
        {
            if (this.Controller == null)
                return;

            //this.Controller.RefreshElements();

            if (this.Controller.OrderForm.IsOrderFormFocused)
                this.BorderColor = Color.Green;
            else
                this.BorderColor = Color.Red;
        }
        #endregion

        #region 1-Input Search
        private void CreateInputSearch()
        {
            var tpi = base.TestPanelItemBuilder("Input\nSearch");
            tpi.OnTestClick += InputSearch_Click;
            this.AddTestPanelItem(tpi);
        }

        private void InputSearch_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            int tpiIndex = (int)OrderPanelTestIndex.INPUT_SEARCH;
            var param = this.GetParameterValue(tpiIndex);
            InputSearch(param);
        }

        private void InputSearch(string cartName)
        {
            if (this.Controller == null || !this.Controller.OrderForm.IsOrderFormFocused)
                return;
            
            this.Controller.OrderForm.InputSearchTextBox(cartName);
            this.Controller.OrderForm.PressEnter();
        }
        #endregion

        #region 2-Get Cart Names
        private void CreateGetCartNames()
        {
            var tpi = base.TestPanelItemBuilder("Get\nCart Names");
            tpi.OnTestClick += GetCartNames_Click;
            this.AddTestPanelItem(tpi);
        }

        private void GetCartNames_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            GetCartNames();
        }

        private IReadOnlyCollection<string> GetCartNames()
        {
            int tpiIndex = (int)OrderPanelTestIndex.GET_CART_NAMES;
            if (this.Controller == null || !this.Controller.OrderForm.IsOrderFormFocused)
            {
                this.ChangeParameterValue(tpiIndex, "");
                return null;
            }

            this.Controller.OrderForm.RefreshScreen();
            FindOrderForm();

            var names = this.Controller.OrderForm.GetCartNames();
            StringBuilder sb = new StringBuilder();
            foreach (var name in names)
                sb.AppendLine(name);

            this.ChangeParameterValue(tpiIndex, sb.ToString());
            return names;
        }
        #endregion

        #region 3-Process Button
        private void CreateProcessButton()
        {
            var tpi = base.TestPanelItemBuilder("Click\nProcess", isEnableParameter: false);
            tpi.OnTestClick += ProcessButton_Click;
            this.AddTestPanelItem(tpi);
        }

        private void ProcessButton_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            if (this.Controller == null || !this.Controller.OrderForm.IsOrderFormFocused)
                return;

            this.Controller.OrderForm.PressProcessButton();
        }
        #endregion

        #region Full Test
        private void CreateFullTest()
        {
            var tpi = base.TestPanelItemBuilder("Full\nTest", isEnableParameter: false);
            tpi.OnTestClick += FullTest_Click;
            this.AddTestPanelItem(tpi);
        }

        private void FullTest_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            FullTest();
        }

        private void FullTest()
        {
            if (this.Controller == null)
                return;

            //this.Controller.RefreshElements();

            this.Controller.OrderForm.RefreshScreen();

            FindOrderForm();
            if (!this.Controller.OrderForm.IsOrderFormOpened)
                return;

            var cartList = GetCartNames();
            if(cartList != null)
            {
                foreach (var cart in cartList)
                {
                    InputSearch(cart);
                }
            }            

            Thread.Sleep(1000);
            this.Controller.OrderForm.PressProcessButton();
        }
        #endregion
    }
}
