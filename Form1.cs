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

            if (a > 0)
            {
                MessageBox.Show("Data intersrted in DB");

                displaydata();
            }








        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displaydata();
            // TODO: This line of code loads data into the 'weltec_MorningDataSet.Role_Master' table. You can move, or remove it, as needed.
            this.role_MasterTableAdapter.Fill(this.weltec_MorningDataSet.Role_Master);

        }


        private void displaydata()
        {
            string conn = @"Data Source=LAPTOP-BLNTEBH7\SQLEXPRESS;Initial Catalog=Weltec_Morning;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();   
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from Role_Master";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
            uninstallButtonColumn.Name = "Delete";
            uninstallButtonColumn.Text = "Delete";
            uninstallButtonColumn.HeaderText = "DeleteInfo";
            
            int columnIndex = 2;
            if (dataGridView1.Columns["uninstall_column"] == null)
            {
                dataGridView1.Columns.Insert(columnIndex, uninstallButtonColumn);
            }


            sqlConnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[2].Index)
            {
                var p = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                MessageBox.Show(p.ToString());
            }
        }
    }
}
