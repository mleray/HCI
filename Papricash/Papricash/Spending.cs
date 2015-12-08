using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papricash
{
    /// <summary>
    /// Class used to define the spendings and their attributes
    /// </summary>
    public class Spending // Table for database
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Cat { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        
        public override string ToString()
        {
            string result = String.Empty;
            result += "Date: " + Date + "\n";
            result += "Amount: " + Amount + "\n";
            result += "Category: " + Cat + "\n";
            if (Comment != String.Empty)
            {
                result += "Comment: " + Comment + "\n";
            }
            return result;
        }
    }
}
