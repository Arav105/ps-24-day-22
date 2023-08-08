using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ps_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee()
            {
                Id = 10,
                FirstName = "Arav",
                LastName = "S",
                Salary = 50000
            };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("C:\\Users\\Admin\\source\\repos\\ps-24 day-22\\Employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs,employee);
                Console.WriteLine("Created and Serialized");
                Console.WriteLine(employee.Id);
                Console.WriteLine(employee.FirstName);
                Console.WriteLine(employee.LastName);
                Console.WriteLine(employee.Salary);

            }
            using (FileStream fs = new FileStream("C:\\Users\\Admin\\source\\repos\\ps-24 day-22\\Employee.bin", FileMode.Open))
            {
                employee = (Employee)formatter.Deserialize(fs);
                Console.WriteLine("De-Serialized");
                Console.WriteLine(employee.Id);
                Console.WriteLine(employee.FirstName);
                Console.WriteLine(employee.LastName);
                Console.WriteLine(employee.Salary);

            }
            //XML serialization and deserialization

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter textWriter = new StreamWriter("C:\\Users\\Admin\\source\\repos\\ps-24 day-22\\employee.Xml"))
            {
                serializer.Serialize(textWriter, employee);

            }
            Console.WriteLine("XML Serialization completed!!!!!\n\n");

            using (TextReader textReader = new StreamReader("C:\\Users\\Admin\\source\\repos\\ps-24 day-22\\employee.Xml"))
            {
                Employee emp = (Employee)serializer.Deserialize(textReader);
                Console.WriteLine("***Deserialized Data in (XML)****");
                Console.WriteLine("Employee ID:" + emp.Id);
                Console.WriteLine("Employee First Name:" + emp.FirstName);
                Console.WriteLine("Employee Last Name:" + emp.LastName);
                Console.WriteLine("Employee Salary:" + emp.Salary);
            }
            Console.ReadKey();
        }
    }
}
