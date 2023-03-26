using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TodoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Todo> tasks = new();
        List<Category> categories = new();
        List<Person> persons = new();

        AddOnFile(tasks);

        Console.WriteLine("Hello, World!");
    }

    private static void AddOnFile([Optional] List<Todo> tasks, [Optional] List<Category>? categories, [Optional] List<Person>? persons)
    {

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
                    DateTime created = Convert.ToDateTime(task[2]);
                    DateTime dueDate = Convert.ToDateTime(task[3]);
                    bool status = bool.Parse(task[4]);

                    tasks.Add(new Todo(id, description, created, dueDate, status));
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
}