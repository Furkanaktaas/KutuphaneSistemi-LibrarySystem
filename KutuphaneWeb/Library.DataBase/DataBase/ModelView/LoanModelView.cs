using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataBase.DataBase
{
    public class LoanModelView
    {

        public LoanModelView()
        {
            books = new List<Book>();
            users = new List<User>();
        }

        public List<Book> books { get; set; }
        public List<User> users { get; set; }

    }
}
