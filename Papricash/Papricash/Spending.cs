using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papricash
{
    public class Spending
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int Cat { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset Date { get; set; }
        
        public override string ToString()
        {
            string result = String.Empty;
            result += "Spending number: " + Id + "\n";
            result += "Category: " + Cat + "\n";
            result += "Amount: " + Amount + "\n";
            if (Comment != String.Empty)
            {
                result += "Comment: " + Comment + "\n";
            }
            result += "Date: " + Date.ToString() + "\n";
            return result;
        }
    }
}
