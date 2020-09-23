using lemonway.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Description résumée de LemonwayWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class LemonwayWebService : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IXmlToJsonService _xmlToJsonservice;
        private IFibonacciService _fibonacciService;


        public LemonwayWebService()
        {
            _fibonacciService = new FibonacciService();
            _xmlToJsonservice = new XmlToJsonService();
        }

        [WebMethod]
        public int Fibonacci(int n)
        {
            log.Info($"LemonwayWebService Fibonacci({n}) is call");
            return _fibonacciService.GetValue(n);
        }

        [WebMethod]
        public string XmlToJson(string xml)
        {
            log.Info($"LemonwayWebService XmlToJson({xml}) is call");
            return _xmlToJsonservice.Convert(xml);
        }
    }
}
