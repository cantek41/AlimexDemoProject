using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using AlimexIdentity.Model;


namespace AlimexIdentity.Controller
{
    public static class Identity
    {
        private static string userId;
        private static string userName;
        private static List<string> role;
        private static byte? timeOut;
        private static System.Timers.Timer noActionTimer;
        private static DateTime lastActiveDate;

        public static string getUserId()
        {
            return userId;
        }

        /// <summary>
        /// LogOut or NoAction
        /// </summary>
        public static void clearUser()
        {
            userId = null;
            userName = null;
            role = null;
            noActionTimer = null;
            timeOut = null;
        }
        /// <summary>
        /// Login set User prop
        /// </summary>
        /// <param name="model"></param>
        public static void setIdentity(UserIdentiyModel model)
        {
            userName = model.userName;
            role = model.role;
            userId = model.userId;
            if (model.timeOut != null)
            {
                timeOut = (byte)model.timeOut;
                noActionTimer = new System.Timers.Timer();
                noActionTimer.Interval = 1000;
                noActionTimer.Enabled = true;
                noActionTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                lastActiveDate = DateTime.Now.AddMinutes((byte)timeOut);
                noActionTimer.Start();
            }

        }

        public static void onEvent()
        {
            if (timeOut != null)
                lastActiveDate = DateTime.Now.AddMinutes((byte)timeOut);
        }
        /// <summary>
        /// Timer tick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            int a = DateTime.Now.CompareTo(lastActiveDate);
             if (a != -1)
            {
                Console.WriteLine("Bitti");
                noActionTimer.Stop();
                identityAlert();
            }
        }

        /// <summary>
        /// bir aksiyon yoksa uygulamayı kapat
        /// burada yeniden şifre sordurup devam ettirilebilinir
        /// arka plandaki formlar disabled edilerek
        /// </summary>
        private static void identityAlert()
        {
           // MessageBox.Show("Süre Doldu Tekrar Giriş Yapın");                        
            Application.Exit();
        }
    }

}
