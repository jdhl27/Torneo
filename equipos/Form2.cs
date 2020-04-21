using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace equipos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {       

            dataGridView1.RowCount = 5;
            dataGridView1.ColumnCount = 3;

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[,] tabla = new string[5, 3];
            int n = Convert.ToInt16(textBox1.Text);

            Matrices objMatrices = new Matrices();


            //MANDAR DATOS DEL DATA GRID VIEW A LA TABLA
            for (int i = 0; i <5; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    tabla[i, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                }
            }

            //ORDENAR LA TABLA
            tabla= objMatrices.ordenarTabla(tabla,n);


            // MANDAR TABLA AL DATA GRID VIEW
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                  
                        dataGridView1.Rows[i].Cells[j].Value = tabla[i, j];
                }
            }

        }
    }
}
