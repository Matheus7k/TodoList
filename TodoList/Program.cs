using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TodoList;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Todo> tasks = new();
        List<Category> categories = new();
        List<Person> persons = new();

        tasks = LoadTasks(tasks);
        categories = LoadCategories(categories);
        persons = LoadPersons(persons);

        int op;

        do
        {
            op = Menu();
            switch (op)
            {
                case 1:
                    Console.WriteLine("-----CADASTRAR PESSOA-----");
                    persons.Add(CreatePerson());
                    AddOnPersonFile(persons);
                    break;
                case 2:
                    Console.Write("-----CADASTRAR CATEGORIA-----");
                    categories.Add(CreateGategory());
                    AddOnCategoryFile(categories);
                    break;
                case 3:
                    Console.Write("-----CADASTRAR TAREFA-----");
                    tasks.Add(CreateTodo(persons, categories));
                    AddOnTasksFile(tasks);
                    break;
                case 4:
                    Console.Clear();
                    ShowTask(tasks);
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    ShowCompletedTask(tasks);
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Informe o ID da tarefa: ");
                    string id = Console.ReadLine();
                    EndTask(tasks, id);
                    break;
                case 7:
                    AddOnPersonFile(List < Person > persons);
                    AddOnCategoryFile(List < Category > categories);
                    AddOnTasksFile(List < Todo > tasks);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Escolha uma opção valida!");
                    break;
            }
        } while (op != 7);
    }

    private static int Menu()
    {
        Console.WriteLine($"----Todo List----" +
                             $"\n1 - Adicionar pessoa" +
                             $"\n2 - Adicionar categoria" +
                             $"\n3 - Adicionar tarefa" +
                             $"\n4 - Listar tarefas" +
                             $"\n5 - Listar tarefas finalizadas" +
                             $"\n6 - Finalizar uma tarefa" +
                             $"\n7 - Sair e salvar" +
                             "\n-----------------------");
        return int.Parse(Console.ReadLine());
    }

    private static Person CreatePerson()
    {
        Console.Write("\nInforme o nome da pessoa: ");
        string name = Console.ReadLine();

        return new Person(name);
    }

    private static Category CreateGategory()
    {
        Console.Write("\nInforme a nova categoria: ");
        string category = Console.ReadLine();

        return new Category(category);
    }

    private static Todo CreateTodo(List<Person> persons, List<Category> categories)
    {
        Console.WriteLine("Essa tarefa pertence a quem?");
        Person personToTask = ListPersons(persons);

        Console.Write("Descrição da tarefa: ");
        string description = Console.ReadLine();

        Console.WriteLine("Data do possivel término(dia/mes/ano hora/minuto): ");
        DateTime duaDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Essa tarefa é de qual categoria?");
        Category categoryToTask = ListCategories(categories);

        return new Todo(description, categoryToTask.CategoryName, personToTask, duaDate);
    }

    private static Person ListPersons(List<Person> persons)
    {
        Console.WriteLine("Pessoas cadastradas: ");
        for (int i = 0; i < persons.Count; i++)
        {
            Console.WriteLine($"{i+1} - {persons[i].Name}");
        }
        int personOp = int.Parse(Console.ReadLine());

        return persons[personOp - 1];
    }

    private static Category ListCategories(List<Category> categories)
    {
        Console.WriteLine("Categorias cadastradas: ");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {categories[i].CategoryName}");
        }
        int categoryOp = int.Parse(Console.ReadLine());

        return categories[categoryOp - 1];
    }

    private static void AddOnPersonFile(List<Person> persons)
    {
        try
        {
            if (File.Exists("persons.txt"))
            {
                StreamWriter sw = new("persons.txt");

                foreach (var person in persons)
                {
                    sw.WriteLine(person.ToFile());
                }

                sw.Close();
            }
            else
            {
                StreamWriter sw = new("persons.txt");
                sw.WriteLine();
                sw.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private static void AddOnCategoryFile(List<Category> categories)
    {
        try
        {
            if (File.Exists("categories.txt"))
            {
                StreamWriter sw = new("categories.txt");

                foreach (var category in categories)
                {
                    sw.WriteLine(category.ToFile());
                }

                sw.Close();
            }
            else
            {
                StreamWriter sw = new("categories.txt");
                sw.WriteLine();
                sw.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private static void AddOnTasksFile(List<Todo> tasks)
    {
        try
        {
            if (File.Exists("tasks.txt"))
            {
                StreamWriter sw = new("tasks.txt");

                foreach (var task in tasks)
                {
                    sw.WriteLine(task.ToFile());
                }

                sw.Close();
            }
            else
            {
                StreamWriter sw = new("tasks.txt");
                sw.WriteLine();
                sw.Close();
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private static List<Todo> LoadTasks(List<Todo> tasks)
    {
        try
        {
            if (File.Exists("tasks.txt"))
            {
                StreamReader sr = new("tasks.txt");

                while(!sr.EndOfStream)
                {
                    string[] task = sr.ReadToEnd().Split(';');

                    Guid id = Guid.Parse(task[0]);
                    string description = task[1];
                    string category = task[2];
                    string ownerName = task[3];
                    Guid ownerId = Guid.Parse(task[4]);
                    DateTime created = Convert.ToDateTime(task[5]);
                    DateTime dueDate = Convert.ToDateTime(task[6]);
                    bool status = bool.Parse(task[7]);

                    tasks.Add(new Todo(id, description, category, new Person(ownerId, ownerName), created, dueDate, status));
                }

                sr.Close();

                return tasks;
            }
            else
            {
                StreamWriter sw = new("tasks.txt");
                sw.WriteLine();
                sw.Close();

                return tasks;
            }
        }catch (Exception ex)
        {
            throw;
        }
    }

    private static List<Category> LoadCategories(List<Category> categories)
    {
        try
        {
            if (File.Exists("categories.txt"))
            {
                StreamReader sr = new("categories.txt");

                while (!sr.EndOfStream)
                {
                    string[] category = sr.ReadToEnd().Split(';');

                    string categotyName = category[0];

                    categories.Add(new Category(categotyName));
                }
                sr.Close();

                return categories;
            }
            else
            {
                StreamWriter sw = new("categories.txt");
                sw.WriteLine();
                sw.Close();

                return categories;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private static List<Person> LoadPersons(List<Person> persons)
    {
        try
        {
            if (File.Exists("persons.txt"))
            {
                StreamReader sr = new("persons.txt");

                while (!sr.EndOfStream)
                {
                    string[] person = sr.ReadToEnd().Split(';');

                    Guid id = Guid.Parse(person[0]);
                    string personName = person[1];

                    persons.Add(new Person(id, personName));
                }

                sr.Close();

                return persons;
            }
            else
            {
                StreamWriter sw = new("persons.txt");
                sw.WriteLine();
                sw.Close();

                return persons;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private static void EndTask(List<Todo> tasks, string id)
    {
        foreach (ToDo tarefa in afazeres)
        {
            if (tarefa._id == id)
            {
                tarefa.Status = false;
            }
        }
    }

    private static void ShowTask(List<Todo> tasks)
    {
        foreach (ToDo tarefa in afazeres)
        {
            if (tarefa.Status == true)
            {
                Console.WriteLine(tarefa.ToString());
            }

        }
    }

    private static void ShowCompletedTask(List<Todo> tasks)
    {
        foreach (ToDo tarefa in afazeres)
        {
            if (tarefa.Status == false)
            {
                Console.WriteLine(tarefa.ToString());
            }
        }
    }
}