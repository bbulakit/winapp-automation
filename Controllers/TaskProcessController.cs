using System;
using System.Collections.Generic;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Element = WinApp.Automation.Elements.PreDefinedElements;
using System.Linq;
using System.Threading.Tasks;

namespace WinApp.Automation.Controllers
{
    public enum TaskProcessElements
    {
        NONE = 0,
        TASK_TAB,
        TASK_FORM,
        ORDER_TEXTBOX,
        MATERIAL_TEXTBOX,
        QTY_TEXTBOX,
        SERIAL_TEXTBOX,
        LOCATION_TEXTBOX,
        CONFIRM_BUTTON,
        STATUS_BAR_TEXT,
        STORAGE_UNITS_TAB,
    }

    public class TaskProcessController
    {
        private ElementLocatorController _locatorController;

        public AutomationElement TaskScreenTab { get; private set; }
        public AutomationElement TaskForm { get; private set; }
        public AutomationElement OrderTextBox { get; private set; }
        public AutomationElement MaterialTextBox { get; private set; }
        public AutomationElement QtyTextbox { get; private set; }
        public AutomationElement SerialTextBox { get; private set; }
        public AutomationElement LocationTextBox { get; private set; }
        public AutomationElement ConfirmButton { get; private set; }
        public AutomationElement StatusBar { get; private set; }
        public AutomationElement StatusBarText { get; private set; }
        public AutomationElement GroupOrderQty { get; private set; }
        public AutomationElement GroupMaterialQulification { get; private set; }
        public AutomationElement StorageUnitsTab { get; private set; }
        public Dictionary<string, AutomationElement> StorageUnitsTabItems { get; private set; }

        public TaskProcessController(ElementLocatorController locatorController)
        {
            _locatorController = locatorController;
            RefreshElements();
        }

        public bool IsTaskFormOpened => TaskForm != null;
        public bool IsTaskFormFocused => AutomationController.IsTabItemSelected(TaskScreenTab);
        public string _selectedStorageUnit = string.Empty;
        public string SelectedStorageUnit
        {
            get => _selectedStorageUnit;
            set
            {
                //if (StorageUnitsTabItems == null || StorageUnitsTabItems.Count <= 0)
                //    RefreshElements(TaskProcessElements.STORAGE_UNITS_TAB);
                try
                {
                    AutomationController.SetForegroundWindow(_locatorController.HWnd);
                    RefreshElements(TaskProcessElements.STORAGE_UNITS_TAB);
                    StorageUnitsTabItems.TryGetValue(value, out AutomationElement element);
                    if (element != null)
                    {
                        AutomationController.SelectTabItem(element);
                        _selectedStorageUnit = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace + ":" + ex.Message);
                }
            }
        }

        public IEnumerable<string> GetDisplayingStorageUnits()
        {
            if (StorageUnitsTab == null || StorageUnitsTabItems == null || StorageUnitsTabItems.Count <= 0)
                RefreshElements(TaskProcessElements.STORAGE_UNITS_TAB);

            return StorageUnitsTabItems.Keys;
        }

        public void RefreshElements(TaskProcessElements specific = TaskProcessElements.NONE)
        {
            switch (specific)
            {
                case TaskProcessElements.TASK_TAB:
                    TaskScreenTab = _locatorController.FindElementByInfo(Element.MainApplication.TabItem_TaskProcessor);
                    break;
                case TaskProcessElements.TASK_FORM:
                    TaskForm = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Form_TaskProcessor);
                    break;
                case TaskProcessElements.ORDER_TEXTBOX:
                    OrderTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_MasterOrder);
                    break;
                case TaskProcessElements.MATERIAL_TEXTBOX:
                    MaterialTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_MaterialName);
                    break;
                case TaskProcessElements.QTY_TEXTBOX:
                    var editBoxesInOrderQty = _locatorController.FindElementsByParentElement(GroupOrderQty, ControlType.Edit, AutomationElement.ControlTypeProperty);
                    QtyTextbox = editBoxesInOrderQty.Where(ae =>
                      ae.Current.IsEnabled == true &&
                      int.TryParse(ae.Current.AutomationId, out _)
                    ).FirstOrDefault();
                    break;
                case TaskProcessElements.SERIAL_TEXTBOX:
                    SerialTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_SerialNo);
                    break;
                case TaskProcessElements.LOCATION_TEXTBOX:
                    LocationTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_LocationName);
                    break;
                case TaskProcessElements.CONFIRM_BUTTON:
                    ConfirmButton = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Button_Confirm);
                    break;
                case TaskProcessElements.STATUS_BAR_TEXT:
                    if (StatusBar == null)
                        StatusBar = _locatorController.FindElementByInfo(Element.TaskProcessScreen.StatusBar_StatusBar);
                    StatusBarText = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Text_StatusBarMessage, searchRoot: StatusBar);
                    break;
                case TaskProcessElements.STORAGE_UNITS_TAB:
                    StorageUnitsTab = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Tab_StorageUnit);
                    var tabItems = _locatorController.FindElementsByParentElement(StorageUnitsTab, ControlType.TabItem, AutomationElement.ControlTypeProperty);
                    if (tabItems == null || tabItems.Length == 0)
                        break;
                    StorageUnitsTabItems = new Dictionary<string, AutomationElement>();
                    foreach (var item in tabItems)
                        StorageUnitsTabItems.Add(item.Current.Name, item);
                    break;
                default:
                    GroupOrderQty = _locatorController.FindElementByInfo(Element.TaskProcessScreen.GroupBox_OrderQty);
                    OrderTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_MasterOrder, searchRoot: GroupOrderQty);
                    MaterialTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_MaterialName, searchRoot: GroupOrderQty);

                    TaskForm = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Form_TaskProcessor);
                    ConfirmButton = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Button_Confirm, searchRoot: TaskForm);
                    StatusBar = _locatorController.FindElementByInfo(Element.TaskProcessScreen.StatusBar_StatusBar);
                    StatusBarText = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Text_StatusBarMessage, searchRoot: StatusBar);


                    TaskScreenTab = _locatorController.FindElementByInfo(Element.MainApplication.TabItem_TaskProcessor);
                    SerialTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_SerialNo);
                    LocationTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_LocationName);

                    StorageUnitsTab = _locatorController.FindElementByInfo(Element.TaskProcessScreen.Tab_StorageUnit);
                    break;
            }
        }

        public string GetMasterOrderName()
        {
            //if (OrderTextBox == null)
            RefreshElements(TaskProcessElements.ORDER_TEXTBOX);
            return AutomationController.ReadTextBox(OrderTextBox);
        }
        public string GetMaterialName()
        {
            //if (MaterialTextBox == null)
            RefreshElements(TaskProcessElements.MATERIAL_TEXTBOX);
            return AutomationController.ReadTextBox(MaterialTextBox);
        }

        public string GetLocation()
        {
            //if (LocationTextBox == null)
            RefreshElements(TaskProcessElements.LOCATION_TEXTBOX);
            return AutomationController.ReadTextBox(LocationTextBox);
        }
        public string GetStatusBarText(bool isDateIncluded = false)
        {
            RefreshElements(TaskProcessElements.STATUS_BAR_TEXT);
            string ret = string.Empty;
            if (StatusBarText != null)
                ret = StatusBarText.Current.Name;
            if (!isDateIncluded)
                return ret.Split('\t').Where(t => t.Trim() != "").ToArray().LastOrDefault() ?? "";
            return ret;
        }
        public string GetSerialNo()
        {
            if (SerialTextBox == null)
                RefreshElements(TaskProcessElements.SERIAL_TEXTBOX);
            return AutomationController.ReadTextBox(SerialTextBox);
        }
        public void SetSerialNo(string serialNo)
        {
            SerialTextBox = _locatorController.FindElementByInfo(Element.TaskProcessScreen.TextBox_SerialNo, searchRoot: GroupMaterialQulification);
            AutomationController.InputTextbox(SerialTextBox, serialNo, 100);
        }

        public string GetQty()
        {
            if (QtyTextbox == null)
                RefreshElements(TaskProcessElements.QTY_TEXTBOX);
            return AutomationController.ReadTextBox(QtyTextbox);
        }
        public void SetQty(double qty)
        {
            RefreshElements(TaskProcessElements.QTY_TEXTBOX);
            AutomationController.InputTextbox(QtyTextbox, qty.ToString("0.00"));
        }


        public void PressEnter() => AutomationController.SendEnterKey();
        public void RefreshScreen() => AutomationController.SendRefreshKey();
        public void PressConfirmButton()
        {
            if (ConfirmButton == null)
                RefreshElements(TaskProcessElements.CONFIRM_BUTTON);
            AutomationController.PressButton(ConfirmButton, 100);
        }

    }
}