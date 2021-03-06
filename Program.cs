﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algo
{    class Program
    {
        static void Main(string[] args)
        {
            //TestPairReverse();
            //TestNim();
            //TestSquare();
            //TestTwoSum();
            //TestAddTwoNumbers();
            //TestLengthOfLongestSubstring();
            //TestMediumOfTwoSortedArrays();
            TestLongestPalindrome();
            Console.ReadLine();          
        }

        static void TestSquare()
        {
            var s = new Square();
            int[] samples = new int[] {1024 * 1024,  0, 1, 2, 3, 4, 5, 9, 16, 18, 1024};
            foreach (int n in samples) {
                Console.WriteLine(n + " is perfrect square " + s.IsPerfectSquare(n));
            }
        }

        static void TestTwoSum()
        {
            Console.WriteLine("TwoSum");
            Solution s = new Solution();
            var nums = new int[] {2, 3, 7, 11, 15, 18};
            var target = 18;
            var ret  = s.TwoSum(nums, target);
            if (ret.Length > 0) {
                Console.WriteLine("[" + ret[0] + " , "+ ret[1] + "]");
            }
            else {
                Console.WriteLine("NotExist");
            }
        }

        static void TestAddTwoNumbers()
        {
            Console.WriteLine("AddTwoNumbers");
            Solution s = new Solution();

            s.AddTwoNumbers(new List<int>(), new List<int> {0, 1});
            s.AddTwoNumbers(new List<int> {9, 9}, new List<int> {1});
            s.AddTwoNumbers(new List<int> {2, 4, 3}, new List<int> {5,6, 4});
            s.AddTwoNumbers(new List<int> {4, 3}, new List<int> {5,6, 4});
            s.AddTwoNumbers(new List<int> {3}, new List<int> {5,6, 4});
            s.AddTwoNumbers(new List<int> {1, 2, 4, 3}, new List<int> {5,6, 4});
        }

        static void TestNim()
        {
            Console.WriteLine("Nim");
            Solution s = new Solution();
            var N = 10;
            var r = s.CanWinNim(10);
            Console.WriteLine(N + " is  " + r);
        }

        static void TestPairReverse()
        {
            Console.WriteLine("PairReverse");
            TestList<Int32>(new List<int> { 1 });
            TestList<Int32>(new List<int> { 1, 2});
            TestList<Int32>(new List<int> { 1, 2, 3 });
            TestList<Int32>(new List<int> { 1, 2, 3, 4 });
            TestList<Int32>(new List<int> { 1, 2, 3, 4, 5});
            TestList<Int32>(new List<int> { 1, 2, 3, 4, 5, 6 });
        }

        static void TestList<T>(IEnumerable<T> list)
            where T : struct
        {
            LinkListClass<T> llc = new LinkListClass<T>();

            llc.CreateList(list);
            llc.PrintList(llc.List);
            llc.PrintList(llc.ReverseList(llc.List));
        }

        static void TestLengthOfLongestSubstring()
        {
            Console.WriteLine("TestLengthOfLongestSubstring");
            var testStrings = new List<string> { "", "b", "ab", "abc", "bbbbb", "pwwkew", "abcabcbb", "abcdaegha" };
            Solution s = new Solution();
            foreach (var t in testStrings) {
                Console.Write(t + ":");
                var r = s.LengthOfLongestSubstring(t); 
                Console.WriteLine(":" + r);
            }
        }

        static void TestMediumOfTwoSortedArrays()
        {
            Console.WriteLine("TestMediumOfTwoSortedArrays");
            Solution s = new Solution();
            double r;
            r = s.FindMedianSortedArrays(new int[] {1, 3}, new int[] {2});          // 2.0
            Console.WriteLine(":" + r);
            r = s.FindMedianSortedArrays(new int[] {1, 2}, new int[] {3,4});        // (2+3)/2 = 2.5
            Console.WriteLine(":" + r);
            r = s.FindMedianSortedArrays(new int[] {1, 2, 3}, new int[] {3, 4});    // 3.0
            Console.WriteLine(":" + r);
            r = s.FindMedianSortedArrays(new int[] {1, 2, 3}, new int[] {0, 1});    // 1.0
            Console.WriteLine(":" + r);
        }

        static void TestLongestPalindrome()
        {
            Console.WriteLine("TestLongestPalindrome");
            var testStrings = new List<string> { "", "b", "ab", "bb", "abc", "bbb", "cbbd", "babad", "eeekkkkabcdefedcb", "aaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaa" };
            Solution s = new Solution();
            foreach (var t in testStrings) {
                Console.Write(t + ":");
                var r = s.LongestPalindrome(t); 
                Console.WriteLine(":" + r);
            }
        }
    }
}
