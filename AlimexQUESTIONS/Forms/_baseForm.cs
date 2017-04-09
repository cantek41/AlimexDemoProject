using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlimexQUESTIONS
{
    public class _baseForm : Form
    {
        private ResourceManager resManager= new ResourceManager("AlimexQUESTIONS.lang.Res", Assembly.GetExecutingAssembly());       
        /// <summary>
        /// formalara X butonunun  konulması
        /// </summary>
        /// <param name="form"></param>
        protected void addCloseButton(_baseForm form)
        {
            Label closeLabel = new Label();
            closeLabel.Text = "X";
            closeLabel.Location = new System.Drawing.Point(form.ClientSize.Width - 30, 20);
            closeLabel.Click += closeForm;
            form.Controls.Add(closeLabel);
        }
        /// <summary>
        /// formların borderı olmadığı için mause move çalıoşması devre dışı kalıyor
        /// bunu devreye almak için 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        public virtual void closeForm(object sender, EventArgs e)
        {
            this.Close();
        }

        protected string getResString(string key)
        {            
            return resManager.GetString(key);
        }
    }
}
