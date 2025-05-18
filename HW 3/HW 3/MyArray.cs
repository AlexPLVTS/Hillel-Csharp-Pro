using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3
{
    internal class MyArray : IOutput, IMath, ISort
    {
        public int[] nums { get; set; }
        public MyArray(int[] ints) 
        {
            nums = ints;
        }
        public void Show()
        {
            foreach (int n in nums)
            {
                Console.Write(n + " ");
            }
        }
        public void Show(string info)
        {
            Console.Write($"{info}; ");
            Console.WriteLine("[" + string.Join(", ", nums) + "]");
        }
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
                SortAsc();
            else
                SortDesc();
        }
        public void SortAsc()
        {
            Array.Sort(nums, Compare);
        }
        public void SortDesc()
        {
            Array.Sort(nums, (x, y) => Compare(y, x));
        }
        private int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
        public bool Search(int valueToSearch)
        {
            SortAsc();
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (Compare(nums[mid], valueToSearch) == 0)
                    return true;
                else if (Compare(nums[mid], valueToSearch) > 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return false;
        }
        public int Max()
        {
            SortAsc();
            return nums[nums.Length - 1];
        }
        public int Min()
        {
            SortAsc();
            return nums[0];
        }
        public float Average()
        {
            float average = 0.0f;
            foreach (int n in nums)
            {
                average += n;
            }
            return average / nums.Length;
        }
    }
}
