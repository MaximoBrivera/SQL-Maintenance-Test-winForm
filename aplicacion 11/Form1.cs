using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aplicacion_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=tecnologia_superior;UID=root;PASSWORDS=;";
        MySqlConnection conecta = new MySqlConnection(conexion);


        public DataTable rellenar_grid()
        {
            conecta.Open();
            DataTable dt = new DataTable();
            string rellenar = "select * from estudiantes";
            MySqlCommand cmd = new MySqlCommand(rellenar, conecta);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conecta.Close();


            return dt;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // dataGridView1.DataSource = rellenar_grid(); esto fue un error mio mala mia no va.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string insertar = "insert into estudiantes(id,nombre,apellido,telefono) values(@id,@nombre,@apellido,@telefono)";
            MySqlCommand cmd = new MySqlCommand(insertar, conecta);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox3.Text);
            cmd.Parameters.AddWithValue("@telefono", textBox4.Text);
            cmd.ExecuteNonQuery();

            conecta.Close();

            dataGridView1.DataSource = rellenar_grid();

            MessageBox.Show("se inserto el registro");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string borrar = "delete from estudiantes where  id=@id";
            MySqlCommand cmd = new MySqlCommand(borrar, conecta);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            cmd.ExecuteNonQuery();

            conecta.Close();

            dataGridView1.DataSource = rellenar_grid();

            MessageBox.Show("se borro el registro");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rellenar_grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string modificar = "update estudiantes set id=@id,nombre=@nombre,apellido=@apellido,telefono=@telefono where id=@id";
            MySqlCommand cmd = new MySqlCommand(modificar, conecta);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox3.Text);
            cmd.Parameters.AddWithValue("@telefono", textBox4.Text);

            cmd.ExecuteNonQuery();


            conecta.Close();

            dataGridView1.DataSource = rellenar_grid();

            MessageBox.Show("se modifico el registro");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            sql window = new sql();
            window.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conecta.Open();
            string consultar = "select * from estudiantes where id=" + textBox1.Text;
            MySqlCommand mostrar = new MySqlCommand(consultar, conecta);

            MySqlDataReader registro = mostrar.ExecuteReader();

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
            conecta.Close();
        }
    }
}
