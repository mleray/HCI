using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papricash
{
    class Spending
    {
        private int cat;
        private float amount;
        private string comment;

        public int Cat
        {
            get
            {
                return cat;
            }

            set
            {
                cat = value;
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }

            set
            {
                comment = value;
            }
        }
    }
}
