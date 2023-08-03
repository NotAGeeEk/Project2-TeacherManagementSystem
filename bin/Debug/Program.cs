using ConsoleAppTeacherManagementSystem;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        TeacherFileManager teacherFileManager = new TeacherFileManager("teachersdata.txt");

        List<Teacher> teachers = teacherFileManager.ReadteachersData();

        Console.WriteLine("Teacher Data:");
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
        }

        // Example of updating teacher data
        Console.WriteLine("\nEnter the ID of the teacher you want to update:");
        int idToUpdate = int.Parse(Console.ReadLine());

        Teacher teacherToUpdate = teachers.Find(t => t.ID == idToUpdate);
        if (teacherToUpdate != null)
        {
            Console.WriteLine("Enter the new name:");
            teacherToUpdate.Name = Console.ReadLine();

            Console.WriteLine("Enter the new class:");
            teacherToUpdate.Class = Console.ReadLine();

            Console.WriteLine("Enter the new section:");
            teacherToUpdate.Section = Console.ReadLine();

            Console.WriteLine("Teacher data updated successfully!");
        }
        else
        {
            Console.WriteLine("Teacher with the given ID not found.");
        }

        // Save the updated data back to the text file
        teacherFileManager.SaveTeachersData(teachers);

        Console.ReadKey();
    }
}