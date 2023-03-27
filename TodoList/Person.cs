using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Person
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Person(string name)
        {
            var temp = Guid.NewGuid();
            Id = temp.ToString().Substring(0, 8);
            Name = name;
        }

        public Person(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string ToFile()
        {
            return $"{Id};{Name};";
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "\nNome: " + this.Name + "\n";
        }
    }
}
