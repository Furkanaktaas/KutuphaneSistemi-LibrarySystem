using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.DataBase
{
    public class ReserveApiModelView
    {
        public int reserveID { get; set; }
        public int bookID { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string writer { get; set; }
        public string publisher { get; set; }
        public int numberOfPages { get; set; }
    }
}
