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
    public partial class adv_data_table : Form
    {
        public adv_data_table()
        {
            InitializeComponent();
        }

        private void adv_data_table_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pb_dataset.phone_book_table' table. You can move, or remove it, as needed.
            this.phone_book_tableTableAdapter.Fill(this.pb_dataset.phone_book_table);

        }

        private void phone_book_tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phone_book_tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pb_dataset);

        }
        private void button1_Click(object sender, EventArgs e)
        {
          pb_dataset.phone_book_table.AcceptChanges();
          rows_count.Text = pb_dataset.phone_book_table.Rows.Count.ToString();
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            Int32 p;

            p = phone_book_tableBindingSource.Position;
            p = p + 1;
            lblPosition.Text = p.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phone_book_tableBindingSource.Sort = "id ASC";
        }
    }
}
