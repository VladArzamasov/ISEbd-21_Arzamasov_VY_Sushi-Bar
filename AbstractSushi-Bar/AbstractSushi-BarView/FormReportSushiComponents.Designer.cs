namespace AbstractSushi_BarView
{
    partial class FormReportSushiComponents
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Sushi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveToExel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sushi,
            this.Component,
            this.Col});
            this.dataGridView.Location = new System.Drawing.Point(0, 80);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(1013, 553);
            this.dataGridView.TabIndex = 3;
            // 
            // Sushi
            // 
            this.Sushi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sushi.HeaderText = "Суши";
            this.Sushi.MinimumWidth = 8;
            this.Sushi.Name = "Sushi";
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
            // buttonSaveToExel
            // 
            this.buttonSaveToExel.Location = new System.Drawing.Point(15, 38);
            this.buttonSaveToExel.Name = "buttonSaveToExel";
            this.buttonSaveToExel.Size = new System.Drawing.Size(159, 35);
            this.buttonSaveToExel.TabIndex = 2;
            this.buttonSaveToExel.Text = "Сохранить в Exel";
            this.buttonSaveToExel.UseVisualStyleBackColor = true;
            this.buttonSaveToExel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // FormReportSushiComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 633);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonSaveToExel);
            this.Name = "FormReportSushiComponents";
            this.Text = "FormReportSushiComponents";
            this.Load += new System.EventHandler(this.FormReportSushiComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sushi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col;
        private System.Windows.Forms.Button buttonSaveToExel;
    }
}