using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadVersion2
{
    class SQLConnection
    {
        public static string directory = Directory.GetCurrentDirectory();

        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + directory + @"\DBHome.mdf;Integrated Security=True";
    }
}
