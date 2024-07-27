namespace WinApp.Automation
{
    partial class AutomationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskTestPanel = new WinApp.Automation.UserControls.TaskProcessTestPanel();
            this.orderTestPanel = new WinApp.Automation.UserControls.OrderProcessTestPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskTestPanel
            // 
            this.taskTestPanel.AllowDrop = true;
            this.taskTestPanel.AutoScroll = true;
            this.taskTestPanel.AutoSize = true;
            this.taskTestPanel.BackColor = System.Drawing.Color.Gray;
            this.taskTestPanel.BorderColor = System.Drawing.Color.Gray;
            this.taskTestPanel.Controller = null;
            this.taskTestPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTestPanel.EnableTest = false;
            this.taskTestPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.taskTestPanel.Location = new System.Drawing.Point(3, 3);
            this.taskTestPanel.Name = "taskTestPanel";
            this.taskTestPanel.Size = new System.Drawing.Size(500, 736);
            this.taskTestPanel.TabIndex = 2;
            this.taskTestPanel.TestPanelHeader = "Task Processor";
            // 
            // orderTestPanel
            // 
            this.orderTestPanel.AutoSize = true;
            this.orderTestPanel.BackColor = System.Drawing.Color.Gray;
            this.orderTestPanel.BorderColor = System.Drawing.Color.Gray;
            this.orderTestPanel.Controller = null;
            this.orderTestPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderTestPanel.EnableTest = false;
            this.orderTestPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.orderTestPanel.Location = new System.Drawing.Point(3, 3);
            this.orderTestPanel.Name = "orderTestPanel";
            this.orderTestPanel.Size = new System.Drawing.Size(500, 736);
            this.orderTestPanel.TabIndex = 1;
            this.orderTestPanel.TestPanelHeader = "Order Processing";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 768);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.orderTestPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(506, 742);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Order Proecssing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.taskTestPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(506, 742);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Task Processor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AutomationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 768);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AutomationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AutomationForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.OrderProcessTestPanel orderTestPanel;
        private UserControls.TaskProcessTestPanel taskTestPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}