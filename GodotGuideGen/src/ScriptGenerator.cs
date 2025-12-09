using System.Security.Cryptography.X509Certificates;

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
            string filePath = Path.GetRelativePath(path, file);

            if (scripts.ContainsKey(fileName)) continue;

            ScriptObj script = new ScriptObj(path, filePath, fileName);

            scripts.Add(fileName, script);
        }

    }

    public static string CerateCodeSnippet(string id, int before, int after, string displayInfo)
    {
        foreach (KeyValuePair<string, ScriptObj> pair in scripts)
        {
            var script = pair.Value;
            if (!script.blocks.ContainsKey(id))
                continue;
            return script.GenerateCodeSnippet(id, before, after, displayInfo);
        }
        return "";
    }

}