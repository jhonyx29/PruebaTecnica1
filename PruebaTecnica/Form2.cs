using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTecnica
{
    public partial class Form2 : Form
    {
        int altura, altura2, lateral, contador;
        /*  
            Esta solucion se da para no limitar tanto al usuario y que sea libre de cuanta altura y cuadros a lo lateral
            del arbol pueda tener, para su usu los cuadro que esten vacios no se tendran en cuenta.
            Antes de cada ejecucion por boton se valida que el valor de todos los cuadros de texto sean numero.


            altura = usado para calcular cuantos cruadros se crean a lo alto del arbol
            altura2 = usado para reiniciar la altura al momento de agregar cuadros laterales
            lateral = usado para tener un limite, esto es opcional ya que se puede hacer ilimitado pero para comodidad de la vista se limita
            contador = contar cuantos cuadros o controles se agregan, esto nos sirve para poder obtener el valor de cada texbox creado
            
        */

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (ValidaNumero() == "Y")
            {
                lbAltura.Text = altura.ToString();
            }
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            
            if (ValidaNumero() == "Y")
            {
                lbPromedio.Text = PromedioPesoArbol().ToString("0.00");
            }

        }

        private void btnPeso_Click(object sender, EventArgs e)
        {
            if (ValidaNumero() == "Y") 
            {
                lbpeso1.Text = PesoArbol().ToString();
            }
            
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            altura += 1;
            
            if (altura < 18)
            {
                CreaCajas(30, (50 * altura));
                /*TextBox textBox1 = new TextBox();
                textBox1.Location = new Point(30, (50 * altura));
                textBox1.Visible = true;
                textBox1.Text = ""; // cuando no vaya a usar el campo debe dejarlo en null
                textBox1.Name = contador.ToString();
                panel1.Controls.Add(textBox1);*/
                contador += 1;
            }

            else {
                MessageBox.Show("Por espacio en pantalla no se puede agregar mas niveles de altura.");
            }
            altura2 = (50 * altura);
            lateral = 0;

        }

        private void btnLateral_Click(object sender, EventArgs e)
        {
            lateral += 1;
            
            if (altura > 1)
            {
                if (lateral < 18)
                {
                    CreaCajas((150 * lateral), altura2);
                    /*TextBox textBox1 = new TextBox();
                    textBox1.Location = new Point((150 * lateral), altura2);
                    textBox1.Visible = true;
                    textBox1.Text = "";
                    textBox1.Name = "caja" + contador.ToString();
                    panel1.Controls.Add(textBox1);*/
                    contador += 1;
                }
                else
                {
                    MessageBox.Show("Por espacio en pantalla no se puede agregar mas niveles de altura.");
                }
            }
            else
            {
                MessageBox.Show("En la primera fila solo puede ir un cuadro de valor");
            }

        }
        private decimal PesoArbol() {
            decimal peso = 0;

            for (int i = 0; i <= (contador - 1); i++) 
            {
                var x = (panel1.Controls[i] as TextBox).Text; //prueba para saber el valor antes de asignarlo
                peso += int.Parse(x);
            }
            return peso;
        }
        private decimal PromedioPesoArbol()
        {
            decimal prueba3 = PesoArbol();
            decimal promediopeso = (PesoArbol() / contador);            

            return promediopeso;
        }
        private void CreaCajas(int x, int y)
        {
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(x, y);
            textBox1.Visible = true;
            textBox1.Text = "";
            textBox1.Name = "caja" + contador.ToString();
            panel1.Controls.Add(textBox1);
        }
        private String ValidaNumero()
        {
            //Validamos si es numero N = no es numero; Y = es numero
            String resultadoValidacion = "N";
            double valida;
            for (int i = 0; i <= (contador - 1); i++)
            {
                resultadoValidacion = "N";
                if (double.TryParse((panel1.Controls[i] as TextBox).Text, out valida))
                {
                    resultadoValidacion = "Y";
                }
            }
            
            if (resultadoValidacion == "N")
            {
                MessageBox.Show("Por favor revise las casillas ya que alguno no es un numero");
            }
            return resultadoValidacion;

        }
    }
}
