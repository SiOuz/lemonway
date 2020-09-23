using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonway.services
{
    public interface IXmlToJsonService
    {
        /// <summary>
        /// Takes as input a xml string and returns the json form of the xml string. 
        /// It will return "Bad Xml format" if the input string is not a well-formed xml.
        /// </summary>
        /// <param name="xml">string contain xml</param>
        /// <returns></returns>
        string Convert(string xml);
    }
}
