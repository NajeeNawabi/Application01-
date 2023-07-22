using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mobile
{
    public partial class Form1 : Form
    {
        SqlConnection conection = new SqlConnection("data source=Desktop-5QO01DM; initial catalog=walid;integrated security=true");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showdata();
            delete.Enabled = false;
            update.Enabled = false;
            // TODO: This line of code loads data into the 'walidDataSet.phone' table. You can move, or remove it, as needed.

        }
        public void showdata()
        {
            try
            {
                if (conection.State != ConnectionState.Open)
                {
                    conection.Open();
                }
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from phone", conection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = (dt);
                conection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

            if (textBoxname.Text == "" || textBoxmodel.Text == "" || textBoxcategory.Text == "" || textBoxprice.Text == "")
            {
                MessageBox.Show("fill the Tex Box");
            }
            else
            {
                try
                {

                    if (conection.State != ConnectionState.Open)
                    {
                        conection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("delete from phone  ", conection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("sucess");
                    showdata();
                    cleardata();


                    conection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }


        }

        private void save_Click(object sender, EventArgs e)

        {
            if (textBoxname.Text == "" || textBoxmodel.Text == "" || textBoxcategory.Text == "" || textBoxprice.Text == "")
            {
                MessageBox.Show("fill the Tex Box");
            }
            else
            {
                try
                {

                    if (conection.State != ConnectionState.Open)
                    {
                        conection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("insert into phone (Name,Model,Category,Price) values('" + textBoxname.Text + "','" + textBoxmodel.Text + "','" + textBoxcategory.Text + "','" + textBoxprice.Text + "')", conection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("sucess");
                    showdata();
                    cleardata();


                    conection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
               

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public void cleardata()
        {
            textBoxname.Text = "";
            textBoxmodel.Text = "";
            textBoxcategory.Text = "";
            textBoxprice.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            DataGridViewRow row1 = dataGridView1.Rows[row];
            textBoxname.Text = row1.Cells[0].Value.ToString();
            textBoxmodel.Text = row1.Cells[1].Value.ToString();
            textBoxcategory.Text = row1.Cells[2].Value.ToString(); 
            textBoxprice.Text = row1.Cells[3].Value.ToString();
            save.Enabled = false;
            delete.Enabled = true;
            update.Enabled = true;
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (textBoxname.Text == "" || textBoxmodel.Text == "" || textBoxcategory.Text == "" || textBoxprice.Text == "")
            {
                MessageBox.Show("fill the Tex Box");
            }
            else
            {
                try
                {

                    if (conection.State != ConnectionState.Open)
                    {
                        conection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("update  phone set Name='"+textBoxname.Text+"',Model='"+textBoxmodel.Text+"',Category='"+textBoxcategory.Text+"',Price='"+textBoxprice.Text+"'", conection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("sucess");
                    showdata();
                    cleardata();


                    conection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 =new Form2();
            f2.ShowDialog();
        }
    } 
}
