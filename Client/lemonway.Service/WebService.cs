using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonway.Service
{
    public class WebService : IWebService
    {
        private readonly localhost.LemonwayWebService _service;

        public WebService()
        {
            _service = new localhost.LemonwayWebService();
        }

        public int Fibonacci(int n) =>_service.Fibonacci(n);
    }
}
