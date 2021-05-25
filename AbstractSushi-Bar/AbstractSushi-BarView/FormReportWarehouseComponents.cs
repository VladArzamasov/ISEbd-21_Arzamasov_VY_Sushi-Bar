﻿using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;
namespace AbstractSushi_BarView
{
    public partial class FormReportWarehouseComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportWarehouseComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormReportWarehouseComponents_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetWarehouseComponent();
                if (dict != null)
                {
                    dataGridViewReportWarehouseComponents.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridViewReportWarehouseComponents.Rows.Add(new object[]
                        {
                            elem.WarehouseName, "", ""
                        });
                        foreach (var listElem in elem.Components)
                        {
                            dataGridViewReportWarehouseComponents.Rows.Add(new object[]
                            {
                                "", listElem.Item1, listElem.Item2
                            });
                        }
                        dataGridViewReportWarehouseComponents.Rows.Add(new object[]
                        {
                            "Итого", "", elem.TotalCount
                        });
                        dataGridViewReportWarehouseComponents.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveWarehouseComponentsToExcel(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
