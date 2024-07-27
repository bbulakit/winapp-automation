namespace WinApp.Automation.UserControls
{
    partial class TestPanelItem
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
            this.tlpTestPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblTestName = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.tbParameter = new System.Windows.Forms.TextBox();
            this.tlpTestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTestPanel
            // 
            this.tlpTestPanel.ColumnCount = 3;
            this.tlpTestPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTestPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tlpTestPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpTestPanel.Controls.Add(this.lblTestName, 0, 0);
            this.tlpTestPanel.Controls.Add(this.btnTest, 2, 0);
            this.tlpTestPanel.Controls.Add(this.tbParameter, 1, 0);
            this.tlpTestPanel.Location = new System.Drawing.Point(3, 3);
            this.tlpTestPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTestPanel.Name = "tlpTestPanel";
            this.tlpTestPanel.RowCount = 1;
            this.tlpTestPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTestPanel.Size = new System.Drawing.Size(455, 50);
            this.tlpTestPanel.TabIndex = 0;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.BackColor = System.Drawing.Color.LightGray;
            this.lblTestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTestName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTestName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTestName.Location = new System.Drawing.Point(3, 0);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(107, 50);
            this.lblTestName.TabIndex = 0;
            this.lblTestName.Text = "Test\r\nName";
            this.lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTest
            // 
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTest.Location = new System.Drawing.Point(375, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(77, 44);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // tbParameter
            // 
            this.tbParameter.BackColor = System.Drawing.Color.White;
            this.tbParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbParameter.Location = new System.Drawing.Point(116, 3);
            this.tbParameter.Multiline = true;
            this.tbParameter.Name = "tbParameter";
            this.tbParameter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbParameter.Size = new System.Drawing.Size(253, 44);
            this.tbParameter.TabIndex = 2;
            this.tbParameter.Text = "Test";
            // 
            // TestPanelItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.tlpTestPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestPanelItem";
            this.Size = new System.Drawing.Size(460, 56);
            this.tlpTestPanel.ResumeLayout(false);
            this.tlpTestPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTestPanel;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox tbParameter;
    }
}
