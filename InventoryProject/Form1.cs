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
using System.Linq.Expressions;
using System.Diagnostics;

namespace InventoryProject
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fidan\OneDrive\Belgeler\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try{
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Inventory values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                con.Close();
                disp_data();
                MessageBox.Show("Record inserted succesfully");
            }
           

            catch(Exception Ex){
               
               
                MessageBox.Show("You can't enter same Inventory_id which database already has ");

            }
            finally
            {
                textBox1.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                con.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Inventory";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Inventory where Inventory_id='"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();

            con.Close();
            disp_data();
            MessageBox.Show("Record deleted succesfully");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Inventory SET Tools_name='" + textBox2.Text + "',Number_of_tools='" + textBox3.Text + "',Required_more='" + textBox4.Text + "'WHERE Inventory_id='" + textBox1.Text + "'"; 
            cmd.ExecuteNonQuery();
            
            con.Close();
            disp_data();
            MessageBox.Show("Record uptadeted succesfully");
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Inventory WHERE Inventory_id='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

           
        }
    }
}
