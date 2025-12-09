using System.Text.Json;
using System.Text.Json.Serialization;

public class Entry
{

    public static void Main(String[] args)
    {
        if (args.Length < 1 || args.Length > 1)
        {
            Console.WriteLine($"Expected exactly 1 argument 'path', but received {args.Length}.");
            return;
        }

        string path = args[0];

        if (!Directory.Exists(path))
        {
            Console.WriteLine($"The path '{path}' could not be resolved.");
            return;
        }

        //Load Scripts
        ScriptGenerator.LoadScripts(path);

        //Read index file
        string indexJson = File.ReadAllText(path + "/Book/index.json");
        IndexObj? indexObj = JsonSerializer.Deserialize<IndexObj>(indexJson);

        if (indexObj == null)
        {
            Console.WriteLine("Couldn't read index file.");
            return;
        }

        Index index = new Index(indexObj, path);

        index.CreateHTML();
        Console.WriteLine("Godot Guide Generated!");
    }

}