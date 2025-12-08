using Markdig.Extensions.CustomContainers;
using Markdig.Renderers;
using Markdig.Renderers.Html;

public class SBBCustomContainerRenderer : HtmlObjectRenderer<CustomContainer>
{
    //Matches the format: {id}:{num}:{num}:{text}
    private static string pattern = "([a-zA-Z-_]+):([0-9]+):([0-9]+):?([a-zA-Z\\s*]*)$";

    private static string ATTR_CODE = "code";

    protected override void Write(HtmlRenderer renderer, CustomContainer obj)
    {
        if (obj.Info == ATTR_CODE)
        {
            //render custom html based on parsed scripts 
            Console.WriteLine("Inserting Premade CodeBlock");
            return;
        }

        renderer.EnsureLine();
        if (renderer.EnableHtmlForBlock)
        {
            renderer.Write("<div").WriteAttributes(obj).Write('>');
        }

        Console.WriteLine($"Rendering Custom Block: {obj.Info}");

        renderer.WriteChildren(obj);
        if (renderer.EnableHtmlForBlock)
        {
            renderer.WriteLine("</div>");
        }
    }
}