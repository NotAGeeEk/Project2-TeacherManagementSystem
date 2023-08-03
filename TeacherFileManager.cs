using ConsoleAppTeacherManagementSystem;
using System;
using System.Collections.Generic;
using System.IO;

public class TeacherFileManager
{
    private string filename;

    public TeacherFileManager(string filename)
    {
        this.filename = filename;
    }

    public List<Teacher> ReadteachersData()
    {
        List<Teacher> teachers = new List<Teacher>();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            bool firstLine = true;

            foreach (string line in lines)
            {
                if (firstLine)
                {
                    firstLine = false;
                    continue; // Skip the header line
                }

                string[] data = line.Split(',');
                if (data.Length == 4)
                {
                    Teacher teacher = new Teacher
                    {
                        ID = int.Parse(data[0]),
                        Name = data[1],
                        Class = data[2],
                        Section = data[3]
                    };
                    teachers.Add(teacher);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
        }

        return teachers;
    }

    public void SaveTeachersData(List<Teacher> teachers)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("ID,Name,Class,Section");

                foreach (var teacher in teachers)
                {
                    writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.Class},{teacher.Section}");
                }
            }

            Console.WriteLine("Teacher data saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving the data to file: " + ex.Message);
        }
    }
}