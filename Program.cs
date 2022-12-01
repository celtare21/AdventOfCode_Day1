using System.Reflection;

var filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);
var lines = File.ReadAllLines($@"{filePath!}\1.txt").Append(string.Empty).ToArray();

Console.WriteLine(GetMaxElfCalories(lines));
Console.WriteLine(GetMax3ElfCalories(lines));

static int GetMaxElfCalories(IEnumerable<string> lines)
{
    var max = 0;
    var sum = 0;

    foreach (var line in lines)
    {
        if (int.TryParse(line, out var num))
        {
            sum += num;
        }
        else
        {
            if (sum > max)
                max = sum;

            sum = 0;
        }
    }

    return max;
}

static int GetMax3ElfCalories(IEnumerable<string> lines)
{
    var maxElfCalories = new List<int>();
    int sum = 0;

    foreach (var line in lines)
    {
        if (int.TryParse(line, out var num))
        {
            sum += num;
        }
        else
        {
            maxElfCalories.Add(sum);

            sum = 0;
        }
    }

    maxElfCalories.Sort((a, b) => b.CompareTo(a));

    return maxElfCalories[0] + maxElfCalories[1] + maxElfCalories[2];
}