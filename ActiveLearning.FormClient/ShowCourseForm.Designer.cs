namespace ActiveLearning.FormClient
{
    partial class ShowCourseForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.courseNameDataGridViewTextBoxColumn,
            this.createDTDataGridViewTextBoxColumn,
            this.deleteDTDataGridViewTextBoxColumn,
            this.sidDataGridViewTextBoxColumn,
            this.updateDTDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.courseBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(42, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(555, 165);
            this.dataGridView1.TabIndex = 0;
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataSource = typeof(ActiveLearning.FormClient.StudentService.Course);
            // 
            // courseNameDataGridViewTextBoxColumn
            // 
            this.courseNameDataGridViewTextBoxColumn.DataPropertyName = "CourseName";
            this.courseNameDataGridViewTextBoxColumn.HeaderText = "CourseName";
            this.courseNameDataGridViewTextBoxColumn.Name = "courseNameDataGridViewTextBoxColumn";
            this.courseNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createDTDataGridViewTextBoxColumn
            // 
            this.createDTDataGridViewTextBoxColumn.DataPropertyName = "CreateDT";
            this.createDTDataGridViewTextBoxColumn.HeaderText = "CreateDT";
            this.createDTDataGridViewTextBoxColumn.Name = "createDTDataGridViewTextBoxColumn";
            this.createDTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deleteDTDataGridViewTextBoxColumn
            // 
            this.deleteDTDataGridViewTextBoxColumn.DataPropertyName = "DeleteDT";
            this.deleteDTDataGridViewTextBoxColumn.HeaderText = "DeleteDT";
            this.deleteDTDataGridViewTextBoxColumn.Name = "deleteDTDataGridViewTextBoxColumn";
            this.deleteDTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sidDataGridViewTextBoxColumn
            // 
            this.sidDataGridViewTextBoxColumn.DataPropertyName = "Sid";
            this.sidDataGridViewTextBoxColumn.HeaderText = "Sid";
            this.sidDataGridViewTextBoxColumn.Name = "sidDataGridViewTextBoxColumn";
            this.sidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updateDTDataGridViewTextBoxColumn
            // 
            this.updateDTDataGridViewTextBoxColumn.DataPropertyName = "UpdateDT";
            this.updateDTDataGridViewTextBoxColumn.HeaderText = "UpdateDT";
            this.updateDTDataGridViewTextBoxColumn.Name = "updateDTDataGridViewTextBoxColumn";
            this.updateDTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ShowCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 392);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShowCourseForm";
            this.Text = "ShowCourseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleteDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource courseBindingSource;
    }
}