using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Domain
{
    public class TextMessage
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public Guid ChatId { get; set; }
        public string Text { get; set; }
    }
}
