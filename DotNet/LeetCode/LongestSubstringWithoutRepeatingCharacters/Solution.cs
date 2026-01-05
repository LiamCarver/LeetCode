namespace LeetCode.LongestSubstringWithoutRepeatingCharacters;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0) return 0;
        
        var lengthOfLongestSubstring = 1;

        for (var outerIndex = 0; outerIndex <= s.Length - 2; outerIndex++)
        {
            var totalLettersLeft = s.Length - outerIndex;
            if (lengthOfLongestSubstring >  totalLettersLeft)
            {
                return lengthOfLongestSubstring;
            }

            var currentHashSet = new HashSet<char>();
            var startingCharacter = s[outerIndex];
            currentHashSet.Add(startingCharacter);

            var currentStringLength = 1;

            for (var innerIndex = outerIndex + 1; innerIndex <= s.Length - 1; innerIndex++)
            {
                var nextLetterToAdd = s[innerIndex];
                var isLetterDuplicate = !currentHashSet.Add(nextLetterToAdd);
                
                if (isLetterDuplicate)
                {
                    break;
                }
                else
                {
                    currentStringLength++;
                }
            }

            if (currentStringLength > lengthOfLongestSubstring)
            {
                lengthOfLongestSubstring = currentStringLength;
            }
        }

        return lengthOfLongestSubstring;
    }
}
