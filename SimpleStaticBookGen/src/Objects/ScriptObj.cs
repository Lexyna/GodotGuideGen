using System.Text.RegularExpressions;

public class ScriptObj
{
    private static string patternStart = "#>>\\s*([a-zA-Z-_]+)";
    private static string patternEnd = "#<<\\s*([a-zA-Z-_]+)";

    private List<string> Lines = new();

    public Dictionary<string, (List<string>, int)> blocks = new();

    public string FileName { get; private set; }

    private HashSet<string> currentBlocks = new();

    public ScriptObj(string path, string fileName)
    {
        this.FileName = fileName;
        LoadScript(path);
    }

    private void LoadScript(string path)
    {
        if (!Directory.Exists(path)) return;
        if (!File.Exists(path + $"/{FileName}.gd")) return;

        var pre_lines = File.ReadAllLines(path + $"/{FileName}.gd").ToList();

        int lineIdx = 1;

        for (int i = 0; i < pre_lines.Count; i++)
        {
            var line = pre_lines[i];

            Match startBlock = Regex.Match(line, patternStart);
            Match endBlock = Regex.Match(line, patternEnd);

            if (startBlock.Success)
            {
                MatchCollection matches = Regex.Matches(line, patternStart);
                string id = matches[0].Groups[1].Value;

                if (!currentBlocks.Contains(id))
                    currentBlocks.Add(id);

                continue;
            }

            if (endBlock.Success)
            {
                MatchCollection matches = Regex.Matches(line, patternEnd);
                string id = matches[0].Groups[1].Value;

                if (currentBlocks.Contains(id))
                    currentBlocks.Remove(id);

                continue;
            }

            Lines.Add(line);

            foreach (var block in currentBlocks)
            {
                if (!blocks.ContainsKey(block))
                    blocks.Add(block, (new List<string>(), lineIdx));
                blocks[block].Item1.Add(line);
            }

            lineIdx++;

        }
    }

}