using Microsoft.Win32;
using System;

using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Text;

using System.Threading.Tasks;
using System.Xml.Schema;

namespace TafeSAEnrolment
{
    public static class Utility
    {
        // ====================================================================================================================================================
        // Sort
        // ====================================================================================================================================================
        public static void MergeSortAscending<T>(List<T> list) where T : IComparable<T>
        {
            try
            {
                MergeSort(list, 0, list.Count - 1, (x, y) => x.CompareTo(y));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during MergeSortAscending: {ex.Message}");
            }
        }

        public static void MergeSortDescending<T>(List<T> list) where T : IComparable<T>
        {
            try
            {
                MergeSort(list, 0, list.Count - 1, (x, y) => y.CompareTo(x));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during MergeSortDescending: {ex.Message}");
            }

        }

        public static void QuickSortAscending<T>(List<T> list) where T : IComparable<T>
        {
            try
            {
                QuickSort(list, 0, list.Count - 1, (x, y) => x.CompareTo(y));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during QuickSortAscending: {ex.Message}");
            }
        }

        public static void QuickSortDescending<T>(List<T> list) where T : IComparable<T>
        {
            try
            {
                QuickSort(list, 0, list.Count - 1, (x, y) => y.CompareTo(x));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during QuickSortDescending: {ex.Message}");
            }
        }

        // ====================================================================================================================================================
        // Search
        // ====================================================================================================================================================
        public static int BinarySearch<T>(List<T> list, T target) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;

            // divide and conquer 
            while (low <= high)
            {
                // find the middle index, repeatedly dividing the problem into half
                int mid = (high + low) / 2;
                if (list[mid].CompareTo(target) == 0)
                {
                    // found 
                    return mid;
                }
                else if (list[mid].CompareTo(target) > 0)
                {
                    // second half of array
                    high = mid - 1;
                }
                else if (list[mid].CompareTo(target) < 0)
                {
                    // first half of array
                    low = mid + 1;
                }
            }

            return -1;
        }


        // unsorted search
        public static int LinearSearch<T>(List<T> list, T target) where T : IComparable<T>
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            // loop through the list linearly
            for (int i = 0; i < list.Count; i++)
            {
                // compare
                if (list[i].CompareTo(target) == 0)
                    return i;
            }
            return -1;
        }


        private static void MergeSort<T>(List<T> list, int left, int right, Comparison<T> comparison)
        {
            // reduce arary into single element
            if (left < right)
            {
                // divide 
                int mid = left + (right - left) / 2;

                // splits the list and call itself to sort the two halves
                // divide and conquer
                MergeSort(list, left, mid, comparison);
                MergeSort(list, mid + 1, right, comparison);

                // compare & combine
                Merge(list, left, mid, right, comparison);

            }
        }
        private static void Merge<T>(List<T> list, int left, int mid, int right, Comparison<T> comparison)
        {
            int len1 = mid - left + 1;
            int len2 = right - mid;

            T[] leftArr = new T[len1];
            T[] rightArr = new T[len2];

            // Copy data to temporary array
            for (int i = 0; i < len1; i++)
                leftArr[i] = list[left + i];


            for (int i = 0; i < len2; i++)
                rightArr[i] = list[mid + 1 + i];

            int indexLeft = 0, indexRight = 0;
            int k = left;

            while (indexLeft < len1 && indexRight < len2)
            {
                if (comparison(leftArr[indexLeft], rightArr[indexRight]) <= 0)
                {
                    list[k] = leftArr[indexLeft];
                    indexLeft++;
                }
                else
                {
                    list[k] = rightArr[indexRight];
                    indexRight++;
                }

                k++;
            }

            while (indexLeft < len1)
            {
                list[k] = leftArr[indexLeft];
                indexLeft++;
                k++;
            }

            while (indexRight < len2)
            {
                list[k] = rightArr[indexRight];
                indexRight++;
                k++;
            }
        }

        private static void QuickSort<T>(List<T> list, int low, int high, Comparison<T> comparison)
        {
            if (low < high)
            {
                int pivot = Partition(list, low, high, comparison);

                // place the elements to the left of the pivot
                QuickSort(list, low, pivot - 1, comparison);

                // place the elements to the right of the pivot
                QuickSort(list, pivot + 1, high, comparison);

            }
        }

        private static int Partition<T>(List<T> list, int low, int high, Comparison<T> comparison)
        {
            // choose a piviot
            T pivot = list[high];

            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (comparison(list[j], pivot) <= 0)
                {
                    i++;
                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, high);
            return i + 1;
        }


        private static void Swap<T>(List<T> array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }
}