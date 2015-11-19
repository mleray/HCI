using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Papricash
{
    class Spending
    {
        public int id { get; set; }
        public int cat { get; set; }
        public int amount { get; set; }
        public string comment { get; set; }
        public DateTime date { get; set; }

        public Spending()
        {
            cat = 0;
            amount = 0;
            comment = "";
            date = DateTime.Today;
        }

        public Spending(int c, int a)
        {
            cat = c;
            amount = a;
            comment = "";
            date = DateTime.Today;
        }

        public Spending(int c, int a, string com)
        {
            cat = c;
            amount = a;
            comment = com;
            date = DateTime.Today;
        }

        public Spending(int c, int a, DateTime d)
        {
            cat = c;
            amount = a;
            comment = "";
            date = d;
        }

        public Spending(int c, int a, string com, DateTime d)
        {
            cat = c;
            amount = a;
            comment = com;
            date = d;
        }
    }
}
