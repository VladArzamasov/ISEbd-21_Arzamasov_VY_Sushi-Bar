using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using AbstractSushi_BarBusinessLogic.BusinessLogics;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarBusinessLogic.BindingModels;
using System.Windows.Forms;

namespace AbstractSushi_BarView
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;
        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }
        private void FormMails_Load(object sender, EventArgs e)
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
