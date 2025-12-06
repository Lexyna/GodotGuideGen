/*
    This class contains the the index structure of the book as parsed by the index.json file
*/
public class Index : IHTMLGenerator
{
    public Dictionary<string, Chapter> chapters = new();

    public List<string> layout = new();

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

        for (int i = 0; i < layout.Count; i++)
        {
            navBar += $"<li><a href=\"#{layout[i]}\"><small>{Utils.ToRomanNumber(i + 1)}</small>{layout[i]}</a></li>\n";
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