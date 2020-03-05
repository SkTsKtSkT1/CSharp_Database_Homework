namespace RestaurantManagement
{
    partial class Mainform
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.个人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人信息编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询消费记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.姓名 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.个人信息 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人ToolStripMenuItem,
            this.查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(353, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 个人ToolStripMenuItem
            // 
            this.个人ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人信息编辑ToolStripMenuItem});
            this.个人ToolStripMenuItem.Name = "个人ToolStripMenuItem";
            this.个人ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.个人ToolStripMenuItem.Text = "个人(&I)";
            // 
            // 个人信息编辑ToolStripMenuItem
            // 
            this.个人信息编辑ToolStripMenuItem.Name = "个人信息编辑ToolStripMenuItem";
            this.个人信息编辑ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.个人信息编辑ToolStripMenuItem.Text = "个人信息编辑";
            this.个人信息编辑ToolStripMenuItem.Click += new System.EventHandler(this.个人信息编辑ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询消费记录ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.查询ToolStripMenuItem.Text = "查询(&Q)";
            // 
            // 查询消费记录ToolStripMenuItem
            // 
            this.查询消费记录ToolStripMenuItem.Name = "查询消费记录ToolStripMenuItem";
            this.查询消费记录ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.查询消费记录ToolStripMenuItem.Text = "查询消费记录";
            this.查询消费记录ToolStripMenuItem.Click += new System.EventHandler(this.查询消费记录ToolStripMenuItem_Click);
            // 
            // 姓名
            // 
            this.姓名.AutoSize = true;
            this.姓名.Location = new System.Drawing.Point(64, 126);
            this.姓名.Name = "姓名";
            this.姓名.Size = new System.Drawing.Size(29, 12);
            this.姓名.TabIndex = 1;
            this.姓名.Text = "姓名";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(64, 200);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(17, 12);
            this.ID.TabIndex = 2;
            this.ID.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // 个人信息
            // 
            this.个人信息.AutoSize = true;
            this.个人信息.Font = new System.Drawing.Font("宋体", 25F);
            this.个人信息.ForeColor = System.Drawing.Color.Crimson;
            this.个人信息.Location = new System.Drawing.Point(35, 57);
            this.个人信息.Name = "个人信息";
            this.个人信息.Size = new System.Drawing.Size(151, 34);
            this.个人信息.TabIndex = 5;
            this.个人信息.Text = "个人信息";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 371);
            this.Controls.Add(this.个人信息);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.姓名);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.Text = "用户模式";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人信息编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询消费记录ToolStripMenuItem;
        private System.Windows.Forms.Label 姓名;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label 个人信息;
        private System.Windows.Forms.Timer timer1;
    }
}