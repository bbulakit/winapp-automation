using System;
using System.Collections.Generic;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Element = WinApp.Automation.Elements.PreDefinedElements;

namespace WinApp.Automation.Controllers
{
    public enum OrderProcessElements
    {
        NONE = 0,
        ORDER_TAB,
        ORDER_FORM,
        SEARCH_TEXTBOX,
        PROCESS_BUTTON,
        TREE_ORDERS,
        ORDER_CARTS,
    }

    public class OrderProcessController
    {
        private ElementLocatorController _locatorController;
        public AutomationElement OrderScreenTab { get; private set; }
        public AutomationElement OrderForm { get; private set; }
        public AutomationElement SearchBox { get; private set; }
        public AutomationElement ProcessButton { get; private set; }
        public AutomationElement TreeOrders { get; private set; }
        public AutomationElement[] OrderCarts { get; private set; }

        public OrderProcessController(ElementLocatorController locatorController)
        {
            _locatorController = locatorController;
            RefreshElements();
        }

        public bool IsOrderFormOpened => OrderForm != null;
        public bool IsOrderFormFocused => AutomationController.IsTabItemSelected(OrderScreenTab);

        public void RefreshElements(OrderProcessElements specific = OrderProcessElements.NONE)
        {
            switch (specific)
            {
                case OrderProcessElements.ORDER_TAB:
                    OrderScreenTab = _locatorController.FindElementByInfo(Element.MainApplication.TabItem_OrderProcessing);
                    break;
                case OrderProcessElements.ORDER_FORM:
                    OrderForm = _locatorController.FindElementByInfo(Element.OrderProcessScreen.Form_OrderProcess);
                    break;
                case OrderProcessElements.SEARCH_TEXTBOX:
                    SearchBox = _locatorController.FindElementByInfo(Element.OrderProcessScreen.TextBox_Search);
                    break;
                case OrderProcessElements.PROCESS_BUTTON:
                    ProcessButton = _locatorController.FindElementByInfo(Element.OrderProcessScreen.Button_Process);
                    break;
                case OrderProcessElements.TREE_ORDERS:
                    TreeOrders = _locatorController.FindElementByInfo(Element.OrderProcessScreen.Tree_OrdersGridTree);
                    break;
                case OrderProcessElements.ORDER_CARTS:
                    if (TreeOrders == null)
                        RefreshElements(OrderProcessElements.TREE_ORDERS);
                    OrderCarts = _locatorController.FindElementsByParentElement(TreeOrders, ControlType.DataItem, AutomationElement.ControlTypeProperty);
                    break;
                default:
                    OrderScreenTab = _locatorController.FindElementByInfo(Element.MainApplication.TabItem_OrderProcessing);
                    OrderForm = _locatorController.FindElementByInfo(Element.OrderProcessScreen.Form_OrderProcess);
                    SearchBox = _locatorController.FindElementByInfo(Element.OrderProcessScreen.TextBox_Search);
                    ProcessButton = _locatorController.FindElementByInfo(Element.OrderProcessScreen.Button_Process);
                    TreeOrders = _locatorController.FindElementByInfo(Element.OrderProcessScreen.Tree_OrdersGridTree);
                    OrderCarts = _locatorController.FindElementsByParentElement(TreeOrders, ControlType.DataItem, AutomationElement.ControlTypeProperty);
                    break;
            }
        }

        public void InputSearchTextBox(string input)
        {
            if (SearchBox == null)
                RefreshElements(OrderProcessElements.SEARCH_TEXTBOX);
            AutomationController.InputTextbox(SearchBox, input);
        }
        public void PressEnter() => AutomationController.SendEnterKey(duration: 200);
        public void RefreshScreen() => AutomationController.SendRefreshKey(duration: 200);
        public void PressProcessButton()
        {
            RefreshElements(OrderProcessElements.PROCESS_BUTTON);
            AutomationController.PressButton(ProcessButton);
        }
        public IReadOnlyCollection<string> GetCartNames()
        {
            try
            {
                if (OrderForm == null)
                    throw new Exception("Order Form not found.");
                RefreshElements(OrderProcessElements.ORDER_CARTS);
                if (OrderCarts == null)
                    throw new Exception("Order Carts not found.");

                List<string> cart = new List<string>();
                foreach (var elm in OrderCarts)
                    cart.Add(elm.Current.Name);
                return cart;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace + ":" + ex.Message);
            }
            return new List<string>();
        }


    }
}