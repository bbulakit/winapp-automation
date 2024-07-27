namespace WinApp.Automation.UserControls
{
    partial class BaseTestPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlOrderProcessScreen = new System.Windows.Forms.Panel();
            this.flpController = new System.Windows.Forms.FlowLayoutPanel();
            this.testPanelItem1 = new WinApp.Automation.UserControls.TestPanelItem();
            this.testPanelItem2 = new WinApp.Automation.UserControls.TestPanelItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlOrderProcessScreen.SuspendLayout();
            this.flpController.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOrderProcessScreen
            // 
            this.pnlOrderProcessScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrderProcessScreen.BackColor = System.Drawing.Color.White;
            this.pnlOrderProcessScreen.Controls.Add(this.flpController);
            this.pnlOrderProcessScreen.Controls.Add(this.panel1);
            this.pnlOrderProcessScreen.Location = new System.Drawing.Point(10, 10);
            this.pnlOrderProcessScreen.Margin = new System.Windows.Forms.Padding(10);
            this.pnlOrderProcessScreen.Name = "pnlOrderProcessScreen";
            this.pnlOrderProcessScreen.Size = new System.Drawing.Size(465, 198);
            this.pnlOrderProcessScreen.TabIndex = 0;
            // 
            // flpController
            // 
            this.flpController.AutoSize = true;
            this.flpController.Controls.Add(this.testPanelItem1);
            this.flpController.Controls.Add(this.testPanelItem2);
            this.flpController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpController.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpController.Location = new System.Drawing.Point(0, 50);
            this.flpController.Margin = new System.Windows.Forms.Padding(5);
            this.flpController.Name = "flpController";
            this.flpController.Size = new System.Drawing.Size(465, 148);
            this.flpController.TabIndex = 0;
            this.flpController.WrapContents = false;
            // 
            // testPanelItem1
            // 
            this.testPanelItem1.BackColor = System.Drawing.Color.White;
            this.testPanelItem1.EnableParameter = true;
            this.testPanelItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.testPanelItem1.Location = new System.Drawing.Point(2, 2);
            this.testPanelItem1.Margin = new System.Windows.Forms.Padding(2);
            this.testPanelItem1.Name = "testPanelItem1";
            this.testPanelItem1.ParameterValue = "Test Paremeters";
            this.testPanelItem1.Size = new System.Drawing.Size(461, 56);
            this.testPanelItem1.TabIndex = 0;
            this.testPanelItem1.TestBackColor = System.Drawing.Color.White;
            this.testPanelItem1.TestButtonText = "Test";
            this.testPanelItem1.TestName = "Test\r\nName";
            // 
            // testPanelItem2
            // 
            this.testPanelItem2.BackColor = System.Drawing.Color.White;
            this.testPanelItem2.EnableParameter = true;
            this.testPanelItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.testPanelItem2.Location = new System.Drawing.Point(2, 62);
            this.testPanelItem2.Margin = new System.Windows.Forms.Padding(2);
            this.testPanelItem2.Name = "testPanelItem2";
            this.testPanelItem2.ParameterValue = "Test Paremeters";
            this.testPanelItem2.Size = new System.Drawing.Size(461, 56);
            this.testPanelItem2.TabIndex = 1;
            this.testPanelItem2.TestBackColor = System.Drawing.Color.White;
            this.testPanelItem2.TestButtonText = "Test";
            this.testPanelItem2.TestName = "Test\r\nName";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 50);
            this.panel1.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Azure;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(465, 50);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Test Name";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaseTestPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.pnlOrderProcessScreen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "BaseTestPanel";
            this.Size = new System.Drawing.Size(485, 218);
            this.pnlOrderProcessScreen.ResumeLayout(false);
            this.pnlOrderProcessScreen.PerformLayout();
            this.flpController.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrderProcessScreen;
        private System.Windows.Forms.FlowLayoutPanel flpController;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private TestPanelItem testPanelItem1;
        private TestPanelItem testPanelItem2;
    }
}
