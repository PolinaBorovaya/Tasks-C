using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Обобщённые_типы_1.Classes
{
    internal class Book
    {
        public string Title { get; set;  }
        public string Author { get; set;  }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Author}: {Title}";
        }
    }
}
