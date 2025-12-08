public static class ScriptGenerator
{

    private static Dictionary<string, ScriptObj> scripts = new();

    public static void LoadScripts(string path)
    {
        if (!Directory.Exists(path)) return;

        var files = Directory.GetFiles(path, "*.gd", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);

            if (scripts.ContainsKey(fileName)) continue;

            ScriptObj script = new ScriptObj(path, fileName);

            scripts.Add(fileName, script);
        }

    }

}