using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace aplicacion_11
{
    public partial class sql : Form
    {
        public sql()
        {
            InitializeComponent();
        }
        static string conectar = "server=DESKTOP-C69ESQO;database=la_mejor; integrated security=true";
        SqlConnection conecta = new SqlConnection(conectar);

        public DataTable rellenar_datos()
        {
            conecta.Open();
            DataTable dt = new DataTable();
            string rellenar = "select * from la_mejor";
            SqlCommand cmd = new SqlCommand(rellenar, conecta);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            conecta.Close();

            return dt;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sql_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rellenar_datos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string insertar = "insert into la_mejor (id,nombre,apellido,telefono) values(@id,@nombre,@apellido,@telefono)";
            SqlCommand cmd = new SqlCommand(insertar, conecta);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox3.Text);
            cmd.Parameters.AddWithValue("@telefono", textBox4.Text);

            cmd.ExecuteNonQuery();

            conecta.Close();

            dataGridView1.DataSource = rellenar_datos();
            MessageBox.Show("se inserto el registro");

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string modificar = "update la_mejor set id=@id,nombre=@nombre,apellido=@apellido,telefono=@telefono where id=@id";
            SqlCommand cmd = new SqlCommand(modificar, conecta);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox3.Text);
            cmd.Parameters.AddWithValue("@telefono", textBox4.Text);

            cmd.ExecuteNonQuery();

            conecta.Close();

            dataGridView1.DataSource = rellenar_datos();
            MessageBox.Show("se modifico el registro");




        }

        private void button3_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string eliminar = "delete from la_mejor where id=@id";
            SqlCommand cmd = new SqlCommand(eliminar, conecta);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox3.Text);
            cmd.Parameters.AddWithValue("@telefono", textBox4.Text);

            cmd.ExecuteNonQuery();

            conecta.Close();

            dataGridView1.DataSource = rellenar_datos();
            MessageBox.Show("se elimino el registro");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string consultar = "select * from la_mejor where id=" + textBox1.Text;
            SqlCommand mostrar = new SqlCommand(consultar, conecta);

            SqlDataReader registro = mostrar.ExecuteReader();

            if (registro.Read())
            {
                textBox2.Text = registro["nombre"].ToString();
                textBox3.Text = registro["apellido"].ToString();
                textBox4.Text = registro["telefono"].ToString();

                MessageBox.Show("se consulto el registro");
            }
            else
                //{


                MessageBox.Show("no existe un articulo con el codigo ingresado");
            // }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 window = new Form1();
            window.Show();
            this.Hide();
        }
    }
}
