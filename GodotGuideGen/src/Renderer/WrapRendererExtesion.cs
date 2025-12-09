using System.Net.Http.Headers;
using Markdig.Extensions.Abbreviations;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;

public static class WrapRendererExtension
{
    public static void WrapRenderer<TBlock, TOriginal>(
        this HtmlRenderer renderer,
        string tag = "div",
        string? wrapperClass = null
    )
    where TBlock : Block
    where TOriginal : HtmlObjectRenderer<TBlock>
    {
        var original = renderer.ObjectRenderers.OfType<TOriginal>().FirstOrDefault();

        if (original == null) return;

        renderer.ObjectRenderers.Remove(original);
        var wrapper = new WrapRenderer<TBlock, TOriginal>(original, tag, wrapperClass);
        renderer.ObjectRenderers.Add(wrapper);
    }
}