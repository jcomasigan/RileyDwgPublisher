namespace RileyDwgPublisher
{
    partial class PublisherUI 
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.overrideDateChkBox = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkedTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.monthTextBox = new System.Windows.Forms.TextBox();
            this.dayTextBox = new System.Windows.Forms.TextBox();
            this.directorTextBox = new System.Windows.Forms.TextBox();
            this.designedTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveDwgCheckBox = new System.Windows.Forms.CheckBox();
            this.freezeDwgs = new System.Windows.Forms.CheckBox();
            this.appendRegisterCheckBox = new System.Windows.Forms.CheckBox();
            this.freezeAfterCheckBox = new System.Windows.Forms.CheckBox();
            this.updatePdfCheckBox = new System.Windows.Forms.CheckBox();
            this.okUpdateButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.curCadTxtBox = new System.Windows.Forms.TextBox();
            this.dwgsListBox = new System.Windows.Forms.ListBox();
            this.selectFilesButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.overrideDateChkBox);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.checkedTextBox);
            this.groupBox1.Controls.Add(this.yearTextBox);
            this.groupBox1.Controls.Add(this.monthTextBox);
            this.groupBox1.Controls.Add(this.dayTextBox);
            this.groupBox1.Controls.Add(this.directorTextBox);
            this.groupBox1.Controls.Add(this.designedTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Signature Values";
            // 
            // overrideDateChkBox
            // 
            this.overrideDateChkBox.AutoSize = true;
            this.overrideDateChkBox.Location = new System.Drawing.Point(14, 121);
            this.overrideDateChkBox.Name = "overrideDateChkBox";
            this.overrideDateChkBox.Size = new System.Drawing.Size(95, 17);
            this.overrideDateChkBox.TabIndex = 5;
            this.overrideDateChkBox.Text = "Override Date:";
            this.overrideDateChkBox.UseVisualStyleBackColor = true;
            this.overrideDateChkBox.CheckedChanged += new System.EventHandler(this.overrideDateChkBox_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 86);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // checkedTextBox
            // 
            this.checkedTextBox.Location = new System.Drawing.Point(222, 31);
            this.checkedTextBox.Name = "checkedTextBox";
            this.checkedTextBox.Size = new System.Drawing.Size(69, 20);
            this.checkedTextBox.TabIndex = 2;
            this.checkedTextBox.Text = "MP";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Enabled = false;
            this.yearTextBox.Location = new System.Drawing.Point(246, 119);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(45, 20);
            this.yearTextBox.TabIndex = 6;
            this.yearTextBox.Text = "YY";
            // 
            // monthTextBox
            // 
            this.monthTextBox.Enabled = false;
            this.monthTextBox.Location = new System.Drawing.Point(186, 119);
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.Size = new System.Drawing.Size(45, 20);
            this.monthTextBox.TabIndex = 5;
            this.monthTextBox.Text = "MM";
            // 
            // dayTextBox
            // 
            this.dayTextBox.Enabled = false;
            this.dayTextBox.Location = new System.Drawing.Point(125, 119);
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.Size = new System.Drawing.Size(45, 20);
            this.dayTextBox.TabIndex = 4;
            this.dayTextBox.Tag = "";
            this.dayTextBox.Text = "DD";
            // 
            // directorTextBox
            // 
            this.directorTextBox.Location = new System.Drawing.Point(72, 57);
            this.directorTextBox.Name = "directorTextBox";
            this.directorTextBox.Size = new System.Drawing.Size(219, 20);
            this.directorTextBox.TabIndex = 3;
            this.directorTextBox.Text = "S JAMES";
            // 
            // designedTextBox
            // 
            this.designedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.designedTextBox.Location = new System.Drawing.Point(72, 31);
            this.designedTextBox.Name = "designedTextBox";
            this.designedTextBox.Size = new System.Drawing.Size(69, 20);
            this.designedTextBox.TabIndex = 1;
            this.designedTextBox.Text = "PO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(256, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 9);
            this.label7.TabIndex = 0;
            this.label7.Text = "YEAR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(190, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 9);
            this.label6.TabIndex = 0;
            this.label6.Text = "MONTH";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(133, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 9);
            this.label5.TabIndex = 0;
            this.label5.Text = "DAY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Director:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Checked:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Designed:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveDwgCheckBox);
            this.groupBox2.Controls.Add(this.freezeDwgs);
            this.groupBox2.Controls.Add(this.appendRegisterCheckBox);
            this.groupBox2.Controls.Add(this.freezeAfterCheckBox);
            this.groupBox2.Controls.Add(this.updatePdfCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 383);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 148);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // saveDwgCheckBox
            // 
            this.saveDwgCheckBox.AutoSize = true;
            this.saveDwgCheckBox.Checked = true;
            this.saveDwgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveDwgCheckBox.Enabled = false;
            this.saveDwgCheckBox.Location = new System.Drawing.Point(14, 19);
            this.saveDwgCheckBox.Name = "saveDwgCheckBox";
            this.saveDwgCheckBox.Size = new System.Drawing.Size(86, 17);
            this.saveDwgCheckBox.TabIndex = 9;
            this.saveDwgCheckBox.Text = "Save DWGs";
            this.saveDwgCheckBox.UseVisualStyleBackColor = true;
            // 
            // freezeDwgs
            // 
            this.freezeDwgs.AutoSize = true;
            this.freezeDwgs.Location = new System.Drawing.Point(14, 111);
            this.freezeDwgs.Name = "freezeDwgs";
            this.freezeDwgs.Size = new System.Drawing.Size(155, 17);
            this.freezeDwgs.TabIndex = 8;
            this.freezeDwgs.Text = "Freeze signature block only";
            this.freezeDwgs.UseVisualStyleBackColor = true;
            this.freezeDwgs.CheckedChanged += new System.EventHandler(this.freezeDwgs_CheckedChanged);
            // 
            // appendRegisterCheckBox
            // 
            this.appendRegisterCheckBox.AutoSize = true;
            this.appendRegisterCheckBox.Location = new System.Drawing.Point(14, 65);
            this.appendRegisterCheckBox.Name = "appendRegisterCheckBox";
            this.appendRegisterCheckBox.Size = new System.Drawing.Size(152, 17);
            this.appendRegisterCheckBox.TabIndex = 8;
            this.appendRegisterCheckBox.Text = "Do not add to PDF register";
            this.appendRegisterCheckBox.UseVisualStyleBackColor = true;
            this.appendRegisterCheckBox.CheckedChanged += new System.EventHandler(this.appendRegisterCheckBox_CheckedChanged);
            // 
            // freezeAfterCheckBox
            // 
            this.freezeAfterCheckBox.AutoSize = true;
            this.freezeAfterCheckBox.Location = new System.Drawing.Point(14, 88);
            this.freezeAfterCheckBox.Name = "freezeAfterCheckBox";
            this.freezeAfterCheckBox.Size = new System.Drawing.Size(192, 17);
            this.freezeAfterCheckBox.TabIndex = 8;
            this.freezeAfterCheckBox.Text = "Freeze signature block when done.";
            this.freezeAfterCheckBox.UseVisualStyleBackColor = true;
            this.freezeAfterCheckBox.CheckedChanged += new System.EventHandler(this.freezeAfterCheckBox_CheckedChanged);
            // 
            // updatePdfCheckBox
            // 
            this.updatePdfCheckBox.AutoSize = true;
            this.updatePdfCheckBox.Location = new System.Drawing.Point(14, 42);
            this.updatePdfCheckBox.Name = "updatePdfCheckBox";
            this.updatePdfCheckBox.Size = new System.Drawing.Size(87, 17);
            this.updatePdfCheckBox.TabIndex = 8;
            this.updatePdfCheckBox.Text = "Output PDFs";
            this.updatePdfCheckBox.UseVisualStyleBackColor = true;
            this.updatePdfCheckBox.CheckedChanged += new System.EventHandler(this.updatePdfCheckBox_CheckedChanged);
            // 
            // okUpdateButton
            // 
            this.okUpdateButton.Location = new System.Drawing.Point(107, 537);
            this.okUpdateButton.Name = "okUpdateButton";
            this.okUpdateButton.Size = new System.Drawing.Size(109, 23);
            this.okUpdateButton.TabIndex = 10;
            this.okUpdateButton.Text = "OK";
            this.okUpdateButton.UseVisualStyleBackColor = true;
            this.okUpdateButton.Click += new System.EventHandler(this.okUpdateButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.curCadTxtBox);
            this.groupBox3.Controls.Add(this.dwgsListBox);
            this.groupBox3.Controls.Add(this.selectFilesButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 200);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dwgs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Current CAD Folder:";
            // 
            // curCadTxtBox
            // 
            this.curCadTxtBox.Enabled = false;
            this.curCadTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curCadTxtBox.Location = new System.Drawing.Point(115, 169);
            this.curCadTxtBox.Name = "curCadTxtBox";
            this.curCadTxtBox.Size = new System.Drawing.Size(176, 17);
            this.curCadTxtBox.TabIndex = 8;
            // 
            // dwgsListBox
            // 
            this.dwgsListBox.FormattingEnabled = true;
            this.dwgsListBox.Location = new System.Drawing.Point(14, 19);
            this.dwgsListBox.Name = "dwgsListBox";
            this.dwgsListBox.Size = new System.Drawing.Size(277, 95);
            this.dwgsListBox.TabIndex = 0;
            // 
            // selectFilesButton
            // 
            this.selectFilesButton.Location = new System.Drawing.Point(95, 120);
            this.selectFilesButton.Name = "selectFilesButton";
            this.selectFilesButton.Size = new System.Drawing.Size(103, 23);
            this.selectFilesButton.TabIndex = 7;
            this.selectFilesButton.Text = "Select Files";
            this.selectFilesButton.UseVisualStyleBackColor = true;
            this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
            // 
            // PublisherUI
            // 
            this.AcceptButton = this.okUpdateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.okUpdateButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(363, 650);
            this.MinimumSize = new System.Drawing.Size(363, 558);
            this.Name = "PublisherUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riley DWG Publisher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox checkedTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.TextBox directorTextBox;
        private System.Windows.Forms.TextBox designedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox saveDwgCheckBox;
        private System.Windows.Forms.CheckBox updatePdfCheckBox;
        private System.Windows.Forms.Button okUpdateButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox dwgsListBox;
        private System.Windows.Forms.Button selectFilesButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox overrideDateChkBox;
        private System.Windows.Forms.CheckBox freezeDwgs;
        private System.Windows.Forms.CheckBox appendRegisterCheckBox;
        private System.Windows.Forms.CheckBox freezeAfterCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox curCadTxtBox;
    }
}