using System;
using System.Collections.Generic;
using NUnit.Framework;
using TafeSAEnrolment;
using TafeSAEnrolment.DoublyLinkedList;

namespace TafeSAEnrolment.Test
{
    [TestFixture]
    public class DoublyLinkedListTest
    {
        List<Student> students;
        [SetUp]
        public void SetUp()
        {
            students = GetSampleStudents();
        }

        [Test]
        public void DoubleLinkedList_AddFirst_EnumerateToCheck()
        {
            // Arrange
            DoubleLinkedList<Student> doubleLinkedList = new DoubleLinkedList<Student>();
            foreach (Student student in students)
            {
                doubleLinkedList.Add(student);
            }

            Student studentToAdd = new Student(8, "John", "john@example.com", "999-888-7777", "Physics", DateTime.Now);

            // Act
            doubleLinkedList.AddFirst(studentToAdd);

            // Assert
            Assert.AreEqual(studentToAdd, doubleLinkedList.Head.Value, "Head should point to the added student");
            Assert.AreEqual(studentToAdd, doubleLinkedList.Head.Next.Previous.Value, "Previous of the next node should also point to the added student");
        }

        //b
        [Test]
        public void DoublyLinkedList_AddToTail_EnumerateToCheck()
        {
            // Arrange
            DoubleLinkedList<Student> doubleLinkedList = new DoubleLinkedList<Student>();
            foreach (Student student in students)
            {
                doubleLinkedList.Add(student);
            }

            Student studentToAdd = new Student(8, "John", "john@example.com", "999-888-7777", "Physics", DateTime.Now);

            // Act
            doubleLinkedList.AddLast(studentToAdd);

            // Assert
            Assert.AreEqual(studentToAdd, doubleLinkedList.Tail.Value, "Tail should point to the added student");
        }

        // c. LinkedList_FindStudentInList_ShouldReturnTrue
        [Test]
        public void DoublyLinkedList_FindStudentInList_ShouldReturnTrue()
        {
            // Arrange
            DoubleLinkedList<Student> doubleLinkedList = new DoubleLinkedList<Student>();
            foreach (Student student in students)
            {
                doubleLinkedList.Add(student);
            }

            // Create a student list to search for a student
            DoubleLinkedList<Student> studentList = new DoubleLinkedList<Student>();
            Student studentToFind = new Student(4, "Don", "don@example.com", "888-666-852", "Business", DateTime.Now);
            studentList.AddLast(studentToFind);

            // Act
            bool found = doubleLinkedList.Contains(studentToFind);

            // Assert
            Assert.IsTrue(found);
        }

        // d. LinkedList_RemoveFromHead_ShouldWork
        [Test]
        public void DoublyLinkedList_RemoveFromHead_ShouldWork()
        {
            // Arrange
            DoubleLinkedList<Student> doubleLinkedList = new DoubleLinkedList<Student>();
            foreach (Student student in students)
            {
                doubleLinkedList.Add(student);
            }

            // Get the student to be removed (head)
            Student studentToRemove = doubleLinkedList.Head.Value;

            // Act
            doubleLinkedList.RemoveFirst(studentToRemove);

            bool exist = doubleLinkedList.Contains(studentToRemove);

            // Assert
            Assert.IsFalse(exist, "The removed student should not be found in the linked list");
        }

        // e. LinkedList_RemoveFromTail_ShouldWork
        [Test]
        public void DoublyLinkedList_RemoveFromTail_ShouldWork()
        {
            // Arrange
            DoubleLinkedList<Student> doubleLinkedList = new DoubleLinkedList<Student>();
            foreach (Student student in students)
            {
                doubleLinkedList.Add(student);
            }

            // Get the student to be removed (tail)
            Student studentToRemove = doubleLinkedList.Tail.Value;

            // Act
            doubleLinkedList.RemoveLast();

            // Check
            bool exist = doubleLinkedList.Contains(studentToRemove);

            // Assert
            Assert.IsFalse(exist, "The removed student should not be found in the linked list");
        }


        private List<Student> GetSampleStudents()
        {
            return new List<Student>()
            {
                new Student(4, "Don", "don@example.com", "888-666-852", "Business", DateTime.Now),
                new Student(2, "Bob", "bob@example.com", "987-654-3210", "Engineering", DateTime.Now),
                new Student(6, "Falcon", "falcon@example.com", "555-555-5555", "Business", DateTime.Now),
                new Student(1, "Alice", "alice@example.com", "123-456-7890", "Computer Science", DateTime.Now),
                new Student(3, "Carson", "carson@example.com", "555-555-5555", "Business", DateTime.Now),
                new Student(5, "Eason", "eason@example.com", "123-423-123", "Marketing", DateTime.Now),
                new Student(7, "Gret", "gre@example.com", "65132-231-222", "Finance", DateTime.Now)
            };
        }
    }
}
