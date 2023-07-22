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

namespace Mobile
{
    public partial class Form2 : Form
    {
        SqlConnection conection = new SqlConnection("data source=Desktop-5QO01DM; initial catalog=walid;integrated security=true");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void login_Click(object sender, EventArgs e)
        {

            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Enter your Username and Password");

            }
            else
            {
                try
                {
                    if(conection.State != ConnectionState.Open)
                    {
                        conection.Open();
                    }
                  SqlDataAdapter adapter = new SqlDataAdapter("select * from users where Username = '"+txtusername.Text+"' and password = '"+txtpassword.Text+"'", conection);
                   DataTable dt = new DataTable();
                    adapter.Fill(dt); 
                    if(dt.Rows.Count > 0)
                    {
                        Form1 f1 = new Form1();
                        this.Hide(); 
                        f1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Try Agian");
                    }


                    conection.Close();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); 

                }
            }

        }
    }
}
