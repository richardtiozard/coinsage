using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Models
{
    public class Logging : TableEntity
    {
        public Logging()
        {

        }

        public Logging(string userid, string datetime)
        {
            PartitionKey = userid;
            RowKey = datetime;
        }

        public string email { get; set; }
        public string fullname { get; set; }
        public DateTime datetime { get; set; }
        public string activity { get; set; }
    }
}
