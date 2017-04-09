using AlimexIdentity.Controller;
using AlimexIdentity.Model;
using AlimexQUESTIONS.helper;
using AlimexService;
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
    public partial class LoginForm : _baseForm
    {
        private LanguageHelper langHelper;
        private IUserService userSrv;
        public LoginForm(LanguageHelper langHelper,
            IUserService userSrv)
        {
            this.langHelper = langHelper;
            this.userSrv = userSrv;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            addCloseButton(this);

        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            init();
            setTextItems();
            checkAutoLogin();
        }

        /// <summary>
        /// arayüz ayarlamaları
        /// </summary>
        private void init()
        {
            txtUserName.Text = Properties.Settings.Default.userName;

            btnLogin.Click += btnLogin_Click;
            btnRegister.Click += btnRegister_Click;


            cmbLanguage.SelectedIndexChanged += cmbLanguage_Changed;
            foreach (var item in Enum.GetValues(typeof(EnumLanguage)))
            {
                cmbLanguage.Items.Add(item.ToString());
            }
            cmbLanguage.SelectedText = langHelper.getLanguage().ToString();
        }

        //kaydol butonu click
        void btnRegister_Click(object sender, EventArgs e)
        {
            LoginModel userModel = new LoginModel();
            userModel.userName = txtUserName.Text;
            userModel.password = txtPassword.Text;
            userSrv.createUser(userModel);
            btnLogin_Click(null, null);
        }

        /// <summary>
        /// dil değişim 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmbLanguage_Changed(object sender, EventArgs e)
        {
            langHelper.setLanguage(cmbLanguage.Text);
            setTextItems();
        }
        /// <summary>
        /// arayüz dil değişimi
        /// </summary>
        void setTextItems()
        {
            lblLanguage.Text = getResString("language");
            lblLoginMessaege.Text = getResString("loginMessage");
            lblPassword.Text = getResString("password");
            lblUserName.Text = getResString("username");
            chkRemember.Text = getResString("savepassword");
            btnLogin.Text = getResString("login");
            btnRegister.Text = getResString("register");
        }

        /// <summary>
        /// auto login
        /// </summary>
        private void checkAutoLogin()
        {
            txtUserName.Text = Properties.Settings.Default.userName;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.password))
            {
                txtPassword.Text = Properties.Settings.Default.password;
                btnLogin_Click(null, null);
            }
        }

        /// <summary>
        /// login click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnLogin_Click(object sender, EventArgs e)
        {
            LoginModel userModel = new LoginModel();
            userModel.userName = txtUserName.Text;
            userModel.password = txtPassword.Text;

            Properties.Settings.Default.userName = txtUserName.Text;
            if (chkRemember.Checked)
                Properties.Settings.Default.password = txtPassword.Text;
            Properties.Settings.Default.Save();
            var user = userSrv.login(userModel);
            if (user != null)
            {
                Identity.setIdentity(new UserIdentiyModel()
                {
                    userName = user.Name,
                    userId = user.Id.ToString(),
                    timeOut = 10,
                    role = new List<string>() { "Admin" }
                });
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Bilgileri Hatalı");
            }
        }
        public override void closeForm(object sender, EventArgs e)
        {
            base.closeForm(sender, e);
            Application.Exit();
        }

    }
}
