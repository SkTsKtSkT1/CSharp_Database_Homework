namespace RestaurantManagement
{
    partial class FormForTest
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
            this.canteenManagementDataSet = new RestaurantManagement.CanteenManagementDataSet();
            this.canteensBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.canteensTableAdapter = new RestaurantManagement.CanteenManagementDataSetTableAdapters.canteensTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pelpleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pelpleTableAdapter = new RestaurantManagement.CanteenManagementDataSetTableAdapters.pelpleTableAdapter();
            this.peopleIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peopleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peopleTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.canteenManagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canteensBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelpleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // canteenManagementDataSet
            // 
            this.canteenManagementDataSet.DataSetName = "CanteenManagementDataSet";
            this.canteenManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // canteensBindingSource
            // 
            this.canteensBindingSource.DataMember = "canteens";
            this.canteensBindingSource.DataSource = this.canteenManagementDataSet;
            // 
            // canteensTableAdapter
            // 
            this.canteensTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.peopleIDDataGridViewTextBoxColumn,
            this.peopleNameDataGridViewTextBoxColumn,
            this.peopleTypeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pelpleBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(261, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // pelpleBindingSource
            // 
            this.pelpleBindingSource.DataMember = "pelple";
            this.pelpleBindingSource.DataSource = this.canteenManagementDataSet;
            // 
            // pelpleTableAdapter
            // 
            this.pelpleTableAdapter.ClearBeforeFill = true;
            // 
            // peopleIDDataGridViewTextBoxColumn
            // 
            this.peopleIDDataGridViewTextBoxColumn.DataPropertyName = "PeopleID";
            this.peopleIDDataGridViewTextBoxColumn.HeaderText = "PeopleID";
            this.peopleIDDataGridViewTextBoxColumn.Name = "peopleIDDataGridViewTextBoxColumn";
            // 
            // peopleNameDataGridViewTextBoxColumn
            // 
            this.peopleNameDataGridViewTextBoxColumn.DataPropertyName = "PeopleName";
            this.peopleNameDataGridViewTextBoxColumn.HeaderText = "PeopleName";
            this.peopleNameDataGridViewTextBoxColumn.Name = "peopleNameDataGridViewTextBoxColumn";
            // 
            // peopleTypeDataGridViewTextBoxColumn
            // 
            this.peopleTypeDataGridViewTextBoxColumn.DataPropertyName = "PeopleType";
            this.peopleTypeDataGridViewTextBoxColumn.HeaderText = "PeopleType";
            this.peopleTypeDataGridViewTextBoxColumn.Name = "peopleTypeDataGridViewTextBoxColumn";
            // 
            // FormForTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormForTest";
            this.Text = "FormForTest";
            this.Load += new System.EventHandler(this.FormForTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canteenManagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canteensBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pelpleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CanteenManagementDataSet canteenManagementDataSet;
        private System.Windows.Forms.BindingSource canteensBindingSource;
        private CanteenManagementDataSetTableAdapters.canteensTableAdapter canteensTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource pelpleBindingSource;
        private CanteenManagementDataSetTableAdapters.pelpleTableAdapter pelpleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn peopleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn peopleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn peopleTypeDataGridViewTextBoxColumn;
    }
}