using System;
using NUnit.Framework;
namespace Canducci.Gravatar.Test
{
    [TestFixture]
    public class TestClass
    {
        [TestCase]        
        public void EmailFailedTest()
        {
            Assert.Throws(typeof(InvalidOperationException),
                new TestDelegate(EmailFailed));                       
        }
        private void EmailFailed()
        {
            IEmail email = new Email("");            
        }

        [TestCase]
        public void EmailOkTest()
        {
            IEmail email = new Email("test@test.com");
            Assert.IsInstanceOf<Email>(email);
        }
    }
}
