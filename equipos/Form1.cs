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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //LIMPIANDO LISTAS
            lstOperaciones.Items.Clear();
            lstTablaPosiciones.Items.Clear();

            //DECLARACION DE VARIABLES

            Matrices objMatrices = new Matrices();  //INSTANCIAR CLASE MATRICES

            Vectores objVectores = new Vectores();  //INSTANCIAR CLASE VECTORES

            Random objRandom = new Random();   //INSTANCIAR CLASE PARA GENERAR DATOS ALEATORIOS

            int[,] m; // DECLARANDO MATRIZ PASAR LOS DATOS DEL DGV A LA MATRIZ
            int n = 6; //Convert.ToInt32(txtN.Text);
            m = new int[n, n]; //SEPARAR FILAS Y COLUMNAS DE LA MATRIZ

            int[] v = new int[n];   //VECTOR PARA OBTENER RESULTADO DE LA SUMA DE LAS COLUMNAS

            // ASIGANDO FILAS Y COLUMNAS A CADA DATA GRID VIEW

            dgvNombresEquipos.RowCount = n;    // FILAS
            dgvNombresEquipos.ColumnCount = n;  //COLUMNAS

            dgvPuntosEquipos.RowCount = n;    // FILAS
            dgvPuntosEquipos.ColumnCount = n;  //COLUMNAS

            dgvPuntosTotal.RowCount = 1;    // FILAS
            dgvPuntosTotal.ColumnCount = n;  //COLUMNAS

            dgvNombresVertical.RowCount = n;    // FILAS
            dgvNombresVertical.ColumnCount = 1;  //COLUMNAS

            //AGREGANDO DATOS AL DATA GRID VIEW PARA LOS NOMBRES DE LOS EQUIPOS

            dgvNombresEquipos.Rows[0].Cells[0].Value = "REAL";
            dgvNombresEquipos.Rows[0].Cells[1].Value = "LANÚS";
            dgvNombresEquipos.Rows[0].Cells[2].Value = "COLONIA";
            dgvNombresEquipos.Rows[0].Cells[3].Value = "LITEX";
            dgvNombresEquipos.Rows[0].Cells[4].Value = "BETIS";
            dgvNombresEquipos.Rows[0].Cells[5].Value = "NIC";


            string[] nombres = new string[n];  //CREANDO VECTOR PARA PASAR LOS NOMBRES

            //PASAR DATOS DEL DATA GRIED VIEW AL VECTOR

                for (int j = 0; j < n; j++)
                {
                    nombres[j] = dgvNombresEquipos.Rows[0].Cells[j].Value.ToString();
                }
  


            //AGREGANDO DATOS AL DATA GRIED VIEW VERTICAL PARA LOS NOMBRES DE LOS EQUIPOS
            for (int i = 0; i < n; i++)
            {
                dgvNombresVertical.Rows[i].Cells[0].Value = dgvNombresEquipos.Rows[0].Cells[i].Value;
            }
      
            //DIAGONAL PRINCIPAL
            for (int k = 0; k < n; k++)
            {
                dgvPuntosEquipos.Rows[k].Cells[k].Value = 0;   //AGREGANDO CEROS A LA DIAGONAL PRINCIPAL
                dgvPuntosEquipos.Rows[k].Cells[k].Style.BackColor = Color.Red;    //CAMBIANDO COLOR A LA DIAGONAL PRINCIPAL
            }

            

            //LLENANDO DATOS ALEATORIOS CON LA CLASE RANDOM
            for (int j = 0; j <n; j++) // CICLO COLUMNAS, PARA LLENAR POR COLUMNAS
            {
                for (int i = 0; i <n; i++)
                {

                    if (i > j)  //DATOS POR DEBAJO Y ENCIMA DE LA DIAGONAL PRINCIPAL
                    {
                        dgvPuntosEquipos.Rows[i].Cells[j].Value = objRandom.Next(0,4);  // METODO PARA LLEVAR DATOS AL DGV ENTRE 0 Y 3
                        // dgvPuntosEquipos[j.i].Value = objRandom.Next(0,4);   // METODO PARA LLEVAR DATOS AL DGV

                        // ESPEJO

                        if (Convert.ToInt32(dgvPuntosEquipos.Rows[i].Cells[j].Value) == 0)
                        {
                            dgvPuntosEquipos.Rows[j].Cells[i].Value = 3;


                        }
                        else
                        {
                            if (Convert.ToInt32(dgvPuntosEquipos.Rows[i].Cells[j].Value) == 3)
                            {
                                dgvPuntosEquipos.Rows[j].Cells[i].Value = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(dgvPuntosEquipos.Rows[i].Cells[j].Value) == 1)
                                {
                                    dgvPuntosEquipos.Rows[j].Cells[i].Value = 1;
                                }
                                else
                                {
                                    i = i - 1; // ERROR
                                }
                            }
                        }
                    }
                }
            }

            //PASAR DATOS DEL DATA GRIED VIEW A LA MATRIZ
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] =Convert.ToInt32(dgvPuntosEquipos.Rows[i].Cells[j].Value);
                }
            }

            v = objMatrices.obtenerSumaColumnas(m); // RECIBE LA SUMA DE LAS COLUMNAS


            // MOSTRAR EN EL DATA GRID VIEW EL VECTOR V, QUE CONTIENE LA SUMA DE LAS COLUMNAS(puntos totales)
            for (int j = 0; j < n; j++)
            {
                dgvPuntosTotal.Rows[0].Cells[j].Value = v[j];
            }


            double media = objVectores.promedioVector(v, n);  //RECIBE LA MEDIA DEL VECTOR
            double mediana = objVectores.medianaVector(v, nombres);   //RECIBE LA MEDIANA DEL VECTOR
            double desviacionEstandar = objVectores.obtenerDesviacionEstandar(v,n);   //RECIBE LA DESVIACION ESTANDAR DEL VECTOR
            double moda = objVectores.obtenerModa(v);     //RECIBE LA MODA DEL VECTOR

            //MOSTRANDO OPERACIONES
            lstOperaciones.Visible = true;   // HABILITANDO LISTBOX
            lstOperaciones.Items.Add("La media es: " + media);    // AGREGANDO DATO AL LISTBOX
            lstOperaciones.Items.Add("La mediana es: " + mediana);    // AGREGANDO DATO AL LISTBOX
            lstOperaciones.Items.Add("La moda es: " + moda);    // AGREGANDO DATO AL LISTBOX
            lstOperaciones.Items.Add("La desviación es: " + desviacionEstandar);    // AGREGANDO DATO AL LISTBOX



            //MOSTRANDO TABLA DE POSICIONES EN UN LISTBOX
            lstTablaPosiciones.Visible = true;   // HABILITANDO LISTBOX

            for (int i = 0; i < n; i++)
            {
                lstTablaPosiciones.Items.Add(i+1 +") " + nombres[i] +": "+ v[i]);
            }


            lblCampeon.Text = nombres[0].ToString(); //MOSTRANDO EQUIPO CON MAYOR PUNTOS
        }






















        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
