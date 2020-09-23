using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace lemonway.services
{
    public class XmlToJsonService : IXmlToJsonService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Takes as input a xml string and returns the json form of the xml string. 
        /// It will return "Bad Xml format" if the input string is not a well-formed xml.
        /// </summary>
        /// <param name="xml">string contain xml</param>
        /// <returns></returns>
        public string Convert(string xml)
        {
            XElement x;
            try
            {
                x = XElement.Parse(xml);
                var nb = x.Descendants().Count();
                var format = nb > 0 ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
                return ConvertToJson(x, format, true);
            }
            catch (System.Xml.XmlException ex)
            {
                log.Error("This is an error message");
                return "Bad Xml format";
            }
        }

        /// <summary>
        /// Use Newtonsoft.Json to convert XElement To Json
        /// </summary>
        /// <param name="xml">string contain xml</param>
        /// <param name="format">param for format return</param>
        /// <param name="removeEmptyValue">remove empty value from xmlt</param>
        /// <returns></returns>
        private string ConvertToJson(XElement x, Newtonsoft.Json.Formatting format, bool removeEmptyValue) =>
            JsonConvert.SerializeXNode(removeEmptyValue ? XmlRemoveNullValue(x) : x, format);

        /// <summary>
        /// Remove null ou empty value from XElement
        /// </summary>
        /// <param name="x">x is XElement</param>
        /// <returns></returns>
        private XElement XmlRemoveNullValue(XElement x)
        {
            foreach (XElement child in x.Descendants().Reverse())
            {
                if (!child.HasElements && string.IsNullOrEmpty(child.Value) && !child.HasAttributes) child.Remove();
            }
            return x;
        }

    }
}
