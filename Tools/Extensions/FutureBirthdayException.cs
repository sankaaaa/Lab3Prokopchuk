using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Prokopchuk.Tools.Extensions
{
    internal class FutureBirthdayException : MyException
    {
        public FutureBirthdayException(string message) : base(message)
        {

        }
    }
}
