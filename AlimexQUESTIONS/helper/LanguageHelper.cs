using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlimexQUESTIONS.helper
{
    public enum EnumLanguage
    {
        en,
        tr
    }
    public class LanguageHelper
    {
        public EnumLanguage getLanguage()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.lang))
            {
                Properties.Settings.Default.lang = EnumLanguage.tr.ToString();
            }
            switchLang(Properties.Settings.Default.lang);
            return (EnumLanguage)Enum.Parse(typeof(EnumLanguage), Properties.Settings.Default.lang);
        }
        public void setLanguage(string lang)
        {
            Properties.Settings.Default.lang = lang;
            switchLang(lang);
        }

        private void switchLang(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);            
        }
    }
}
