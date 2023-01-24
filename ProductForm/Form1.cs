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
using System.Configuration;

namespace ProductForm
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public Form1()
        {
            InitializeComponent();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //step 2 -->Wrte query here

                string qry = "insert into Product0 values(@productname,@price,@com)";

                //step 3--->Assign query to command class

                cmd = new SqlCommand(qry, con);

                //step 4--->Assign values to the parameter

                cmd.Parameters.AddWithValue("@productName", txtName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@com", txtComname.Text);

                //step 5--->open connection
                con.Open();

                // step 6---->fire query

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Inserted");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //step 7


            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //step 2 -->Wrte query here

                string qry = "update  Product0 set  Name=@name,Price=@price,CompanyName=@com where Id=@id";

                //step 3--->Assign query to command class

                cmd = new SqlCommand(qry, con);

                //step 4--->Assign values to the parameter

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                cmd.Parameters.AddWithValue("@com", txtComname.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));

                //step 5--->open connection
                con.Open();

                // step 6---->fire query

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Updated");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //step 7


            finally
            {
                con.Close();
            }



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //step 2 -->Wrte query here

                string qry = "select *from Product0 where Id=@id";




                //step 3--->Assign query to command class

                cmd = new SqlCommand(qry, con);

                //step 4--->Assign values to the parameter

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
               

                //step 5--->open connection


                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["Name"].ToString();
                        txtPrice.Text = dr["Price"].ToString();
                        txtComname.Text = dr["CompanyName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
                // step 6---->fire query

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //step 7


            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //step 2 -->Wrte query here

                string qry = "delete from Product0 where Id=@id";

                //step 3--->Assign query to command class

                cmd = new SqlCommand(qry, con);

                //step 4--->Assign values to the parameter
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
               
                //step 5--->open connection
                con.Open();

                // step 6---->fire query

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Deleted");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //step 7


            finally
            {
                con.Close();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            
            
                try
                {
                    //step 2 -->Wrte query here

                    string qry = "select * from Product0";

                    //step 3--->Assign query to command class

                    cmd = new SqlCommand(qry, con);

                    
                   

                    //step 5--->open connection
                    con.Open();

                    dr = cmd.ExecuteReader();

                   
                    if (dr.HasRows)
                    {
                        DataTable table = new DataTable();
                    table.Load(dr);
                    ProductList.DataSource = table;
                    }
                else
                {
                    MessageBox.Show("Record not found");
                }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                //step 7


                finally
                {
                    con.Close();
                }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtComname.Clear();

        }
    }
}
