using System.Text.Json;
using System.Text.Json.Serialization;

public class Entry
{

    public static void Main(String[] args)
    {
        Console.WriteLine("Static Book Gen, Hello!");

        string path = "";

        //Load Scripts
        ScriptGenerator.LoadScripts(path + "/Scripts");

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
    }

}