using AlimexDAL.Model;
using AlimexQUESTIONS.helper;
using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlimexQUESTIONS
{
    static class Program
    {
        private static IContainer container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            initAutoFac();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = container.Resolve<MainForm>();
            Application.Run(mainForm);

        }

       
        private static void initAutoFac()
        {
            var builder = new ContainerBuilder();
            // var assembly =  BuildManager.GetReferencedAssemblies();
            //   var assembly = AppDomain.CurrentDomain.GetAssemblies()
            //    .Where(x=>x.FullName.StartsWith("Alimex")).ToArray();           

            loadAllModuleFromAssembly(builder);

            builder.RegisterType<DbParameter>().AsSelf();
            builder.RegisterType<LanguageHelper>().AsSelf();
            builder.RegisterType<LoginForm>().AsSelf();
            builder.RegisterType<DbConnectionForm>().AsSelf();
            builder.RegisterType<MainForm>().AsSelf();
            container = builder.Build();

        }

        private static void loadAllModuleFromAssembly(ContainerBuilder builder)
        {
            IList<Assembly> binAssemblies = new List<Assembly>();

            string binFolder = AppDomain.CurrentDomain.BaseDirectory;
            IList<string> dllFiles = Directory.GetFiles(binFolder, "*.dll",
                SearchOption.TopDirectoryOnly).ToList();

            foreach (string dllFile in dllFiles)
            {

                Assembly locatedAssembly = Assembly.LoadFrom(dllFile);

                if (locatedAssembly != null)
                {
                    binAssemblies.Add(locatedAssembly);
                }
            }

            builder.RegisterAssemblyModules(binAssemblies.ToArray());
        }




    }
}
