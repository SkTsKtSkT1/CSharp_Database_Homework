namespace RestaurantManagement
{
    partial class MainFormManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销售额查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改个人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改消费记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.更改ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户信息ToolStripMenuItem,
            this.销售额查询ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.查询ToolStripMenuItem.Text = "查询(&S)";
            // 
            // 用户信息ToolStripMenuItem
            // 
            this.用户信息ToolStripMenuItem.Name = "用户信息ToolStripMenuItem";
            this.用户信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.用户信息ToolStripMenuItem.Text = "用户消费信息";
            this.用户信息ToolStripMenuItem.Click += new System.EventHandler(this.用户信息ToolStripMenuItem_Click);
            // 
            // 销售额查询ToolStripMenuItem
            // 
            this.销售额查询ToolStripMenuItem.Name = "销售额查询ToolStripMenuItem";
            this.销售额查询ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.销售额查询ToolStripMenuItem.Text = "销售额查询";
            this.销售额查询ToolStripMenuItem.Click += new System.EventHandler(this.销售额查询ToolStripMenuItem_Click);
            // 
            // 更改ToolStripMenuItem
            // 
            this.更改ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更改个人信息ToolStripMenuItem,
            this.更改消费记录ToolStripMenuItem});
            this.更改ToolStripMenuItem.Name = "更改ToolStripMenuItem";
            this.更改ToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.更改ToolStripMenuItem.Text = "管理(&M)";
            // 
            // 更改个人信息ToolStripMenuItem
            // 
            this.更改个人信息ToolStripMenuItem.Name = "更改个人信息ToolStripMenuItem";
            this.更改个人信息ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.更改个人信息ToolStripMenuItem.Text = "管理注册用户信息";
            this.更改个人信息ToolStripMenuItem.Click += new System.EventHandler(this.更改个人信息ToolStripMenuItem_Click);
            // 
            // 更改消费记录ToolStripMenuItem
            // 
            this.更改消费记录ToolStripMenuItem.Name = "更改消费记录ToolStripMenuItem";
            this.更改消费记录ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.更改消费记录ToolStripMenuItem.Text = "管理餐厅及餐品";
            this.更改消费记录ToolStripMenuItem.Click += new System.EventHandler(this.更改消费记录ToolStripMenuItem_Click);
            // 
            // MainFormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFormManager";
            this.Text = "管理员模式";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改个人信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改消费记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 销售额查询ToolStripMenuItem;
    }
}