using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrderBooks
    {
        public List<AsksBids> asks { get; set; }
        public List<AsksBids> bids { get; set; }
        public string updated_at { get; set; }
        public string sequence { get; set; }
    }
}
