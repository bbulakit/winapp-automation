using WinApp.Automation.Models;
using System.Windows.Automation;

namespace WinApp.Automation.Elements
{
    #region Pre-defiend UI element names        
    public class PreDefinedElements
    {
        public class MainApplication
        {
            public static ElementInfo Tab_Main = new ElementInfo
            {
                Name = "",
                AutomationId = null,
                ControlType = ControlType.Tab,
                SupportedPatterns = new[] { SelectionPattern.Pattern },
            };

            public static ElementInfo TabItem_OrderProcessing = new ElementInfo
            {
                Name = "Order Processing",
                AutomationId = null,
                ControlType = ControlType.TabItem,
                SupportedPatterns = new[] { SelectionItemPattern.Pattern },
                Parent = Tab_Main,
            };

            public static ElementInfo TabItem_TaskProcessor = new ElementInfo
            {
                Name = "Task processor",
                AutomationId = null,
                ControlType = ControlType.TabItem,
                SupportedPatterns = new[] { SelectionItemPattern.Pattern },
                Parent = Tab_Main,
            };

        }

        public class OrderProcessScreen
        {
            public static ElementInfo Form_OrderProcess = new ElementInfo
            {
                Name = "Order Processing",
                AutomationId = null,
                ControlType = ControlType.Window,
                SupportedPatterns = new[] { WindowPattern.Pattern },
            };

            public static ElementInfo TextBox_Search = new ElementInfo
            {
                Name = "",
                AutomationId = "m_searchText",
                ControlType = ControlType.Edit,
                SupportedPatterns = new[] { ValuePattern.Pattern },
                Parent = Form_OrderProcess,
            };

            public static ElementInfo Button_Process = new ElementInfo
            {
                Name = "Process",
                AutomationId = "m_processOrderBtn",
                ControlType = ControlType.Button,
                SupportedPatterns = new[] { InvokePattern.Pattern },
                Parent = Form_OrderProcess,
            };

            /* Counting Cart - Root */
            public static ElementInfo Pane_OrdersTabPage = new ElementInfo
            {
                Name = "",
                AutomationId = "m_ordersTabPage",
                ControlType = ControlType.Pane,
                Parent = Form_OrderProcess,
            };

            /* Counting Cart - Sub Root */
            public static ElementInfo Grid_OrdersGrid = new ElementInfo
            {
                Name = "",
                AutomationId = "m_ordersGrid",
                ControlType = ControlType.Custom,
                SupportedPatterns = new[] { SelectionPattern.Pattern },
                Parent = Pane_OrdersTabPage
            };

            /* Counting Cart - Group */
            public static ElementInfo Tree_OrdersGridTree = new ElementInfo
            {
                Name = "",
                AutomationId = "ColScrollRegion: 0, RowScrollRegion: 0",
                ControlType = ControlType.Tree,
                SupportedPatterns = new[] { ItemContainerPattern.Pattern },
                Parent = Grid_OrdersGrid,
            };

            /* Counter Cart - Reference Cart Info */
            public static ElementInfo DataItem_OrdersCart = new ElementInfo
            {
                Name = "",
                AutomationId = "",
                ControlType = ControlType.DataItem,
                Parent = Tree_OrdersGridTree,
            };
        }

        public class TaskProcessScreen
        {
            public static ElementInfo Form_TaskProcessor = new ElementInfo
            {
                Name = "Task processor",
                AutomationId = "TasksProcess2Form",
                ControlType = ControlType.Window,
                SupportedPatterns = new[] { WindowPattern.Pattern },
            };

            public static ElementInfo Pane_WindowDockingArea = new ElementInfo
            {
                Name = "",
                AutomationId = "windowDockingArea10",
                ControlType = ControlType.Pane,
                Parent = Form_TaskProcessor,
            };

            public static ElementInfo GroupBox_OrderQty = new ElementInfo
            {
                Name = "",
                AutomationId = "m_materialOrderQuantityGroupBox",
                ControlType = ControlType.Group,
                Parent = Pane_WindowDockingArea,
            };

            public static ElementInfo GroupBox_MaterialQualification = new ElementInfo
            {
                Name = "",
                AutomationId = "materialQualificationGroupBox",
                ControlType = ControlType.Group,
                Parent = Pane_WindowDockingArea,
            };


            public static ElementInfo TextBox_MasterOrder = new ElementInfo
            {
                Name = "",
                AutomationId = "m_masterOrderText",
                ControlType = ControlType.Edit,
                SupportedPatterns = new[] { ValuePattern.Pattern },
                Parent = GroupBox_OrderQty,
            };

            public static ElementInfo TextBox_MaterialName = new ElementInfo
            {
                Name = "",
                AutomationId = "m_materialNameText",
                ControlType = ControlType.Edit,
                SupportedPatterns = new[] { ValuePattern.Pattern },
                Parent = GroupBox_OrderQty,
            };

            public static ElementInfo TextBox_Quantity = new ElementInfo
            {
                Name = "",
                AutomationId = null,
                ControlType = ControlType.Edit,
                SupportedPatterns = new[] { ValuePattern.Pattern },
                Parent = GroupBox_OrderQty,
            };

            public static ElementInfo TextBox_SerialNo = new ElementInfo
            {
                Name = "",
                AutomationId = "m_serialNumberText",
                ControlType = ControlType.Edit,
                SupportedPatterns = new[] { ValuePattern.Pattern },
                //Parent = GroupBox_MaterialQualification,
            };

            public static ElementInfo TextBox_LocationName = new ElementInfo
            {
                Name = "",
                AutomationId = "m_locationNameText",
                ControlType = ControlType.Edit,
                SupportedPatterns = new[] { ValuePattern.Pattern },
                Parent = Form_TaskProcessor,
            };

            public static ElementInfo Button_Confirm = new ElementInfo
            {
                Name = "Confirm",
                AutomationId = "m_confirmBtn",
                ControlType = ControlType.Button,
                SupportedPatterns = new[] { InvokePattern.Pattern },
                Parent = Form_TaskProcessor,
            };

            public static ElementInfo StatusBar_StatusBar = new ElementInfo
            {
                Name = "",
                AutomationId = "m_statusBar",
                ControlType = ControlType.StatusBar,
                SupportedPatterns = new[] { ItemContainerPattern.Pattern },
                Parent = Form_TaskProcessor,
            };

            public static ElementInfo Text_StatusBarMessage = new ElementInfo
            {
                Name = "",
                AutomationId = null,
                ControlType = ControlType.Text,
                SupportedPatterns = new[] { TogglePattern.Pattern },
                Parent = StatusBar_StatusBar,
            };

            /* For searching TabItem (Storage Units) */
            public static ElementInfo Tab_StorageUnit = new ElementInfo
            {
                Name="",
                AutomationId= "m_tabControl",
                ControlType = ControlType.Tab,
                SupportedPatterns= new[] { ScrollPattern.Pattern, SelectionPattern.Pattern },
                Parent = Form_TaskProcessor,
            };
            
        }
        #endregion
    }
}
