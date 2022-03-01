using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antiban
{
    public class AntibanResult
    {
        public int Priority { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public int EventMessageId { get; set; }
        public int QueueNumber { get; set; }
    }
}
