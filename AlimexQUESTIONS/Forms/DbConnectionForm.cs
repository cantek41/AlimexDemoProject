using AlimexDAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlimexQUESTIONS
{
    public partial class DbConnectionForm : _baseForm
    {
        private DbParameter dbparam;
        public DbConnectionForm(DbParameter dbparam)
        {
            this.dbparam = dbparam;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            addCloseButton(this);
            init();
        }

        /// <summary>
        /// formun hazılanması 
        /// </summary>
        private void init()
        {
            lblAuth.Text = getResString("auth");
            lblPass.Text = getResString("password");
            lblServer.Text = getResString("server");
            lblUser.Text = getResString("username");
            btnCancel.Text = getResString("cancel");
            btnOk.Text = getResString("ok");
            lblFormName.Text = getResString("dbConnection");
            cmbAuth.Items.Add("Windows Authentication");
            cmbAuth.Items.Add("SQL Server Authentication");

            //defual değerlerin forma yerleştirilmesi
            dbparam = dbparam.getParam();
            txtServar.Text = dbparam.dataSource;

            if (dbparam.IntegratedSecurity)
                cmbAuth.SelectedIndex = 0;
            else
            {
                cmbAuth.SelectedIndex = 1;
                txtUser.Text = dbparam.dbUserId;
                txtPass.Text = dbparam.dbPassword;
            }
            //eventların oluşturulması
            btnOk.Click += btnOk_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// girilen değerleri defult olarak kayder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnOk_Click(object sender, EventArgs e)
        {
            //TODO:burada connection testi yaptılmalı

            dbparam.dataSource = txtServar.Text;
            if (cmbAuth.SelectedIndex == 0)
                dbparam.IntegratedSecurity = true;
            else
            {
                dbparam.IntegratedSecurity = false;
                dbparam.dbUserId = txtUser.Text;
                dbparam.dbPassword = txtPass.Text;
            }
            dbparam.initialCatalog = "AlimexQUESTIONS";
            dbparam.setParam();

            Application.Restart();
           
        }
    }
}
