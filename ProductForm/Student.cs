using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductForm
{
    public partial class Student : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Student()
        {
            InitializeComponent();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                string qry = "insert into Student0 values(@rollno,@name,@stream,@percentage,@age,@gender)";



                cmd = new SqlCommand(qry, con);



                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtrollno.Text));
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@stream", txtstream.Text);
                cmd.Parameters.AddWithValue("@percentage",Convert.ToInt32 (txtpercentage.Text));
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text));
                cmd.Parameters.AddWithValue("@gender", txtage.Text);

                con.Open();



                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Inserted");
                }
               // ClearForm();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();
            }
        }
    }
}
