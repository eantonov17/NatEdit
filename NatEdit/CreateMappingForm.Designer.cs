namespace NatEdit
{
    partial class CreateMappingForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateMappingForm));
            this.RouterPortTextBox = new System.Windows.Forms.TextBox();
            this.LocalAddrTextBox = new System.Windows.Forms.TextBox();
            this.LocalPortTextBox = new System.Windows.Forms.TextBox();
            this.RouterAddrTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ProtocolComboBox = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 67);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 13);
            label1.TabIndex = 0;
            label1.Text = "Router port:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 93);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 13);
            label2.TabIndex = 2;
            label2.Text = "Local IP address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 119);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 13);
            label3.TabIndex = 4;
            label3.Text = "Local port:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 41);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(95, 13);
            label4.TabIndex = 6;
            label4.Text = "Router IP address:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(13, 145);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 13);
            label5.TabIndex = 8;
            label5.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 14);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(49, 13);
            label6.TabIndex = 13;
            label6.Text = "Protocol:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RouterPortTextBox
            // 
            this.RouterPortTextBox.Location = new System.Drawing.Point(136, 64);
            this.RouterPortTextBox.Name = "RouterPortTextBox";
            this.RouterPortTextBox.Size = new System.Drawing.Size(100, 20);
            this.RouterPortTextBox.TabIndex = 2;
            // 
            // LocalAddrTextBox
            // 
            this.LocalAddrTextBox.Location = new System.Drawing.Point(136, 90);
            this.LocalAddrTextBox.Name = "LocalAddrTextBox";
            this.LocalAddrTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocalAddrTextBox.TabIndex = 3;
            // 
            // LocalPortTextBox
            // 
            this.LocalPortTextBox.Location = new System.Drawing.Point(136, 116);
            this.LocalPortTextBox.Name = "LocalPortTextBox";
            this.LocalPortTextBox.Size = new System.Drawing.Size(100, 20);
            this.LocalPortTextBox.TabIndex = 4;
            // 
            // RouterAddrTextBox
            // 
            this.RouterAddrTextBox.Enabled = false;
            this.RouterAddrTextBox.Location = new System.Drawing.Point(136, 38);
            this.RouterAddrTextBox.Name = "RouterAddrTextBox";
            this.RouterAddrTextBox.Size = new System.Drawing.Size(100, 20);
            this.RouterAddrTextBox.TabIndex = 1;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(136, 142);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DescriptionTextBox.TabIndex = 5;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 176);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(98, 23);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(136, 176);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ProtocolComboBox
            // 
            this.ProtocolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProtocolComboBox.FormattingEnabled = true;
            this.ProtocolComboBox.Items.AddRange(new object[] {
            "Tcp",
            "Udp"});
            this.ProtocolComboBox.Location = new System.Drawing.Point(136, 11);
            this.ProtocolComboBox.MaxDropDownItems = 2;
            this.ProtocolComboBox.Name = "ProtocolComboBox";
            this.ProtocolComboBox.Size = new System.Drawing.Size(100, 21);
            this.ProtocolComboBox.TabIndex = 0;
            // 
            // CreateMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 217);
            this.Controls.Add(label6);
            this.Controls.Add(this.ProtocolComboBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(label5);
            this.Controls.Add(this.RouterAddrTextBox);
            this.Controls.Add(label4);
            this.Controls.Add(this.LocalPortTextBox);
            this.Controls.Add(label3);
            this.Controls.Add(this.LocalAddrTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.RouterPortTextBox);
            this.Controls.Add(label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateMappingForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Mapping";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox RouterPortTextBox;
        private System.Windows.Forms.TextBox LocalAddrTextBox;
        private System.Windows.Forms.TextBox LocalPortTextBox;
        private System.Windows.Forms.TextBox RouterAddrTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox ProtocolComboBox;
    }
}