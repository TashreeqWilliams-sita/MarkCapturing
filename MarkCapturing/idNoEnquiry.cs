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

namespace MarkCapturing
{
    public partial class idNoEnquiry : Form
    {
        public idNoEnquiry()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MCAP0021\SQLEXPRESS01;Initial Catalog=NSC_VraagpunteStelsel;Integrated Security=True");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string idNo = textBox1.Text;

                try
                {
             
                    NSC_VraagpunteStelselEntities DbContext = new NSC_VraagpunteStelselEntities();
                    var getRecord = DbContext.EKS_PUNTESTATE.Where(a => a.PS_ID_NO == idNo).ToList();

                    foreach( var record in getRecord)
                    {
                        listBox1.Items.Add(record.PS_Msheet);
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
        }
    }
}
