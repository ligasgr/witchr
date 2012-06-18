using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Witchr.Core.Wpf;

namespace Witchr.Core.Tests.Wpf
{
    [TestClass]
    public class WitchrAppTest
    {

        [TestMethod]
        public void ShouldCreateWitchrAppProperly()
        {
            //given
            WitchrApp testee;
            //when
            testee = new WitchrApp();
            //then
            Assert.IsNotNull(testee);
        }
    }
}
