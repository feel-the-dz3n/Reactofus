using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reactofus
{
    public class TrivialException : Exception
    {
        public TrivialException(string message) : base(message)
        {
        }
    }
}
