using AlimexDAL;
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
    public partial class MainForm : _baseForm
    {
        private readonly AppDbContext context;
        private readonly DbConnectionForm dbForm;        
        public MainForm(AppDbContext _context,
            LoginForm childForm,
            DbConnectionForm dbForm)
        {
            context = _context;
            InitializeComponent();         
            childForm.MdiParent = this;
            childForm.Show();
            setTextItems();
            this.dbForm = dbForm;
        }
        /// <summary>
        /// arayüz dil değişimi
        /// </summary>
        private void setTextItems()
        {
            this.fileMenu.Text = getResString("File");
            this.dbConnectionMenuSplit.Text = getResString("dbConnection");
            this.ClearCacheMenuSplit.Text = getResString("dbConnection");
            this.ClearCacheMenuSplit.Text = getResString("clearcache");
        }

        /// <summary>
        /// aksiyon olduğunda otomatik kapatma zamanını güncelle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Click(object sender, EventArgs e)
        {
            AlimexIdentity.Controller.Identity.onEvent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// cache sil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearCache_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userName = String.Empty;
            Properties.Settings.Default.password = String.Empty;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// database seçimi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dbConnectionMenuSplit_Click(object sender, EventArgs e)
        {
            dbForm.MdiParent = this;
            dbForm.Show();
        }

    }
}
