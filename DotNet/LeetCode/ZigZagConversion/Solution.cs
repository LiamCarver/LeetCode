using System.Text;

namespace LeetCode.ZigZagConversion;

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }
        
        var dictionary = new Dictionary<(int, int), char>();
        var currentRowIndex = 0;
        var currentColumnIndex = 0;
        var isGoingDown = true;

        foreach (var character in s)
        {
            dictionary.Add((currentRowIndex, currentColumnIndex), character);

            if (isGoingDown)
            {
                currentRowIndex++;
                if (currentRowIndex > numRows - 1)
                {
                    currentRowIndex -= 2;
                    if (currentRowIndex > 0)
                    {
                        isGoingDown = false;
                    }
                    currentColumnIndex++;
                }
            }
            else
            {
                currentRowIndex--;
                currentColumnIndex++;
                if (currentRowIndex == 0)
                {
                    isGoingDown = true;
                }
            }
        }

        var stringBuilder = new StringBuilder();

        for (var rowIndex = 0; rowIndex < numRows; rowIndex++)
        {
            for (var colIndex = 0; colIndex <= currentColumnIndex; colIndex++)
            {
                if (dictionary.TryGetValue((rowIndex, colIndex), out char value))
                {
                    stringBuilder.Append(value);
                }
            }
        }

        var result = stringBuilder.ToString();
        
        return result;
    }
}
