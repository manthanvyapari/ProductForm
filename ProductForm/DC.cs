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
    public partial class DC : Form
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommandBuilder sqlCommandBuilder;
        DataSet ds;

        public DC()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

        private DataSet GetAll()
        {
            adapter = new SqlDataAdapter("select * from Product0", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlCommandBuilder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, "DCproduct");// product is table name given to the DataSet
            return ds;

        }
        private void ClearForm()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtComname.Clear();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                DataRow row = ds.Tables["DCproduct"].NewRow();
                row["Name"] = txtName.Text;
                row["Price"] = txtPrice.Text;
                row["CompanyName"] = txtComname.Text;
                ds.Tables["DCproduct"].Rows.Add(row);
                int result = adapter.Update(ds.Tables["DCproduct"]);
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
                DataRow row = ds.Tables["DCproduct"].Rows.Find(txtId.Text);

                if (row != null)
                {
                    txtName.Text = row["Name"].ToString();
                    txtPrice.Text = row["Price"].ToString();
                    txtComname.Text = row["CompanyName"].ToString();

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
                DataRow row = ds.Tables["DCproduct"].Rows.Find(txtId.Text);

                if (row != null)
                {
                    row["Name"] = txtName.Text;
                    row["Price"] = txtPrice.Text;
                    row["CompanyName"] = txtComname.Text;
                    int result = adapter.Update(ds.Tables["DCproduct"]);
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
                DataRow row = ds.Tables["DCproduct"].Rows.Find(txtId.Text);

                if (row != null)
                {
                    row.Delete();
                    int result = adapter.Update(ds.Tables["DCproduct"]);
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

        //private void btnShowAll_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ds = GetAll();
        //        ProductList.DataSource = ds.Tables["DCproduct"];
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtComname.Clear();
        }

        private void btnShowAll_Click_1(object sender, EventArgs e)
        {
            try
            {
                ds = GetAll();
                ProductList.DataSource = ds.Tables["DCproduct"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

