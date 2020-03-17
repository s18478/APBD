using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Classes2
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToFile();
        }

        static void SaveToFile()
        {
            Console.Write("Enter the csv file path: ");
            string csvPath = Console.ReadLine();
            Console.Write("Enter the result file path: ");
            string xmlPath = Console.ReadLine();
            Console.Write("Enter the type (xml or json): ");
            string format = Console.ReadLine();

            if (File.Exists(csvPath) && Directory.Exists(xmlPath))
            {
                var list = new List<Student>();
                
                var fileInfo = new FileInfo(csvPath);
                using (var stream = new StreamReader(fileInfo.OpenRead()))
                {
                    string line = null;

                    while ((line = stream.ReadLine()) != null)
                    {
                        if (line.Contains(",,"))
                            ErrorLogging("One from the column is null");
                        else if (line.Split(",").Length != 9)
                            ErrorLogging("Missing column");
                        else
                        {
                            string[] data = line.Split(",");
                            var student = new Student()
                            {
                                Id = data[4],
                                FirstName = data[0],
                                LastName = data[1],
                                Birthdate = data[5],
                                Email = data[6],
                                MothersName = data[7],
                                FathersName = data[8],
                                StudiesName = data[2],
                                Mode = data[3]
                            };
                            
                            // Add if student is not in the list 
                            if (!list.Contains(student))
                                list.Add(student);
                        }
                    }
                    stream.Dispose();
                }
                
                // Checking active studies
                var map = new Dictionary<string, int>();
                
                foreach (Student st in list)
                {
                    string studiesName = st.StudiesName;
                    
                    if (map.ContainsKey(studiesName))
                    {
                        int count;
                        map.TryGetValue(st.StudiesName, out count);
                        map.Remove(studiesName);
                        map.Add(studiesName, ++count);
                    }
                    else
                    {
                        map.Add(studiesName, 1);
                    }
                }
            
                // Generate and save xml file
                XElement xml = new XElement("uczelnia", 
                    new XAttribute("createdAt", DateTime.Now.ToShortDateString()),    
                    new XAttribute("author", "Jan Kowalski"),
                    new XElement("studenci", 
                        from st in list
                        select new XElement("student", 
                            new XAttribute("indexNumber", "s" + st.Id),
                            new XElement("fname", st.FirstName),
                            new XElement("lname", st.LastName),
                            new XElement("birthdate", st.Birthdate),
                            new XElement("email", st.Email),
                            new XElement("mothersName", st.MothersName),
                            new XElement("fathersName", st.FathersName),
                            new XElement("studies",
                                new XElement("name", st.StudiesName),
                                new XElement("mode", st.Mode))
                        )
                    ), 
                    new XElement("activeStudies",
                        from pair in map
                        select new XElement("studies",
                            new XAttribute("name", pair.Key), 
                            new XAttribute("numberOfStudents", pair.Value))
                        )
                    );
                
                xml.Save(String.Concat(xmlPath, "result.xml"));
            }
            else
            {
                if (!File.Exists(csvPath))
                {
                    ErrorLogging("File does not exists");
                    throw new FileNotFoundException("File does not exists !");
                }

                if (!Directory.Exists(xmlPath))
                {
                    ErrorLogging("Directory does not exists");
                    throw new ArgumentException("Directory does not exists !");
                }
            }
        }

        public static void ErrorLogging(string message)
        {
            string logPath = @"C:\Users\log.txt";

            if (!File.Exists(logPath))
            {
                File.Create(logPath).Dispose();
            }

            StreamWriter sw = File.AppendText(logPath);
            
            sw.WriteLine("\nLogging error");
            sw.WriteLine("Start: " + DateTime.Now);
            sw.WriteLine(message);
            sw.WriteLine("End: " + DateTime.Now);
            sw.Close();
        }
    }
}