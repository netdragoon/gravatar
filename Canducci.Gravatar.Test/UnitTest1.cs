using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canducci.Gravatar.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "E-mail format invalid")]
        public void TestEmailFailed()
        {
            try
            {
                IEmail email = new Email("");
                Assert.Fail("E-mail format invalid");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [TestMethod]
        public void TestEmailOk()
        {
            IEmail email = new Email("test@test.com");
            Assert.IsInstanceOfType(email, typeof(Email));
        }
    }
}
