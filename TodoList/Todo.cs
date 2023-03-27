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
        public string Category { get; set; }
        public Person Owner { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool Status { get; private set; }

        public Todo(string description, string category, Person owner, DateTime dueDate)
        {
            Id = Guid.NewGuid();
            Description = description;
            Category = category;
            Owner = owner;
            Created = DateTime.Now;
            DueDate = dueDate;
            Status = false;
        }

        public Todo(Guid id, string description, string category, Person owner, DateTime created, DateTime dueDate, bool status)
        {
            Id = id;
            Description = description;
            Category = category;
            Owner = owner;
            Created = created;
            DueDate = dueDate;
            Status = status;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Descrição: {Description} | Categoria: {Category} | Proprietario: {Owner.Name} | Data de criação: {Created} | Data de término: {DueDate} | Completa: {Status}";
        }

        public string ToFile()
        {
            return $"{Id};{Description};{Category};{Owner.Name};{Owner.Id};{Created};{DueDate};{Status};";
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
