namespace NatEdit
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DevicesComboBox = new System.Windows.Forms.ComboBox();
            this.DevicesLabel = new System.Windows.Forms.Label();
            this.MappingsListBox = new System.Windows.Forms.ListBox();
            this.MappingsLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceDiscoveryLabel = new System.Windows.Forms.Label();
            this.MappingUpdateLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DevicesComboBox
            // 
            this.DevicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DevicesComboBox.FormattingEnabled = true;
            this.DevicesComboBox.Location = new System.Drawing.Point(12, 52);
            this.DevicesComboBox.Name = "DevicesComboBox";
            this.DevicesComboBox.Size = new System.Drawing.Size(340, 21);
            this.DevicesComboBox.TabIndex = 0;
            this.DevicesComboBox.SelectedIndexChanged += new System.EventHandler(this.DevicesComboBox_SelectedIndexChanged);
            // 
            // DevicesLabel
            // 
            this.DevicesLabel.AutoSize = true;
            this.DevicesLabel.Location = new System.Drawing.Point(12, 36);
            this.DevicesLabel.Name = "DevicesLabel";
            this.DevicesLabel.Size = new System.Drawing.Size(112, 13);
            this.DevicesLabel.TabIndex = 1;
            this.DevicesLabel.Text = "Discovering devices...";
            // 
            // MappingsListBox
            // 
            this.MappingsListBox.FormattingEnabled = true;
            this.MappingsListBox.Location = new System.Drawing.Point(12, 128);
            this.MappingsListBox.Name = "MappingsListBox";
            this.MappingsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.MappingsListBox.Size = new System.Drawing.Size(340, 108);
            this.MappingsListBox.TabIndex = 2;
            // 
            // MappingsLabel
            // 
            this.MappingsLabel.AutoSize = true;
            this.MappingsLabel.Location = new System.Drawing.Point(12, 112);
            this.MappingsLabel.Name = "MappingsLabel";
            this.MappingsLabel.Size = new System.Drawing.Size(111, 13);
            this.MappingsLabel.TabIndex = 4;
            this.MappingsLabel.Text = "No device discovered";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(364, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // DeviceDiscoveryLabel
            // 
            this.DeviceDiscoveryLabel.AutoSize = true;
            this.DeviceDiscoveryLabel.Location = new System.Drawing.Point(12, 76);
            this.DeviceDiscoveryLabel.Name = "DeviceDiscoveryLabel";
            this.DeviceDiscoveryLabel.Size = new System.Drawing.Size(112, 13);
            this.DeviceDiscoveryLabel.TabIndex = 6;
            this.DeviceDiscoveryLabel.Text = "Discovering devices...";
            // 
            // MappingUpdateLabel
            // 
            this.MappingUpdateLabel.AutoSize = true;
            this.MappingUpdateLabel.Location = new System.Drawing.Point(9, 239);
            this.MappingUpdateLabel.Name = "MappingUpdateLabel";
            this.MappingUpdateLabel.Size = new System.Drawing.Size(150, 13);
            this.MappingUpdateLabel.TabIndex = 7;
            this.MappingUpdateLabel.Text = "Waiting for device discovery...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 259);
            this.Controls.Add(this.MappingUpdateLabel);
            this.Controls.Add(this.DeviceDiscoveryLabel);
            this.Controls.Add(this.MappingsLabel);
            this.Controls.Add(this.MappingsListBox);
            this.Controls.Add(this.DevicesLabel);
            this.Controls.Add(this.DevicesComboBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAT Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DevicesComboBox;
        private System.Windows.Forms.Label DevicesLabel;
        private System.Windows.Forms.ListBox MappingsListBox;
        private System.Windows.Forms.Label MappingsLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label DeviceDiscoveryLabel;
        private System.Windows.Forms.Label MappingUpdateLabel;
    }
}

