public class Entry
{

    public static void Main(String[] args)
    {
        Console.WriteLine("Static Book Gen, Hello!");

        Index index = new Index();

        int testChapter = 10;

        for (int i = 1; i <= testChapter; i++)
        {
            string title = $"Chapter {i}";
            Chapter ch = new Chapter(title, "blablabla");
            index.chapters.Add(title, ch);
            index.layout.Add(title);
        }

        if (!Directory.Exists("Site"))
            Directory.CreateDirectory("Site");

        File.WriteAllText("Site/index.html", index.GenerateSite());

    }

}