using System;

public class Square
{
    public bool IsPerfectSquare(int n)
    {
        if (n >= 0) {
            switch (n)
            {
                case 0:
                    goto case 1;

                case 1: 
                    return true;
                
                default: 
                    int high = n;
                    int low  = 1;
                    var tic  = 1;

                    while (low <= high) {
                        int mid  = (high + low) / 2;
                        Console.WriteLine(tic++  + " | " + mid);

                        // Overflow Alert
                        // mid * mid could overflow to become 0.  Worse yet the result type would be int w/o casting
                        // long vsqaure = mid * mid;        <=== doen't help

                        long vsquare = (long) mid * (long) mid;
                        if (vsquare == n)  {
                            Console.WriteLine("==============> " + mid);
                            return true;
                        }
                        else if (vsquare < n) {
                            low = mid + 1;
                        }
                        else {
                            high = mid - 1;
                        }
                    }
                    break;
            }    
        }
        return false;
    }
}