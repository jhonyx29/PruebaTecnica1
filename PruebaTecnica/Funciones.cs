using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica
{
    //Clase dedicada a funciones y metodos
    internal class Funciones
    {
        public long FuncionBase (long num1user, int base1user, int base2user)
            {
            String mensaje;
           //Varificamos que el numero de cualquiera de las dos bases sea entre 2 y 10
            if(base1user > 1 && base1user < 11 && base2user > 1 && base2user < 11)
            {
                long resultado = 0; //creamos la variable donde se almacenara el resultado
                if (base1user == 10 || base2user == 10) // condicion para base 10
                {
                    int prueba = 0; // usada para prueba
                    long residuo = 0; //capturamos el residuo en esta variable
                    for (long i = num1user, j = 0; i > 0; i /= base2user, j++)
                    {
                        residuo = i % base2user; //capturamos el residuo
                        prueba = Convert.ToInt32(Math.Pow(base1user, j));
                        resultado += residuo * Convert.ToInt32(Math.Pow(base1user, j)); //elevamos a la potencia y multiplicamos por el residuo
                    }

                }
                else
                {
                    //Pasamos la base en caso de que ninguna sea 10 a 10, luego reporcesamos el resultado con base10
                    long numeroConvertirDec = FuncionBase(num1user, base1user, 10);
                    numeroConvertirDec = FuncionBase(numeroConvertirDec, 10, base2user);
                }

                return resultado;

            }
            else
            {
                return -1;
            }
        }
    }
}
