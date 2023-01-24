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
    public partial class DCemployeii : Form

    {

        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommandBuilder sqlCommandBuilder;
        DataSet ds;
        public DCemployeii()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }
        private void ClearForm()
        {
            txtid.Clear();
            txtname.Clear();
            txtdeptname.Clear();
            txtsalary.Clear();
            txtage.Clear();
        }
        private DataSet GetAll()
        {
            adapter = new SqlDataAdapter("select * from Employeii", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlCommandBuilder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "DCemp");// product is table name given to the DataSet
            return ds;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["DCemp"].NewRow();
                row["empid"] = txtid.Text;
                row["empname"] = txtname.Text;
                row["deptname"] = txtdeptname.Text;
                row["salary"] = txtsalary.Text;
                row["age"] = txtage.Text;
                ds.Tables["DCemp"].Rows.Add(row);
                int result = adapter.Update(ds.Tables["DCemp"]);
                if (result == 1)
                {
                    MessageBox.Show("Record inserted..");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["DCemp"].Rows.Find(txtid.Text);

                if (row != null)
                {
                    txtname.Text = row["empname"].ToString();
                    txtdeptname.Text = row["deptname"].ToString();
                    txtsalary.Text = row["salary"].ToString();
                    txtage.Text = row["age"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["DCemp"].Rows.Find(txtid.Text);

                if (row != null)
                {
                    row["empname"] = txtname.Text;
                    row["deptname"] = txtdeptname.Text;
                    row["salary"] = txtsalary.Text;
                    row["age"] = txtage.Text;
                    int result = adapter.Update(ds.Tables["DCemp"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record updated..");
                        ClearForm();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["DCemp"].Rows.Find(txtid.Text);

                if (row != null)
                {
                    row.Delete();
                    int result = adapter.Update(ds.Tables["DCemp"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record deleted..");
                        ClearForm();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                EmployeList.DataSource = ds.Tables["DCemp"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
