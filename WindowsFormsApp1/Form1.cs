using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView2.RowCount = 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                if (radioButton1.Checked)
                {

                    dataGridView1.RowCount = (int)numericUpDown2.Value;
                    dataGridView1.ColumnCount = (int)numericUpDown1.Value;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1.Columns[i].HeaderText = i.ToString();
                    }
                }
                else
                {
                    dataGridView1.RowCount = (int)numericUpDown2.Value;
                    dataGridView1.ColumnCount = (int)numericUpDown1.Value;
                    Random rand = new Random();
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            dataGridView1.Rows[j].Cells[i].Value = rand.Next(-100, 100);
                            dataGridView1.Columns[i].HeaderText = i.ToString();
                        }
                    }

                }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {

                dataGridView2.RowCount = (int)numericUpDown3.Value;
                dataGridView2.ColumnCount = (int)numericUpDown4.Value;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView2.Columns[i].HeaderText = i.ToString();
                }
            }
            else
            {
                dataGridView2.RowCount = (int)numericUpDown3.Value;
                dataGridView2.ColumnCount = (int)numericUpDown4.Value;
                Random rand = new Random();
                for (int j = 0; j < dataGridView2.RowCount; j++)
                {
                    for (int i = 0; i < dataGridView2.ColumnCount; i++)
                    {
                        dataGridView2.Rows[j].Cells[i].Value = rand.Next(-100, 100);
                        dataGridView2.Columns[i].HeaderText = i.ToString();
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myArray1 = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    myArray1[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }

            var myArray2 = new int[dataGridView2.RowCount, dataGridView2.ColumnCount];
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    myArray2[i, j] = Convert.ToInt32(dataGridView2.Rows[i].Cells[j].Value.ToString());
                }
            }

            if (dataGridView1.RowCount != dataGridView2.ColumnCount)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var myArray3 = new int[dataGridView1.RowCount, dataGridView2.ColumnCount];

            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                for (var j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    myArray3[i, j] = 0;
                    for (var k = 0; k < dataGridView1.ColumnCount; k++)
                    {
                        myArray3[i, j] += myArray1[i, k] * myArray2[k, j];
                    }
                }
            }


            //указываем контроллу в который пишем количество строк и столбцов
                dataGridView3.RowCount = myArray1.GetLength(0);
                dataGridView3.ColumnCount = myArray2.GetLength(1);
                for (int i = 0; i < myArray1.GetLength(0); i++)
                {
                    for (int j = 0; j < myArray1.GetLength(1); j++)
                    {
                    //пишем значения из массива в ячейки контролла
                    dataGridView3.Rows[i].Cells[j].Value = myArray3[i, j];
                    }
                }

        }
    }
}
