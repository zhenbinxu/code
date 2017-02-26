using System;
using System.Diagnostics;
using System.Collections.Generic;

public class Solution
{
    //
    // You are playing the following Nim Game with your friend: There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones. The one who removes the last stone will be the winner. You will take the first turn to remove the stones.
    // Both of you are very clever and have optimal strategies for the game.Write a function to determine whether you can win the game given the number of stones in the heap.
    // For example, if there are 4 stones in the heap, then you will never win the game: no matter 1, 2, or 3 stones you remove, the last stone will always be removed by your friend.
    //
    public bool CanWinNim(int n)
    {
        // You win if the stones are no more than 3. 
        if (n <= 3)
        {
            return true;
        }

        // Try take 1, if opponent wins, 
        if (CanWinNim(n - 1))
        {
            // Try Take 2
            if (CanWinNim(n - 2))
            {
                // Try Take 3
                if (CanWinNim(n - 3))
                {
                    return false;
                }
            }
        }

        return true;
    }


    // Given an arry of integers, return indices of the two numbers such that they add up to a specific target. 
    // You may assume that each input would have exactly one Solution
    // nums = [2, 7, 11, 15],  target = 9
    // nums[0] + nums[1] = 2 + 7 = 9
    // return [0, 1]. 
    public int[] TwoSum(int[] nums, int target) {
            Array.Sort(nums);

            int anchor  = 0;
            while (anchor < nums.Length - 2) {
                int scan = nums.Length - 1;

                while (anchor < scan) {
                    int sum = nums[anchor] + nums[scan];
                    if (sum == target) {
                            return new int [] { anchor, scan };
                    }
                    else if (sum > target) {
                            scan--;
                    }
                    else {
                            break;
                    }
                }
                anchor++;
            }
            return new int[0];
    }

    public void AddTwoNumbers(IEnumerable<int> n1, IEnumerable<int> n2)
    {
        // Consider overflow???
        /*
        You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

        You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        */

        LinkListClass<int> l1 = new LinkListClass<int>();
        l1.CreateList(n1);
        l1.PrintList(l1.List);

        LinkListClass<int> l2 = new LinkListClass<int>();
        l2.CreateList(n2);
        l2.PrintList(l2.List);

        LinkListClass<int> l3 = new LinkListClass<int>();

        var a = l1.List; 
        var b = l2.List;

        int carry = 0;
        while (a != null || b != null) {
                int d1 = 0;
                if (a != null) {
                    d1 = a.Val;
                    a  = a.Next;
                }
                
                int d2 = 0;
                if (b != null) {
                    d2 = b.Val;
                    b = b.Next;
                }

                int s = d1 + d2 + carry;
                int d3 = s % 10;
                carry  = s / 10;
                
                l3.Append(d3);
        }

        // Carry 
        if (carry != 0) {
            l3.Append(carry);
        }

        Console.Write("Sum is ");
        l3.PrintList(l3.List);
    }

    public int LengthOfLongestSubstringV1(string s) {
        // Given "abcabcbb", the answer is "abc", which the length is 3.
        // Given "bbbbb", the answer is "b", with the length of 1.
        // Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
        // Given "abcdaegha", the answer is "bcdaegh", with the length of 7.
        int longest  = 0;
        int slongest = 0;
        var ss = new Dictionary<char, int>();
        for (int start = 0, end = s.Length; start < end - longest; ) {
            // Handle substring begining at "start"
            ss.Clear();
            int skip = 0;
            for (int i = start; i < end; i++) {
                char c = s[i];
                if (ss.ContainsKey(c)) {
                    bool gotRepeat = ss.TryGetValue(c, out skip);
                    skip++; // convert index to length
                    Debug.Assert(gotRepeat);
                    break;
                }
                else {
                    ss.Add(c, i);
                }
            }

            // Update longest if necessary
            if (ss.Count > longest) {
                slongest = start;
                longest  = ss.Count;
            }
            // Skip past the repeating character. 
            start += skip;
        }

        // Print the longest substring
        if (longest > 0) {
            Console.Write(s.Substring(slongest, longest));
        }
        else {
            Console.Write("");
        }
        return longest;
    }

  public int LengthOfLongestSubstring(string s) {
        // Given "abcabcbb", the answer is "abc", which the length is 3.
        // Given "bbbbb", the answer is "b", with the length of 1.
        // Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
        // Given "abcdaegha", the answer is "bcdaegh", with the length of 7.

        // Longest sliding window
        int blongest  = 0;
        int elongest  = -1;

        var ss = new Dictionary<char, int>();
        for (int b = 0, e = 0;  e < s.Length; ) {
            // Try to extend the range [s, e]
            char  c = s[e];
            if (ss.ContainsKey(c)) {
                // Locate the repeating char
                int olde = 0;
                bool gotRepeat = ss.TryGetValue(c, out olde);
                Debug.Assert(gotRepeat);

                // Move left side of window until we have passed the repeating char.  
                for ( ; b <= olde; b++) {
                    ss.Remove(s[b]);
                }
            }
            // Extend e;               
            ss.Add(c, e);
            // Record the postion of the longest char
            if (ss.Count > (elongest - blongest + 1)) {
                blongest = b; 
                elongest = e;
            }

            // Move to a new char as new ending.  
            e++; 
        }

        // Print the longest substring
        if ( elongest >= blongest ) {
            Console.Write(s.Substring(blongest, elongest - blongest + 1));
        }
        else {
            Console.Write("");
        }
        return elongest - blongest + 1;
    }


    public double FindMedianSortedArrays(int[] a1, int[] a2)
    {
        // Median = (A[(N-1)/2] + A[N/2]) / 2;
        int N1 = a1.Length;
        int N2 = a2.Length;
        if (N1 < N2) return FindMedianSortedArrays(a2, a1); // Make sure a2 is shorter one. 
        Debug.Assert(N1 > 0);
        if (N2 == 0) return ((double)a1[(N1-1)/2] + (double)a1[N1/2]) / 2;  // If a2 is empty

        int lo = 0, hi = N2 * 2;
        while (lo <= hi) {
            int mid2 = (lo + hi) / 2;   // Try Cut 2
            int mid1 = N1 + N2 - mid2;  // Calculate Cut 1 accordingly

            double L1 = (mid1 == 0) ? Int32.MinValue : a1[(mid1 - 1) / 2];  // Get L1, R1, L2, R2 respectxively
            double L2 = (mid2 == 0) ? Int32.MinValue : a2[(mid2 - 1) / 2];
            double R1 = (mid1 == N1 * 2) ? Int32.MaxValue : a1[mid1/2];
            double R2 = (mid2 == N2 * 2) ? Int32.MaxValue : a2[mid2/2];

            if (L1 > R2) lo = mid2 + 1;         // A1's lower half is too big; need to move C1 left (C2 right)
            else if (L2 > R1) hi = mid2 - 1;    // A2's lower half too big; need to move C2 left
            else return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;  // Otherise, that's the rigth cut; 
        }

        return -1;
    }
}