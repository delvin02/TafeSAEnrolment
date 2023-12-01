using System;
using System.Collections.Generic;
using NUnit.Framework;
using TafeSAEnrolment;
using TafeSAEnrolment.LinkedList;

namespace TafeSAEnrolment.Test
{
    [TestFixture]
    public class LinkedListTest
    {
        List<Student> students;

        [SetUp]
        public void SetUp()
        {
            students = GetSampleStudents();
        }
        
        // a
        [Test]
        public void LinkedList_AddToHead_EnumerateToCheck()
        {
            // Arrange
            TafeSAEnrolment.LinkedList.LinkedList<Student> linkedList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();
            foreach (Student student in students)
            {
                linkedList.Add(student);
            }

            Student studentToAdd = new Student(8, "John", "john@example.com", "999-888-7777", "Physics", DateTime.Now);

            // Act
            linkedList.AddFirst(studentToAdd);


            // Assert
            Assert.AreEqual(studentToAdd, linkedList.Head.Value, "Head should point to the added student");
        }

        // b
        [Test]
        public void LinkedList_AddToTail_EnumerateToCheck()
        {
            // Arrange
            TafeSAEnrolment.LinkedList.LinkedList<Student> linkedList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();
            foreach (Student student in students)
            {
                linkedList.Add(student);
            }

            Student studentToAdd = new Student(8, "John", "john@example.com", "999-888-7777", "Physics", DateTime.Now);

            // Act
            linkedList.AddLast(studentToAdd);

            // Assert
            Assert.AreEqual(studentToAdd, linkedList.Tail.Value, "Tail should point to the added student");
        }

        // c
        [Test]
        public void LinkedList_FindStudentInList_ShouldReturnTrue()
        {
            TafeSAEnrolment.LinkedList.LinkedList<Student> linkedList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();
            foreach (Student student in students)
            {
                linkedList.Add(student);
            }

            // Arrange
            TafeSAEnrolment.LinkedList.LinkedList<Student> studentList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();
            Student studentToFind = new Student(4, "Don", "don@example.com", "888-666-852", "Business", DateTime.Now);
            studentList.AddLast(studentToFind);

            // Act
            bool found = studentList.Contains(studentToFind);

            // Assert
            Assert.IsTrue(found);
        }

        // d
        [Test]
        public void LinkedList_RemoveFromHead_ShouldWork()
        {
            // Arrange
            TafeSAEnrolment.LinkedList.LinkedList<Student> linkedList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();
            foreach (Student student in students)
            {
                linkedList.Add(student);
            }

            // Get the student to be removed
            Student studentToRemove = linkedList.Head.Value;

            // Act
            linkedList.RemoveFirst();

            bool exist = linkedList.Contains(studentToRemove);

            // Assert
            Assert.IsFalse(exist, "The removed student should not be found in the linked list");
        }

        // e
        [Test]
        public void LinkedList_RemoveFromTail_ShouldWork()
        {
            // Arrange
            TafeSAEnrolment.LinkedList.LinkedList<Student> linkedList = new TafeSAEnrolment.LinkedList.LinkedList<Student>();
            foreach (Student student in students)
            {
                linkedList.Add(student);
            }

            // Get the student to be removed
            Student studentToRemove = linkedList.Tail.Value;

            // Act
            linkedList.RemoveLast();

            // Check
            bool exist = linkedList.Contains(studentToRemove);

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
