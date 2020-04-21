using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipos
{
    class Matrices
    {    
        
        // METODO ASIGNAR A UN VECTOR LA SUMA DE LAS COLUMNAS DE UNA MATRIZ
        
                                        //PARAMETRO, RECIBE UNA MATRIZ
        public int[] obtenerSumaColumnas(int[,] mat)
        {
            int[] vecSuma;  //OBTENER EL VECTOR DE LA SUMA DE COLUMNAS
            int nFilas = mat.GetLength(0);   //OBTENER LAS FILAS DE LA MATRIZ
            int nColumnas = mat.GetLength(1); //OBTENER LAS COLUMNAS DE LA MATRIZ

            vecSuma = new int[nColumnas];   //ASIGNANDO LOGITUD AL VECTOR
            int sum;    //ACUMULADOR DE SUMA POR COLUMNA


            // MATRIZ QUE SE RECORRE POR COLUMNAS
            for (int j = 0; j < nColumnas; j++)    //CICLO COLUMNAS
            {
                sum = 0;
                for (int i = 0; i < nFilas; i++)   //CICLO FILAS
                {
                    sum = sum + mat[i, j];

                }
                vecSuma[j] = sum;

            }


            return vecSuma;

        }


    }
}
