using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeSAEnrolment.BinaryTree;
using TafeSAEnrolment.LinkedList;

namespace TafeSAEnrolment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>
            {
                new Student(4, "Encu", "e@example.com", "888-666-852", "Business", DateTime.Now),
                new Student(3, "Alice Smith", "alice@example.com", "987-654-3210", "Engineering", DateTime.Now),
                new Student(5, "Chalice", "c@example.com", "555-555-5555", "Business", DateTime.Now),
                new Student(1, "John Doe", "john@example.com", "123-456-7890", "Computer Science", DateTime.Now),
                new Student(2, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now),
                new Student(6, "Vin", "cryayon@example.com", "123-423-123", "Mareting", DateTime.Now),
                new Student(7, "Qujmn", "qujm@example.com", "65132-231-222", "Finance", DateTime.Now)
            };
            // =============================================
            // Merge Sort testing
            // =============================================

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

            //Student searchStudent = new Student(3, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now);

            //Utility.QuickSortAscending(students);

            //int index = Utility.BinarySearch(students, searchStudent);

            //if (index != -1)
            //{
            //    Console.WriteLine("Student found at index:" + index);
            //}
            //else
            //{
            //    Console.WriteLine("Student not found!");
            //}

            // =============================================
            // Double Linked List
            // =============================================

            //DoublyLinkedList.DoubleLinkedList<Student> studentList = new DoublyLinkedList.DoubleLinkedList<Student>();
            //foreach (Student student in students)
            //{
            //    studentList.Append(student);
            //}

            //Student studentToFind = new Student(1, null, null, null, null, default);
            //DoublyLinkedList.DoublyLinkedListNode<Student> foundNode = studentList.Find(studentToFind);

            //if (foundNode != null)
            //{
            //    Student foundStudent = foundNode.Value;
            //    Console.WriteLine("Found student: " + foundStudent.Name);
            //}
            //else
            //{
            //    Console.WriteLine("Student not found.");
            //}

            // =============================================
            // Linked List
            // =============================================

            //var linkedList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();

            //// Add students to the LinkedList
            //foreach (var student in students)
            //{
            //    linkedList.AddLast(student);
            //}
            //linkedList.RemoveFirst();
            //linkedList.RemoveLast();

            //// Display LinkedList after removal
            //Console.WriteLine("\nAfter removal:");
            //foreach (var student in linkedList)
            //{
            //    Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}, Program: {student.Program}");
            //}

            // =============================================
            // Binary Tree
            // =============================================

            BinaryTree<Student> studentTree = new BinaryTree<Student>();

            foreach (Student student in students)
            {
                studentTree.Add(student);
            }

            // studentTree.Remove(students[4]);


            //   3
            // /  \
            //1     6
            // \   / \
            //  2  5  7
            //    /
            //   4
            Console.WriteLine("Traverse In-Order:");
            studentTree.TraverseInOrder(studentTree.Root);

            Console.WriteLine("\nTraverse Pre-Order:");
            studentTree.TraversePreOrder(studentTree.Root);

            Console.WriteLine("\nTraverse Post-Order:");
            studentTree.TraversePostOrder(studentTree.Root);
        }
    }
}
