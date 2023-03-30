using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phone_Book
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void phone_book_tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phone_book_tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pb_dataset);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'pb_dataset.phone_book_table' table. You can move, or remove it, as needed.
                this.phone_book_tableTableAdapter.Fill(this.pb_dataset.phone_book_table);
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            groupBox1.Enabled = false;

            phone_book_tableDataGridView.Enabled = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            new_edit_del_btn_enable();

            phone_book_tableBindingSource.AddNew();

            pictureBox1.Image = Phone_Book.Properties.Resources.no_image; //Loading Default Image//
        }

        void new_edit_del_btn_enable()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            groupBox1.Enabled = true;
        }

        void save_cancel_btn_enable()
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            groupBox1.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Int32 rc;

            rc = pb_dataset.phone_book_table.Rows.Count;
            if (rc == 0)
            {
                MessageBox.Show("Please select the record to Edit");
                return;
            }
            
            new_edit_del_btn_enable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Int32 rc;

            rc = pb_dataset.phone_book_table.Rows.Count;
            if (rc == 0)
            {
                MessageBox.Show("Please select the record to Delete");
                return;
            }
            
            new_edit_del_btn_enable();

            groupBox1.Enabled = false;

            phone_book_tableBindingSource.RemoveCurrent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save_cancel_btn_enable();
            phone_book_tableBindingSource.EndEdit();
            Int32 r;

            try
            {
                r = phone_book_tableTableAdapter.Update(pb_dataset.phone_book_table);

                if (r > 0)
                {
                    // MessageBox.Show("Saved");
                }
                else
                {
                    //  MessageBox.Show("Not Saved");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                     
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            save_cancel_btn_enable();

            pb_dataset.phone_book_table.RejectChanges();
            phone_book_tableBindingSource.CancelEdit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            phone_book_tableTableAdapter.FillBy(pb_dataset.phone_book_table);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string fn;
            fn = openFileDialog1.FileName;
            
            if (fn == "openFileDialog1")
            {
                return;
            }
            pictureBox1.Image = Image.FromFile(fn);
        }
    }
}
