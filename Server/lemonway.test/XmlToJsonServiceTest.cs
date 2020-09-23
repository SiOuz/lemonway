using lemonway.services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonway.test
{
    [TestClass]
    public class XmlToJsonServiceTest
    {
        private static IXmlToJsonService _XmlToJsonservice;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            _XmlToJsonservice = new XmlToJsonService();
            
        }

        /// <summary>
        /// Test Service with a bad format of xml
        /// </summary>
        [TestMethod]
        public void BadFormat()
        {
            var result = _XmlToJsonservice.Convert("<foo>hello</bar>");
            Assert.IsTrue(result.Equals("Bad Xml format"));
        }

        /// <summary>
        /// Convert a (valid) xml to json
        /// result json is in file
        /// </summary>
        ///  [DataTestMethod]
        [DataTestMethod]
        [DataRow(@"Samples\sample1.xml", @"Samples\sample1.json")]
        [DataRow(@"Samples\sample2.xml", @"Samples\sample2.json")]
        public void Convert(string xmlFilePath, string jsonFilePath)
        {
            var xml = File.ReadAllText(xmlFilePath);
            var json = File.ReadAllText(jsonFilePath);
            var result = _XmlToJsonservice.Convert(xml);
            Assert.IsTrue(json.Equals(result));
        }
    }
}
