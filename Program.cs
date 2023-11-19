using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>
            {
            new Student(3, "Alice Smith", "alice@example.com", "987-654-3210", "Engineering", DateTime.Now),
            new Student(1, "John Doe", "john@example.com", "123-456-7890", "Computer Science", DateTime.Now),
            new Student(2, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now),
            new Student(5, "Chalice", "c@example.com", "555-555-5555", "Business", DateTime.Now),
            new Student(4, "Encu", "e@example.com", "555-555-5555", "Business", DateTime.Now)
            };
            // ============================================= Merge Sort testing ====================================================

            //Utility.MergeSortAscending(students);



            //Console.ReadKey();

            //Utility.MergeSortDescending(students);


            // ============================================= Quick Sort testing ====================================================

            //Utility.QuickSortAscending(students);

            //Console.ReadKey(); 

            // Utility.QuickSortDescending(students);

            // Quicksort test

            //Student[] students = new Student[]
            //{
            //new Student(3, "Alice Smith", "alice@example.com", "987-654-3210", "Engineering", DateTime.Now),
            //new Student(1, "John Doe", "john@example.com", "123-456-7890", "Computer Science", DateTime.Now),
            //new Student(2, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now),
            //new Student(5, "Chalice", "c@example.com", "555-555-5555", "Business", DateTime.Now),
            //new Student(4, "Encu", "e@example.com", "555-555-5555", "Business", DateTime.Now)

            //};

            //// Apply QuickSort to the array
            //Utility.QuickSort(students);

            //// Print the sorted array
            //Console.WriteLine("Sorted students by StudentId:");
            //foreach (var student in students)
            //{
            //    Console.WriteLine($"StudentId: {student.StudentId}, Name: {student.Name}");
            //}


            //Student searchStudent = new Student(3, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now);

            //int index = Utility.LinearSearch(students, searchStudent);

            //if (index != -1)
            //{
            //    Console.WriteLine("Student found at index:" + index);
            //}
            //else
            //{
            //    Console.WriteLine("Student not found!");
            //}

            // Binary search Test
            //Student[] students = new Student[]
            //{
            //    new Student(3, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now),
            //    new Student(1, "John Doe", "john@example.com", "123-456-7890", "Computer Science", DateTime.Now),
            //    new Student(2, "Alice Smith", "alice@example.com", "987-654-3210", "Engineering", DateTime.Now)
            // };

            //Array.Sort(students);

            Student searchStudent = new Student(3, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now);

            Utility.QuickSortAscending(students);

            int index = Utility.BinarySearch(students, searchStudent);

            if (index != -1)
            {
                Console.WriteLine("Student found at index:" + index);
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

            //string[] words = new string[]
            //{
            //"apple", "banana", "cherry", "date", "fig", "grape"
            //};

            //Array.Sort(words);

            //string targetWord = "date";

            //int wordsFoundIndex = Utility.LinearSearch(words, targetWord);

            //// Output the result
            //if (wordsFoundIndex != -1)
            //{
            //    Console.WriteLine($"'{targetWord}' found at index: {wordsFoundIndex}");
            //}
            //else
            //{
            //    Console.WriteLine($"'{targetWord}' not found");
            //}




            Console.ReadKey();

            
        }
    }
}
