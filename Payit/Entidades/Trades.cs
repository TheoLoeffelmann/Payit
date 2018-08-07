using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Trades
    {
        public string book { get; set; }
        public string created_at { get; set; }
        public string amount { get; set; }
        public string maker_side { get; set; }
        public string price { get; set; }
        public string tid { get; set; }
    }
}
