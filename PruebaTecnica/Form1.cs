namespace PruebaTecnica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Llamamos a la funcion con respecto a los numeros ingresador por el usuario
            Funciones funciones= new Funciones();
            txtResultado.Text = funciones.FuncionBase(int.Parse(txtNum1.Text), int.Parse(txtBase1.Text), int.Parse(txtBase2.Text)).ToString();
        }
    }
}