using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaoYangToolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = DBUtility.DBHelperList.Oracle58.Query("select * from twbas_pass").Tables[0];
        }
    }
}
