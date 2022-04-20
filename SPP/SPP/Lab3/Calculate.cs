﻿namespace Lab3;

public class Calculate
{
    public int Sum(params int[] numbers)
    {
        return numbers.Sum();
    }
    
    public static int LevenshteinDistance(string source1, string source2)
    {
        if (source1 == null && source2 != null || source2 == null && source1 != null)
        {
            return -1;
        }
        
        var source1Length = source1.Length;
        var source2Length = source2.Length;

        var matrix = new int[source1Length + 1, source2Length + 1];
        
        if (source1Length == 0)
            return source2Length;

        if (source2Length == 0)
            return source1Length;
        
        for (var i = 0; i <= source1Length; matrix[i, 0] = i++){}
        for (var j = 0; j <= source2Length; matrix[0, j] = j++){}
        
        for (var i = 1; i <= source1Length; i++)
        {
            for (var j = 1; j <= source2Length; j++)
            {
                var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

                matrix[i, j] = Math.Min(
                    Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                    matrix[i - 1, j - 1] + cost);
            }
        }
        
        return matrix[source1Length, source2Length];
    }

    public static string Keep(string str, string pattern)
    {
        return str switch
        {
            null when pattern == null => throw new ArgumentNullException(),
            null => null,
            _ => pattern == null ? string.Empty : string.Join("", str.Where(c => pattern.Any(c1 => c == c1)).ToArray())
        };
    }
}