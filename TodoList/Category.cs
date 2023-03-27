using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Category
    {
        public string CategoryName { get; set; }

        public Category(string category)
        {
            CategoryName = category;
        }

        public string ToFile()
        {
            return $"{CategoryName};";
        }
    }
}
