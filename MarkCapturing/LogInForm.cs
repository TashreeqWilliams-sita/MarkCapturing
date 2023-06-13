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

namespace MarkCapturing
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MCAP0021\SQLEXPRESS01;Initial Catalog=NSC_VraagpunteStelsel;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;
            textBox1.Text = "Abbas, Tasmeer";
            textBox2.Text = "Summer@02";


            username = textBox1.Text;
            user_password = textBox2.Text;

            try
            {
                string query = "SELECT * FROM dbo.Users WHERE UserName = '" + textBox1.Text + "' AND Password = '"+textBox2.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0) 
                {
                    username = textBox1.Text;
                    user_password = textBox2.Text;

                    //next page after login succeeded
                    EnterExamMarkForm form2 = new EnterExamMarkForm();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();

                    //to focus username
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Oops! That didnt work");
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
