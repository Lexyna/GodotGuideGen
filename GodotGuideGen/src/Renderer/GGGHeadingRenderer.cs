using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;

public class GGGHeadingRenderer : HtmlObjectRenderer<HeadingBlock>
{
    private static readonly string[] HeadingTexts = [
      "h1",
        "h2",
        "h3",
        "h4",
        "h5",
        "h6",
    ];
    protected override void Write(HtmlRenderer renderer, HeadingBlock obj)
    {
        int index = obj.Level - 1;
        string[] headings = HeadingTexts;
        string headingText = ((uint)index < (uint)headings.Length)
            ? headings[index]
            : $"h{obj.Level}";

        if (renderer.EnableHtmlForBlock)
        {
            string id = obj.Inline.FirstChild.ToString().Replace(" ", "-");

            renderer.Write('<');
            renderer.Write(headingText);
            renderer.WriteAttributes(obj);
            if (headingText == "h1")
                renderer.Write($" id=\"{id}\" class=\"title\">");
            else
                renderer.Write($" id=\"{id}\" >");
        }

        renderer.WriteLeafInline(obj);

        if (renderer.EnableHtmlForBlock)
        {
            renderer.Write("</");
            renderer.Write(headingText);
            renderer.WriteLine('>');
        }

        renderer.EnsureLine();
    }
}