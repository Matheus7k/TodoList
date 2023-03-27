using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Person(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Person(Guid id, string name)
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
