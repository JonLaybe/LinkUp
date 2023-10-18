using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Application.Common.Exceptions
{
    public class CheckFailedException : Exception
    {
        public CheckFailedException(string name) : base($"Check failed \"{name}\".") { }
    }
}
