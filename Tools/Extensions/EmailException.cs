using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Prokopchuk.Tools.Extensions
{
    internal class EmailException : MyException
    {
        public EmailException(string message) : base(message)
        {

        }
    }
}
