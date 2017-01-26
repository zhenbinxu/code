using System;
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
}