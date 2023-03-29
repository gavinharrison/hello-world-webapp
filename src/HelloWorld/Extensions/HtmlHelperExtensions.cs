using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HelloWorld.Extentions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString InlineStyles(this IHtmlHelper htmlHelper, string bundleVirtualPath)
        {
            var bundleContent = File.ReadAllText(bundleVirtualPath);
            var htmlTag = $"<style>{bundleContent}</style>";

            return new HtmlString(htmlTag);
        }
    }
}
