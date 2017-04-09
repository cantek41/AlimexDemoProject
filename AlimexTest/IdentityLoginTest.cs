using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlimexIdentity.Controller;


namespace AlimexTest
{
    [TestClass]
    public class IdentityLoginTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void isNullLogin()
        {
           
        }
        
    }
}
