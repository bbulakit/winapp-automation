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
    public enum TaskPanelTestIndex : int
    {
        FIND_FORM = 0,
        ORDER_NAME,
        MATERIAL_NAME,
        QTY,
        SERIAL_NUMBER,
        LOCATION,
        CONFIRM_BUTTON,
        STATUS_BAR_TEXT,
        GET_STORAGE_UNITS,
        SET_STORAGE_UNITS,
        FULL_TEST,
    }

    public partial class TaskProcessTestPanel : BaseTestPanel
    {
        public AutomationController Controller { get; set; }
        public TaskProcessTestPanel()
        {
            InitializeComponent();
            TestPanelHeader = "Task Processor";
            CreateFindTaskForm();
            CreateGetMasterOrderName();
            CreateGetMaterialName();
            CreateSetQuantity();
            CreateSetSerialNo();
            CreateGetLocationName();
            CreateConfirmButton();
            CreateGetStatusBarText();
            CreateGetStorageUnits();
            CreateSetStorageUnits();
            CreateFullTest();
        }

        #region 0-Find Task Form
        private void CreateFindTaskForm()
        {
            var tpi = base.TestPanelItemBuilder("Find\nForm", isEnableParameter: false);
            tpi.OnTestClick += FindForm_Click;
            this.AddTestPanelItem(tpi);
        }

        private void FindForm_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            FindTaskForm();
        }

        private void FindTaskForm()
        {
            if (this.Controller == null)
                return;

            this.Controller.TaskForm.RefreshElements(TaskProcessElements.TASK_TAB);

            if (this.Controller.TaskForm.IsTaskFormFocused)
                this.BorderColor = Color.Green;
            else
                this.BorderColor = Color.Red;
        }
        #endregion

        #region 1-Get Master Order Name
        private void CreateGetMasterOrderName()
        {
            var tpi = base.TestPanelItemBuilder("Get\nOrder Name");
            tpi.OnTestClick += GetMasterOrderName_Click;
            this.AddTestPanelItem(tpi);
        }

        private void GetMasterOrderName_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            this.ChangeParameterValue((int)TaskPanelTestIndex.ORDER_NAME, GetMasterOrderName());
        }

        private string GetMasterOrderName()
        {
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return "";
            //this.Controller.TaskForm.RefreshElements(TaskProcessElements.ORDER_TEXTBOX);
            return this.Controller.TaskForm.GetMasterOrderName();
        }
        #endregion

        #region 2-Get Material Name
        private void CreateGetMaterialName()
        {
            var tpi = base.TestPanelItemBuilder("Get\nMat. Name");
            tpi.OnTestClick += GetMaterialName_Click;
            this.AddTestPanelItem(tpi);
        }

        private void GetMaterialName_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            this.ChangeParameterValue((int)TaskPanelTestIndex.MATERIAL_NAME, GetMaterialName());
        }

        private string GetMaterialName()
        {
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return "";
            //this.Controller.TaskForm.RefreshElements(TaskProcessElements.MATERIAL_TEXTBOX);
            return this.Controller.TaskForm.GetMaterialName();
        }
        #endregion

        
        #region 3-Set Quantity
        private void CreateSetQuantity()
        {
            var tpi = base.TestPanelItemBuilder("Set\nQuantity");
            tpi.OnTestClick += SetQuantity_Click;
            this.AddTestPanelItem(tpi);
        }

        private void SetQuantity_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            string param = this.GetParameterValue((int)TaskPanelTestIndex.QTY);
            if(double.TryParse(param, out var qty))
            {
                SetQty(qty);
            }            
        }

        private void SetQty(double value)
        {
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return;
            this.Controller.TaskForm.SetQty(value);
        }
        #endregion
        

        #region 4-Set Serial No.
        private void CreateSetSerialNo()
        {
            var tpi = base.TestPanelItemBuilder("Set\nSerial No.");
            tpi.OnTestClick += SetSerialNo_Click;
            this.AddTestPanelItem(tpi);
        }

        private void SetSerialNo_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            string param = this.GetParameterValue((int)TaskPanelTestIndex.SERIAL_NUMBER);
            SetSerialNo(param);
        }

        private void SetSerialNo(string serialNo)
        {
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return;
            //this.Controller.TaskForm.RefreshElements(TaskProcessElements.SERIAL_TEXTBOX);
            this.Controller.TaskForm.SetSerialNo(serialNo);
        }
        #endregion

        #region 5-Get Location Name
        private void CreateGetLocationName()
        {
            var tpi = base.TestPanelItemBuilder("Get\nLocation");
            tpi.OnTestClick += GetLocationName_Click;
            this.AddTestPanelItem(tpi);
        }

        private void GetLocationName_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            this.ChangeParameterValue((int)TaskPanelTestIndex.LOCATION, GetLocationName());
        }

        private string GetLocationName()
        {
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return "";
            //this.Controller.TaskForm.RefreshElements(TaskProcessElements.LOCATION_TEXTBOX);
            return this.Controller.TaskForm.GetLocation();
        }
        #endregion

        #region 6-Confirm Button
        private void CreateConfirmButton()
        {
            var tpi = base.TestPanelItemBuilder("Click\nConfirm", isEnableParameter: false);
            tpi.OnTestClick += ConfirmButton_Click;
            this.AddTestPanelItem(tpi);
        }

        private void ConfirmButton_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return;

            //this.Controller.TaskForm.RefreshElements(TaskProcessElements.CONFIRM_BUTTON);
            this.Controller.TaskForm.PressConfirmButton();
        }
        #endregion

        #region 7-Get Status Bar Text
        private void CreateGetStatusBarText()
        {
            var tpi = base.TestPanelItemBuilder("Get\nStatus Text");
            tpi.OnTestClick += GetStatusBarText_Click;
            this.AddTestPanelItem(tpi);
        }

        private void GetStatusBarText_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            this.ChangeParameterValue((int)TaskPanelTestIndex.STATUS_BAR_TEXT, GetStatusBarText());
        }

        private string GetStatusBarText()
        {
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return "";

            //this.Controller.TaskForm.RefreshElements(TaskProcessElements.STATUS_BAR_TEXT);
            return this.Controller.TaskForm.GetStatusBarText();
        }
        #endregion

        #region 8-Get Storage Units
        private void CreateGetStorageUnits()
        {
            var tpi = base.TestPanelItemBuilder("Get\nStorage Units");
            tpi.OnTestClick += GetStorageUnits_Click;
            this.AddTestPanelItem(tpi);
        }

        private void GetStorageUnits_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            GetStorageUnits();
        }

        private void GetStorageUnits()
        {
            int tpiIndex = (int)TaskPanelTestIndex.GET_STORAGE_UNITS;
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
            {
                this.ChangeParameterValue(tpiIndex, "");
                return;
            }

            var storageUnits = this.Controller.TaskForm.GetDisplayingStorageUnits();
            StringBuilder sb = new StringBuilder();
            foreach (string sUnit in storageUnits)
            {
                sb.AppendLine(sUnit);
            }
            this.ChangeParameterValue(tpiIndex, sb.ToString());
        }
        #endregion

        #region 9-Get Storage Units
        private void CreateSetStorageUnits()
        {
            var tpi = base.TestPanelItemBuilder("Set\nStorage Units");
            tpi.OnTestClick += SetStorageUnits_Click;
            this.AddTestPanelItem(tpi);
        }

        private void SetStorageUnits_Click(object sender, TestPanelItem.TestEventArgs e)
        {
            SetStorageUnit();
        }

        private void SetStorageUnit()
        {
            int tpiIndex = (int)TaskPanelTestIndex.SET_STORAGE_UNITS;
            if (this.Controller == null || !this.Controller.TaskForm.IsTaskFormFocused)
                return;

            string storageUnitName = this.GetParameterValue(tpiIndex);
            this.Controller.TaskForm.SelectedStorageUnit = storageUnitName;
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

            //this.Controller.TaskForm.RefreshElements();

            //FindTaskForm();
            if (!this.Controller.TaskForm.IsTaskFormFocused)
                return;

            while (this.Controller.TaskForm.IsTaskFormFocused)
            {
                if (this.Controller.TaskForm.MaterialTextBox == null &&
                    this.Controller.TaskForm.SerialTextBox == null)
                    break;
                
                this.Controller.TaskForm.PressConfirmButton();                
                var randomValue = Guid.NewGuid().ToString();                
                this.Controller.TaskForm.SetSerialNo(randomValue);                
                this.Controller.TaskForm.PressConfirmButton();
                Thread.Sleep(2000);
                Application.DoEvents();
            }
        }
        #endregion
    }
}
