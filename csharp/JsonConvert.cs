using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Algorithms;

/// <summary>
/// Convert an Object to Json
/// </summary>
public class JsonConvert
{
    public static void run()
    {
        Student student = new Student("John", 20, "A", new List<Professor>() { 
            new Professor("Dr. Smith", "Math"),
            new Professor("Dr. Johnson", "Science")
        });
        string json = SerializeWithJson(student);
        Console.WriteLine("Serialized with System.Text.Json: " + json + "\n\n");

        string json2 = SerializeManually(student);
        Console.WriteLine("Serialized with Manuall Method: " + json + "\n\n");

        string json3 = JsonSerializer.Serialize(student);
        Console.WriteLine("Serialized with Manuall Method: " + json + "\n\n");
    }

    public static string SerializeWithJson(Student student)
    {
        return JsonSerializer.Serialize(student);
    }

    public static string SerializeManually(Student student)
    {
        StringBuilder json = new StringBuilder();
        json.Append("{");

        json.Append($"\"Name\": \"{student.Name}\",");
        json.Append($"\"Age\": {student.Age},");
        json.Append($"\"Grade\": \"{student.Grade}\",");

        json.Append("\"Professors\": [");
        for (int i = 0; i < student.professors.Count; i++)
        {
            json.Append("{");
            json.Append($"\"Name\": \"{student.professors[i].Name}\",");
            json.Append($"\"Department\": \"{student.professors[i].Department}\"");
            json.Append("}");

            //add comma if is the last one
            if (i < student.professors.Count - 1)
            {
                json.Append(",");
            }
        }

        json.Append("]");
        json.Append("}");

        return json.ToString();
    }

    //public static string SerializeWithNewtonsoft(Student student)
    //{
    //    //return Newtonsoft.Json.JsonConvert.SerializeObject(student);
    //}


    public static string SerializeWithReflextion(object obj)
    {
        if (obj == null)
            return "null";

        Type type = obj.GetType();

        if (type == typeof(string))
            return $"\"{EscapeJson(obj.ToString())}\"";

        if (type.IsPrimitive || obj is decimal)
            return obj.ToString().ToLower(); // Handles int, float, bool, double, etc.

        if (obj is IEnumerable enumerable) // Handle Lists, Arrays
        {
            List<string> items = new List<string>();
            foreach (var item in enumerable)
            {
                items.Add(SerializeWithReflextion(item));
            }
            return "[" + string.Join(",", items) + "]";
        }

        // If it's a complex object (Class, Struct, etc.)
        List<string> properties = new List<string>();
        PropertyInfo[] props = type.GetProperties();

        foreach (PropertyInfo prop in props)
        {
            object value = prop.GetValue(obj);
            properties.Add($"\"{prop.Name}\":{SerializeWithReflextion(value)}");
        }

        return "{" + string.Join(",", properties) + "}";
    }

    private static string EscapeJson(string input)
    {
        return input.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
    public List<Professor> professors { get; set; }

    public Student(string name, int age, string grade, List<Professor> professors)
    {
        Name = name;
        Age = age;
        Grade = grade;
        this.professors = professors;
    }


   
}

public class Professor
{
    public string Name { get; set; }
    public string Department { get; set; }

    public Professor(string name, string department)
    {
        Name = name;
        Department = department;
    }
}

