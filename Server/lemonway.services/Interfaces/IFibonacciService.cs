using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lemonway.services
{
    public interface IFibonacciService
    {
        /// <summary>
        /// Return the value of Fibonacci sequence number
        /// return -1 if value > 100 || value < 1
        /// </summary>
        /// <param name="value">value must be Between  1 >= N  <= 100</param>
        /// <returns></returns>
        int GetValue(int value);
    }
}
