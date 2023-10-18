using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkUp.Application.Common.Exceptions
{
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException(object value) :base($"Request: invalid character ({value}).") { }
    }
}
