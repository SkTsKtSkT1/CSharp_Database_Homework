namespace RestaurantManagement
{
    partial class EditRestaurantNewD
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxbh = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.comboBoxtype = new System.Windows.Forms.ComboBox();
            this.textBoxyj = new System.Windows.Forms.TextBox();
            this.textBoxzkj = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "餐品编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "餐品名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "餐品类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "原价";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "折扣价";
            // 
            // textBoxbh
            // 
            this.textBoxbh.Location = new System.Drawing.Point(135, 49);
            this.textBoxbh.Name = "textBoxbh";
            this.textBoxbh.Size = new System.Drawing.Size(121, 21);
            this.textBoxbh.TabIndex = 5;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(135, 84);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(121, 21);
            this.textBoxID.TabIndex = 6;
            // 
            // comboBoxtype
            // 
            this.comboBoxtype.FormattingEnabled = true;
            this.comboBoxtype.Items.AddRange(new object[] {
            "饮料",
            "面点",
            "主食",
            "荤菜",
            "素菜"});
            this.comboBoxtype.Location = new System.Drawing.Point(135, 119);
            this.comboBoxtype.Name = "comboBoxtype";
            this.comboBoxtype.Size = new System.Drawing.Size(121, 20);
            this.comboBoxtype.TabIndex = 7;
            // 
            // textBoxyj
            // 
            this.textBoxyj.Location = new System.Drawing.Point(135, 153);
            this.textBoxyj.Name = "textBoxyj";
            this.textBoxyj.Size = new System.Drawing.Size(121, 21);
            this.textBoxyj.TabIndex = 8;
            // 
            // textBoxzkj
            // 
            this.textBoxzkj.Location = new System.Drawing.Point(135, 188);
            this.textBoxzkj.Name = "textBoxzkj";
            this.textBoxzkj.Size = new System.Drawing.Size(121, 21);
            this.textBoxzkj.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定新建";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // EditRestaurantNewD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 316);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxzkj);
            this.Controls.Add(this.textBoxyj);
            this.Controls.Add(this.comboBoxtype);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxbh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditRestaurantNewD";
            this.Text = "新增餐品";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxbh;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.ComboBox comboBoxtype;
        private System.Windows.Forms.TextBox textBoxyj;
        private System.Windows.Forms.TextBox textBoxzkj;
        private System.Windows.Forms.Button button1;
    }
}