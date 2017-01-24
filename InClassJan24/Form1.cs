using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InClassJan24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome!");
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {

            LoadVedorAndInvoices();
        }
        public static void LoadVedorAndInvoices()
        {
            AccountsPayableEntities db = new AccountsPayableEntities();
            //var vendorList = (from v in db.Vendors
            //                           join i in db.Invoices on
            //                           v.VendorID equals i.VendorID
            //                           select new {v.VendorName, i.InvoiceNumber }).ToList();

            //foreach (var v in vendorList)
            //{
            //    lstVendorInvoices.Items.Add($"{v.VendorName} : {v.InvoiceNumber}");
            //}


            //make sure to add System.Data.Entity
            var vendorList = db.Vendors.Where(v => v.VendorState == "CA").Include(v => v.Invoices)
                .OrderBy(v => v.VendorName).Take(10).Skip(10).ToList();
        }

    }
}
