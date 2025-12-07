public class Index : IHTMLGenerator
{
    public Dictionary<string, List<Chapter>> Chapters = new();

    public List<string> ChapterLayout = new();

    public Index(IndexObj index)
    {
        if (index.Book == null)
        {
            Console.WriteLine("No Content found in index.json.");
            return;
        }

        for (int i = 0; i < index.Book.GetLength(0); i++)
        {
            for (int j = 0; j < index.Book[i].Length; j++)
            {
                if (!Chapters.ContainsKey(index.Book[i][0]))
                {
                    Chapters.Add(index.Book[i][0], new List<Chapter>());
                    ChapterLayout.Add(index.Book[i][0]);
                }

                Chapter ch = new Chapter(index.Book[i][j], "blablabla");
                Chapters[index.Book[i][0]].Add(ch);

            }
        }
    }

    public string GenerateSite()
    {
        string site = "<!DOCTYPE html>\n";

        site += "<html>";

        site += Utils.GenerateHead("Table of Contents");

        site += GenerateBody();

        site += "</html>";
        return site;
    }

    public string GenerateNavBar()
    {
        string navBar = "<nav class=\"toc\">\n";

        navBar += "<div class=\"contents\">\n";

        navBar += "<h2><small>Table of Contents</small></h2>\n";

        navBar += "<ul>\n";

        for (int i = 0; i < ChapterLayout.Count; i++)
        {
            navBar += $"<li><a href=\"#{ChapterLayout[i]}\"><small>{Utils.ToRomanNumber(i + 1)}</small>{ChapterLayout[i]}</a></li>\n";
        }

        navBar += "</ul>\n";

        navBar += "<div class =\"prev-next\">\n";

        string prevTitle = "";
        string nextTitle = "";

        navBar += $"<a class=\"prev\" href=\"{prevTitle}.html\">&#8592; Prev</a>\n";
        navBar += $"<a class=\"next\" href=\"{nextTitle}.html\">Next &#8594;</a>\n";

        navBar += "</div>\n";

        navBar += "</div>\n";
        navBar += "</nav>\n";

        return navBar;
    }

    public string GenerateBody()
    {
        string body = "<body>\n";

        body += GenerateNavBar();

        body += "<div class=\"page\">\n";
        body += "</div>\n";

        body += "</body>\n";
        return body;
    }
}