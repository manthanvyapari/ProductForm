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
    public partial class Form2 : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void ClearForm()
        {
            txtid.Clear();
            txtname.Clear();
            txtdeptname.Clear();
            txtsalary.Clear();
            txtage.Clear();
        }
        public Form2()
        {
            InitializeComponent();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               

                string qry = "insert into Employeii values(@empid,@empname,@deptname,@salary,@age)";

               

                cmd = new SqlCommand(qry, con);

                

                cmd.Parameters.AddWithValue("@empid",Convert.ToInt32( txtid.Text));
                cmd.Parameters.AddWithValue("@empname", txtname.Text);
                cmd.Parameters.AddWithValue("@deptname", txtdeptname.Text);
                cmd.Parameters.AddWithValue("@salary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text));

                
                con.Open();

               

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Inserted");
                }
                ClearForm();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
              

                string qry = "update  Employeii set  empname=@name,deptname=@dname,salary=@salary,age=@age where empid=@id";

                

                cmd = new SqlCommand(qry, con);

            

                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@dname", (txtdeptname.Text));
                cmd.Parameters.AddWithValue("@salary",Convert.ToInt32(txtsalary.Text));
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));

              
                con.Open();

               

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Updated");
                }
                ClearForm();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
              

                string qry = "select *from Employeii where empid=@id";




         

                cmd = new SqlCommand(qry, con);

              

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));


               


                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtname.Text = dr["empname"].ToString();
                        txtdeptname.Text = dr["deptname"].ToString();
                        txtsalary.Text = dr["salary"].ToString();
                        txtage.Text = dr["age"].ToString();
                    }
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


            


            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
             

                string qry = "delete from Employeii where empid=@id";

                

                cmd = new SqlCommand(qry, con);

              
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));

             
                con.Open();

           

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record Deleted");
                }
                ClearForm();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
              

                string qry = "select * from Employeii";

                

                cmd = new SqlCommand(qry, con);




                
                con.Open();

                dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
                    EmployeList.DataSource = table;
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


           


            finally
            {
                con.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtname.Clear();
            txtdeptname.Clear();
            txtsalary.Clear();
            txtage.Clear();
        }
    }
    
}
