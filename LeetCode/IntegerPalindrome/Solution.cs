namespace LeetCode.IntegerPalindrome;

public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }

        if (x < 10)
        {
            return true;
        }

        var originalNumber = x;
        var currentNumberToCheck = x;
        var reversedNumber = 0;

        while (currentNumberToCheck > 0)
        {
            var currentRemainder = currentNumberToCheck % 10;
            reversedNumber = (reversedNumber * 10) + currentRemainder;

            currentNumberToCheck /= 10;
        }

        return originalNumber == reversedNumber;
    }
}
