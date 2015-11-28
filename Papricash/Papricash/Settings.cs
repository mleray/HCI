using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papricash
{
    class Settings
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int Threshold { get; set; }
        public int Currency { get; set; }
    }
}
