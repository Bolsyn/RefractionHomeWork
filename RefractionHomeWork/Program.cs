using System;
using System.Collections.Generic;
using System.Reflection;

namespace RefractionHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write path to file: ");
            string pathToFile = Console.ReadLine();

            Assembly scriptLibrary = Assembly.LoadFile(pathToFile);
            foreach (Type type in scriptLibrary.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract)
                {
                    Console.WriteLine($"create table {type.Name}");
                    foreach (var property in type.GetProperties())
                    {
                        if (property.Name == "Id")
                            Console.WriteLine($"({property.Name} int primary key identity not null ) ");
                        else if (property.PropertyType.ToString() is "System.Double")
                            Console.WriteLine($"({property.Name} float not null ) ");
                        else if (property.PropertyType.ToString() is "System.String")
                            Console.WriteLine($"({property.Name} nvarchar(max) not null ) ");
                        else if (property.PropertyType.ToString() is "System.Int32")
                            Console.WriteLine($"({property.Name} int not null ) ");
                    }
                }
            }
        }


    }
}
