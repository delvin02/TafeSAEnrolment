using System;
using System.Diagnostics;
using System.Reflection;
using NUnit.Framework;
using TafeSAEnrolment;
using TafeSAEnrolment.BinaryTree;
using NUnit;
using System.Collections.Generic;


namespace TafeSAEnrolment.Test
{
    [TestFixture]
    public class BinaryTreeTest
    {
        List<Student> students;
        BinaryTree<Student> studentTree;
        [SetUp]
        public void SetUp()
        {
            students = GetSampleStudents();
            studentTree = new BinaryTree<Student>();
            foreach (Student student in students)
            {
                studentTree.Add(student);
            }
        }
       
        [Test]
        public void BinaryTree_AddAndFind_ShouldReturnTrue()
        {
            // Assert
            Assert.IsNotNull(studentTree.Find(new Student(4, "Don", "don@example.com", "888-666-852", "Business", DateTime.Now)));
            Assert.IsNull(studentTree.Find(new Student(11, "Elizabeth", "eliza@example.com", "65132-231-222", "Finance", DateTime.Now)));
        }

        [Test]
        public void BinaryTree_TraverseInOrder_DoesNotThrow()
        {

            // Assert
            Assert.DoesNotThrow(() => studentTree.TraverseInOrder(studentTree.Root));
        }

        [Test]
        public void BinaryTree_RemoveAndFind_ShouldReturnNull()
        {
            // Arrange (Assuming studentTree is set up with students)
            Student studentToRemove = new Student(4, "Don", "don@example.com", "888-666-852", "Business", DateTime.Now);

            // Act
            studentTree.Remove(studentToRemove);
            TreeNode<Student> removedNode = studentTree.Find(studentToRemove);

            // Assert
            Assert.IsNull(removedNode);
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
                new Student(5, "Eason", "eason@example.com", "123-423-123", "Mareting", DateTime.Now),
                new Student(7, "Gret", "gre@example.com", "65132-231-222", "Finance", DateTime.Now)
            };
        }
    }
}