using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWindowApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string conn = @"Data Source=LAPTOP-BLNTEBH7\SQLEXPRESS;Initial Catalog=Weltec_Morning;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = $"insert into Role_Master (Name) values ('{txtname.Text}')";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection; 
            cmd.CommandText = query;    
            int a = cmd.ExecuteNonQuery();

            if(a>0)
            {
                MessageBox.Show("Data intersrted in DB");
            }




           



        }
    }
}
