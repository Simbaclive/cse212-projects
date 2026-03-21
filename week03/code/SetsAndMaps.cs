using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            // Reverse the 2-character word
            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                // If the reversed version is already in our set, it's a matching pair
                result.Add($"{word} & {reversed}");
            }
            else
            {
                // Otherwise, add the current word to the set to check against future words
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file. 
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            
            // The degree information is in the 4th column (index 3)
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim(); // Trim to remove any accidental whitespace
                
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var charCounts = new Dictionary<char, int>();
        int validCharCount1 = 0;

        // Count characters in the first word
        foreach (char c in word1)
        {
            if (c == ' ') continue; // Ignore spaces
            
            char lower = char.ToLower(c); // Ignore case differences
            if (charCounts.ContainsKey(lower))
            {
                charCounts[lower]++;
            }
            else
            {
                charCounts[lower] = 1;
            }
            validCharCount1++;
        }

        int validCharCount2 = 0;

        // Validate characters against the second word
        foreach (char c in word2)
        {
            if (c == ' ') continue; // Ignore spaces
            
            char lower = char.ToLower(c);
            
            // If we find a letter not in word1, or we've used up all instances of that letter, it's false
            if (!charCounts.ContainsKey(lower) || charCounts[lower] == 0)
            {
                return false;
            }
            
            charCounts[lower]--;
            validCharCount2++;
        }

        // The lengths of valid non-space characters must match exactly
        return validCharCount1 == validCharCount2;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();

        // Format the output: "Place - Mag Magnitude"
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return summaries.ToArray();
    }
}