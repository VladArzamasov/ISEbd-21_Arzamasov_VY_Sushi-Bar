namespace AbstractSushi_BarView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuSushiBar = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImplementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentSushiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.CreateBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSushiBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuSushiBar
            // 
            this.menuSushiBar.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuSushiBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuSushiBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.WorkStartToolStripMenuItem,
            this.MailsToolStripMenuItem,
            this.CreateBackupToolStripMenuItem});
            this.menuSushiBar.Location = new System.Drawing.Point(0, 0);
            this.menuSushiBar.Name = "menuSushiBar";
            this.menuSushiBar.Size = new System.Drawing.Size(1264, 36);
            this.menuSushiBar.TabIndex = 0;
            this.menuSushiBar.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.ClientsToolStripMenuItem,
            this.ImplementersToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(139, 32);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(220, 34);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(220, 34);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // ClientsToolStripMenuItem
            // 
            this.ClientsToolStripMenuItem.Name = "ClientsToolStripMenuItem";
            this.ClientsToolStripMenuItem.Size = new System.Drawing.Size(220, 34);
            this.ClientsToolStripMenuItem.Text = "Клиенты";
            this.ClientsToolStripMenuItem.Click += new System.EventHandler(this.ClientsToolStripMenuItem_Click);
            // 
            // ImplementersToolStripMenuItem
            // 
            this.ImplementersToolStripMenuItem.Name = "ImplementersToolStripMenuItem";
            this.ImplementersToolStripMenuItem.Size = new System.Drawing.Size(220, 34);
            this.ImplementersToolStripMenuItem.Text = "Исполнители";
            this.ImplementersToolStripMenuItem.Click += new System.EventHandler(this.ImplementersToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComponentsToolStripMenuItem,
            this.ComponentSushiToolStripMenuItem,
            this.OrdersToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(88, 32);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // ComponentsToolStripMenuItem
            // 
            this.ComponentsToolStripMenuItem.Name = "ComponentsToolStripMenuItem";
            this.ComponentsToolStripMenuItem.Size = new System.Drawing.Size(325, 34);
            this.ComponentsToolStripMenuItem.Text = "Список изделий";
            this.ComponentsToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // ComponentSushiToolStripMenuItem
            // 
            this.ComponentSushiToolStripMenuItem.Name = "ComponentSushiToolStripMenuItem";
            this.ComponentSushiToolStripMenuItem.Size = new System.Drawing.Size(325, 34);
            this.ComponentSushiToolStripMenuItem.Text = "Изделия по компонентам";
            this.ComponentSushiToolStripMenuItem.Click += new System.EventHandler(this.ComponentSushiToolStripMenuItem_Click);
            // 
            // OrdersToolStripMenuItem
            // 
            this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            this.OrdersToolStripMenuItem.Size = new System.Drawing.Size(325, 34);
            this.OrdersToolStripMenuItem.Text = "Список заказов";
            this.OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // WorkStartToolStripMenuItem
            // 
            this.WorkStartToolStripMenuItem.Name = "WorkStartToolStripMenuItem";
            this.WorkStartToolStripMenuItem.Size = new System.Drawing.Size(136, 32);
            this.WorkStartToolStripMenuItem.Text = "Запуск работ";
            this.WorkStartToolStripMenuItem.Click += new System.EventHandler(this.WorkStartToolStripMenuItem_Click);
            // 
            // MailsToolStripMenuItem
            // 
            this.MailsToolStripMenuItem.Name = "MailsToolStripMenuItem";
            this.MailsToolStripMenuItem.Size = new System.Drawing.Size(90, 32);
            this.MailsToolStripMenuItem.Text = "Письма";
            this.MailsToolStripMenuItem.Click += new System.EventHandler(this.MailsToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 36);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(966, 350);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(1007, 64);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(204, 30);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(1007, 212);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(204, 30);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(1007, 266);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(204, 30);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // CreateBackupToolStripMenuItem
            // 
            this.CreateBackupToolStripMenuItem.Name = "CreateBackupToolStripMenuItem";
            this.CreateBackupToolStripMenuItem.Size = new System.Drawing.Size(144, 32);
            this.CreateBackupToolStripMenuItem.Text = "Создать бэкап";
            this.CreateBackupToolStripMenuItem.Click += new System.EventHandler(this.CreateBackupToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 386);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuSushiBar);
            this.MainMenuStrip = this.menuSushiBar;
            this.Name = "FormMain";
            this.Text = "Суши-бар";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuSushiBar.ResumeLayout(false);
            this.menuSushiBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuSushiBar;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentSushiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImplementersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateBackupToolStripMenuItem;
    }
}

