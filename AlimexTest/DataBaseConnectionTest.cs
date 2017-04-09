using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlimexDAL;
using AlimexDAL.Model;

namespace AlimexTest
{
    [TestClass]
    public class DataBaseConnectionTest
    {
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void connectionNullArgumentTest()
        {
            AppDbContext d = new AppDbContext(new DbParameter());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void connectionTest()
        {
            AppDbContext d = new AppDbContext(new DbParameter() {
                dataSource = "(LocalDb)\v11.0",
                initialCatalog = "WebApplication1-20170408040228",
                IntegratedSecurity=true
            });            
        }
    }
}
