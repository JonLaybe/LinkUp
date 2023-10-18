using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(LinkUpDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
