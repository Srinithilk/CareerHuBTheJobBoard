using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHuBTheJobBoard.MyExceptions
{
    internal class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string  message) : base(message) { }
    }
}
