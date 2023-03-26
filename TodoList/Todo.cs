using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Todo
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Person Owner { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime? DueDate { get; private set; }
        public bool Status { get; private set; }

        public Todo(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
            Created = DateTime.Now;
            Status = false;
        }

        public Todo(Guid id, string description, DateTime created, DateTime dueDate, bool status)
        {
            Id = id;
            Description = description;
            Created = created;
            DueDate = dueDate;
            Status = status;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Descrição: {Description} | Proprietario: {Owner} | Data de criação: {Created} | Completa: {Status}";
        }

        public string ToFile()
        {
            return $"{Id};{Description};{Owner};{Created};{Status};";
        }

        public void SetStatus()
        {
            if(Status == true)
            {
                Status = false;
            }
            else
            {
                Status = true;
            }
        }

        public void SetPerson(Person owner)
        {
            Owner = owner;
        }
    }
}
