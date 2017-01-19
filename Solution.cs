using System;

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
}