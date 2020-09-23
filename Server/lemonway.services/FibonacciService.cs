using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonway.services
{
    public class FibonacciService : IFibonacciService
    {
        /// <summary>
        /// Return the value of Fibonacci sequence number
        /// return -1 if value > 100 || value < 1
        /// </summary>
        /// <param name="value">value must be Between  1 >= N  <= 100</param>
        /// <returns></returns>
        public int GetValue(int value)
        {
            if (value < 1 || value > 100) 
                return -1;
            else
                return Fibonacci(value);
        }


        /// <summary>
        /// Algo of Fibonacci sequence (recursive version)
        /// </summary>
        /// <param name="value">value must be integer</param>
        /// <returns></returns>
        private int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 2) + Fibonacci(n - 1);
        }
    }
}
