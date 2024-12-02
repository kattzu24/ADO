using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            return "Data Source=KATARINA\\SQL24;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }
    }
}
