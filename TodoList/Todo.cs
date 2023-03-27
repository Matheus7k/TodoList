using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Todo
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Person Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }

        public string StatusToPrint = "Incompleto";

        public Todo(string description, string category, Person owner, DateTime dueDate)
        {
            var temp = Guid.NewGuid();
            Id = temp.ToString().Substring(0, 8);
            Description = description;
            Category = category;
            Owner = owner;
            Created = DateTime.Now;
            DueDate = dueDate;
            Status = false;
        }

        public Todo(string id, string description, string category, Person owner, DateTime created, DateTime dueDate, bool status)
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
            return $"Id: {Id} | Descrição: {Description} | Categoria: {Category} | Proprietario: {Owner.Name} | Data de criação: {Created} | Data de término: {DueDate} | Status: {StatusToPrint}";
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
                StatusToPrint = "Incompleto";
            }
            else
            {
                Status = true;
                StatusToPrint = "Completo";
            }
        }

        public void SetPerson(Person owner)
        {
            Owner = owner;
        }
    }
}
