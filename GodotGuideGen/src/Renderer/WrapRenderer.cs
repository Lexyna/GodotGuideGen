using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;

public class WrapRenderer<TBlock, TOriginal> : HtmlObjectRenderer<TBlock>
    where TBlock : Block
    where TOriginal : HtmlObjectRenderer<TBlock>
{
    private TOriginal Original;
    private string WrapperTag;
    private string? WrapperClass;

    public WrapRenderer(TOriginal original, string tag = "div", string? wrapperClass = null)
    {
        this.Original = original;
        WrapperClass = wrapperClass;
        WrapperTag = tag;
    }

    protected override void Write(HtmlRenderer renderer, TBlock obj)
    {
        renderer.Write($"<{WrapperTag}");

        if (WrapperClass != null)
            renderer.Write($" class=\"{WrapperClass}\"");
        renderer.Write(">");

        renderer.WriteLine();

        Original.Write(renderer, obj);

        renderer.WriteLine();

        renderer.Write($"</{WrapperTag}>");
    }
}