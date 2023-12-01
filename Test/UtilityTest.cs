using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeSAEnrolment.Test
{
    [TestFixture]
    public class UtilityTest
    {
        List<Student> students;

        [SetUp]
        public void SetUp()
        {
            students = GetSampleStudents();
        }

        [Test]
        public void LinearSearchTest_ExistingElement()
        {
            // Arrange
            var targetStudent = students[3]; // Student with ID 4

            // Act
            int index = Utility.LinearSearch(students, targetStudent);

            // Assert
            Assert.AreEqual(3, index, "LinearSearch should return the correct index of an existing element");
        }

        [Test]
        public void LinearSearchTest_NonExistingElement()
        {
            // Arrange
            var targetStudent = new Student(100, "John", "john@example.com", "999-888-7777", "Physics", DateTime.Now);

            // Act
            int index = Utility.LinearSearch(students, targetStudent);

            // Assert
            Assert.AreEqual(-1, index, "LinearSearch should return -1 for a non-existing element");
        }

        // Binary Search Test
        [Test]
        public void BinarySearchTest_ExistingElement()
        {
            students.Sort();

            // Arrange
            var targetStudent = new Student(4, "Don", "don@example.com", "888-666-852", "Business", DateTime.Now);

            // Act
            int index = Utility.BinarySearch(students, targetStudent);

            // Assert
            Assert.AreEqual(3, index, "BinarySearch should return the correct index of an existing element");
        }

        [Test]
        public void BinarySearchTest_NonExistingElement()
        {
            students.Sort();

            // Arrange
            var targetStudent = new Student(100, "John", "john@example.com", "999-888-7777", "Physics", DateTime.Now);

            // Act
            int index = Utility.BinarySearch(students, targetStudent);

            // Assert
            Assert.AreEqual(-1, index, "BinarySearch should return -1 for a non-existing element");
        }

        [Test]
        public void BubbleSort_SortsStudentsByNameAscending()
        {

            // Act
            Utility.BubbleSortAscending(students);

            // Arrange
            var expectedSortedStudents = new List<Student>(students);
            expectedSortedStudents.Sort((x, y) => x.CompareTo(y));

            // Assert: Check if the array is sorted by name in ascending order
            for (int i = 0; i < expectedSortedStudents.Count - 1; i++)
            {
                Assert.IsTrue(string.Compare(expectedSortedStudents[i].Name, students[i].Name) <= 0);
            }
        }

        [Test]
        public void BubbleSort_SortsStudentsByNameDescending()
        {

            // Act
            Utility.BubbleSortDescending(students);

            // Arrange
            var expectedSortedStudents = new List<Student>(students);
            expectedSortedStudents.Sort((y, x) => x.CompareTo(y));

            // Assert
            Assert.AreEqual(expectedSortedStudents, students, "BubbleSort should sort students by name in ascending order");

        }

        // QuickSort Test
        [Test]
        public void QuicksortAscendingTest()
        {

            // Arrange
            var expectedSortedStudents = new List<Student>(students);
            expectedSortedStudents.Sort((x, y) => x.CompareTo(y));

            // Act
            Utility.QuickSortAscending(students);

            // Assert
            CollectionAssert.AreEqual(expectedSortedStudents, students, "QuickSortAscending should sort the list in ascending order");

        }

        [Test]
        public void QuicksortDescendingTest()
        {

            // Arrange
            var expectedSortedStudents = new List<Student>(students);
            expectedSortedStudents.Sort((y, x) => x.CompareTo(y));

            // Act
            Utility.QuickSortDescending(students);

            // Assert
            CollectionAssert.AreEqual(expectedSortedStudents, students, "QuickSortAscending should sort the list in ascending order");

        }

        // MergeSort Test
        [Test]
        public void MergeSortAscendingTest()
        {

            // Arrange
            var expectedSortedStudents = new List<Student>(students);
            expectedSortedStudents.Sort((x, y) => x.CompareTo(y));

            // Act
            Utility.MergeSortAscending(students);

            // Assert
            CollectionAssert.AreEqual(expectedSortedStudents, students, "QuickSortAscending should sort the list in ascending order");
        }

        // MergeSort Test
        [Test]
        public void MergeSortDescendingTest()
        {

            // Arrange
            var expectedSortedStudents = new List<Student>(students);
            expectedSortedStudents.Sort((y, x) => x.CompareTo(y));

            // Act
            Utility.MergeSortDescending(students);

            // Assert
            CollectionAssert.AreEqual(expectedSortedStudents, students, "QuickSortAscending should sort the list in ascending order");
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
                new Student(7, "Gret", "gre@example.com", "65132-231-222", "Finance", DateTime.Now),
                new Student(8, "Grace", "grace@example.com", "777-888-9999", "Art", DateTime.Now),
                new Student(9, "Sam", "sam@example.com", "555-123-4567", "History", DateTime.Now),
                new Student(10, "Linda", "linda@example.com", "111-222-3333", "Psychology", DateTime.Now)
            };
        }
    }
}
