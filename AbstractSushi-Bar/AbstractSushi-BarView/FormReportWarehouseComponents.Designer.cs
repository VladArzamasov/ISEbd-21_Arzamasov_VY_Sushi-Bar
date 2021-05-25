namespace AbstractSushi_BarView
{
    partial class FormReportWarehouseComponents
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
            this.dataGridViewReportWarehouseComponents = new System.Windows.Forms.DataGridView();
            this.buttonSaveToExel = new System.Windows.Forms.Button();
            this.WarehouseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportWarehouseComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReportWarehouseComponents
            // 
            this.dataGridViewReportWarehouseComponents.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewReportWarehouseComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReportWarehouseComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WarehouseColumn,
            this.Component,
            this.Col});
            this.dataGridViewReportWarehouseComponents.Location = new System.Drawing.Point(0, 56);
            this.dataGridViewReportWarehouseComponents.Name = "dataGridViewReportWarehouseComponents";
            this.dataGridViewReportWarehouseComponents.RowHeadersWidth = 62;
            this.dataGridViewReportWarehouseComponents.RowTemplate.Height = 28;
            this.dataGridViewReportWarehouseComponents.Size = new System.Drawing.Size(1013, 553);
            this.dataGridViewReportWarehouseComponents.TabIndex = 5;
            // 
            // buttonSaveToExel
            // 
            this.buttonSaveToExel.Location = new System.Drawing.Point(49, 14);
            this.buttonSaveToExel.Name = "buttonSaveToExel";
            this.buttonSaveToExel.Size = new System.Drawing.Size(159, 35);
            this.buttonSaveToExel.TabIndex = 4;
            this.buttonSaveToExel.Text = "Сохранить в Exel";
            this.buttonSaveToExel.UseVisualStyleBackColor = true;
            this.buttonSaveToExel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // WarehouseColumn
            // 
            this.WarehouseColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WarehouseColumn.HeaderText = "Склад";
            this.WarehouseColumn.MinimumWidth = 8;
            this.WarehouseColumn.Name = "WarehouseColumn";
            // 
            // Component
            // 
            this.Component.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Component.HeaderText = "Компонент";
            this.Component.MinimumWidth = 8;
            this.Component.Name = "Component";
            // 
            // Col
            // 
            this.Col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Col.HeaderText = "Количество";
            this.Col.MinimumWidth = 8;
            this.Col.Name = "Col";
            // 
            // FormReportWarehouseComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 611);
            this.Controls.Add(this.dataGridViewReportWarehouseComponents);
            this.Controls.Add(this.buttonSaveToExel);
            this.Name = "FormReportWarehouseComponents";
            this.Text = "Отчет по складам";
            this.Load += new System.EventHandler(this.FormReportWarehouseComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportWarehouseComponents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReportWarehouseComponents;
        private System.Windows.Forms.Button buttonSaveToExel;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col;
    }
}