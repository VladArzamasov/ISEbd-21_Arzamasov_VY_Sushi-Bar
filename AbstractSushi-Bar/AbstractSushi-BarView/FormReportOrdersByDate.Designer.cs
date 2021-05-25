namespace AbstractSushi_BarView
{
    partial class FormReportOrdersByDate
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractSushi_BarView.ReportViewerOrder.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(2, 56);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1223, 483);
            this.reportViewer.TabIndex = 10;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(535, 6);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(204, 37);
            this.buttonMake.TabIndex = 3;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(1076, 7);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(147, 34);
            this.buttonSaveToPdf.TabIndex = 4;
            this.buttonSaveToPdf.Text = "Сохранить в Pdf";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSaveToPdf);
            this.panel1.Controls.Add(this.buttonMake);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1236, 49);
            this.panel1.TabIndex = 9;
            // 
            // FormReportOrdersByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 538);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportOrdersByDate";
            this.Text = "Информация о заказах";
            this.Load += new System.EventHandler(this.FormReportOrdersByDate_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Button buttonSaveToPdf;
        private System.Windows.Forms.Panel panel1;
    }
}