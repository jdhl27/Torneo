using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipos
{
    class Vectores
    {
        // METODO OBTENER PROMEDIO DE UN VECTOR
        public double promedioVector(int[] vec, int n)
        {
            double media = 0;

            int suma = 0;

            for (int i = 0; i < n; i++)
            {
                suma = suma + vec[i];
            }

            media = Convert.ToDouble(suma) / n;

            return media;
        }


        //METODO ORDENAR VECTOR DESCENDIENTEMENTE POR METODO DE LA BURBURJA
        public int[] ordenarVector(int[] vec, string[]vecNombres)
        {

            int aux;
            string auxNombre;
            int n = vec.Length;

            for (int i = 0; i < n - 1; i++)
            {

                for (int j = i + 1; j < n; j++)
                {

                    if (vec[j] > vec[i])
                    {
                        aux = vec[i];                          //CAMBIAR ORDEN DEL VECTOR
                        vec[i] = vec[j];
                        vec[j] = aux;

                        /*SE CAMBIA EL ORDEN DE LOS NOMBRES CON RESPECTO AL VECTOR DE LOS PUNTAJES, 
                        YA QUE SON VECTORES PARALELOS*/
                        auxNombre = vecNombres[i];             //CAMBIAR ORDEN DE LOS NOMBRES
                        vecNombres[i] = vecNombres[j];
                        vecNombres[j] = auxNombre;
                    }

                }

            }

            return vec;

        }



        // METODO OBTENER LA MEDIANA DE UN VECTOR

        public double medianaVector(int[] vec, string[] vecNombres)
        {
            double mediana = 0;
            int n = vec.Length;
            vec = ordenarVector(vec,vecNombres);

            if (n % 2 == 0)
            {

                mediana = Convert.ToDouble(vec[n / 2 - 1] + vec[n / 2]) / 2;
                                                    //2          //3
            }
            else
            {
                mediana = vec[(n - 1) / 2];

            }

            return mediana;
        }


        // METODO OBTENER LA MODA DE UN VECTOR

        public double obtenerModa(int[] vec)
        {

            int numero = 0, valor = 0, repeticiones = 0;
            for (int i = 0; i <vec.Length ; i++)
            {
                numero = vec[i];
                if (repeticiones < contadorVeces(vec,numero))
                {
                    repeticiones = contadorVeces(vec, numero);
                    valor = vec[i];           
                }
                
            }

            return valor;
        }

  

        public int contadorVeces(int[] v, int numero)
        {
            int cantidad = 0;

            for (int i = 0; i <v.Length; i++)
            {
                if (numero== v[i])
                {
                    cantidad++;
                }
            }

            return cantidad;
        }



        // METODO OBTENER LA DESVIACION ESTANDAR DE UN VECTOR

        public double obtenerDesviacionEstandar(int[] vec, int n)
        {
            double sumatoria = 0, desviancionEstandar = 0;

            //SUCESIÓN
            for (int i = 0; i < n; i++)
            {
                sumatoria = sumatoria + Math.Pow((vec[i] - promedioVector(vec, n)), 2);
            }

            // DESVIANCIÓN ESTANDAR
            desviancionEstandar = Math.Sqrt(sumatoria / n);


            return desviancionEstandar;
        }


    }
}
