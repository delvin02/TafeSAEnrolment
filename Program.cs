using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeSAEnrolment.BinaryTree;
using TafeSAEnrolment.LinkedList;
using System.Text;
using TafeSAEnrolment.DoublyLinkedList;

namespace TafeSAEnrolment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>
            {
                new Student(4, "Don", "don@example.com", "888-666-852", "Business", DateTime.Now),
                new Student(2, "Bob", "bob@example.com", "987-654-3210", "Engineering", DateTime.Now),
                new Student(6, "Falcon", "falcon@example.com", "555-555-5555", "Business", DateTime.Now),
                new Student(1, "Alice", "alice@example.com", "123-456-7890", "Computer Science", DateTime.Now),
                new Student(3, "Carson", "carson@example.com", "555-555-5555", "Business", DateTime.Now),
                new Student(5, "Eason", "eason@example.com", "123-423-123", "Mareting", DateTime.Now),
                new Student(7, "Gret", "gre@example.com", "65132-231-222", "Finance", DateTime.Now)
            };
            // =============================================
            // Merge Sort testing
            // =============================================
            Console.WriteLine("Merge Sort Ascending:");
            Utility.MergeSortAscending(students);
            PrintStudents(students);

            Console.WriteLine("\nMerge Sort Descending:");
            Utility.MergeSortDescending(students);
            PrintStudents(students);

            // ============================================= Quick Sort testing ====================================================
            Console.WriteLine("\nQuick Sort Ascending:");
            Utility.QuickSortAscending(students);
            PrintStudents(students);

            Console.WriteLine("\nQuick Sort Descending:");
            Utility.QuickSortDescending(students);
            PrintStudents(students);

            // =============================================
            // Linear Search
            // =============================================
            Student searchStudent = new Student(3, "Bob Johnson", "bob@example.com", "555-555-5555", "Business", DateTime.Now);
            int linearSearchIndex = Utility.LinearSearch(students, searchStudent);
            Console.WriteLine($"\nLinear Search Result: Student found at index {linearSearchIndex}");

            // =============================================
            // Binary Search
            // =============================================
            Console.WriteLine("\nBinary Search Result:");
            Utility.QuickSortAscending(students);
            int binarySearchIndex = Utility.BinarySearch(students, searchStudent);
            if (binarySearchIndex != -1)
            {
                Console.WriteLine($"Student found at index {binarySearchIndex}");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

            // =============================================
            // Doubly Linked List
            // =============================================
            Console.WriteLine("\nDoubly Linked List:");
            DoubleLinkedList<Student> doubleLinkedList = new DoubleLinkedList<Student>();
            foreach (Student student in students)
            {
                doubleLinkedList.Add(student);
            }
            // Print Doubly Linked List
            foreach (var node in doubleLinkedList)
            {
                Console.WriteLine($"Student ID: {node.StudentId}");
            }

            // =============================================
            // LinkedList
            // =============================================
            Console.WriteLine("\nLinked List After Removal:");
            var linkedList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();
            foreach (var student in students)
            {
                linkedList.AddLast(student);
            }
            linkedList.RemoveFirst();
            PrintStudents(linkedList);

            // =============================================
            // Binary Tree
            // =============================================
            Console.WriteLine("\nBinary Tree In-Order Traversal:");
            TestBinaryTree(students);
            Console.ReadKey();
        }

        static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}, Program: {student.Program}");
            }
        }

        static void PrintStudents(TafeSAEnrolment.LinkedList.LinkedList<Student> linkedList)
        {
            foreach (var student in linkedList)
            {
                Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.Name}, Program: {student.Program}");
            }
        }
        static void TestBinaryTree(List<Student> students)
        {

            BinaryTree<Student> studentTree = new BinaryTree<Student>();

            foreach (Student student in students)
            {
                studentTree.Add(student);
            }



            Console.WriteLine("Traverse In-Order:");
            studentTree.TraverseInOrder(studentTree.Root);

            Console.WriteLine("\nTraverse Pre-Order:");
            studentTree.TraversePreOrder(studentTree.Root);

            Console.WriteLine("\nTraverse Post-Order:");
            studentTree.TraversePostOrder(studentTree.Root);


        }
    }
}
