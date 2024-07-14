using LibraryWebApplication.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LibraryWebApplication.TagHelpers;

public class SortHeaderTagHelper : TagHelper
{
    public SortState Property { get; set; }
    public SortState Current { get; set; }
    public string Action { get; set; }
    public bool Up { get; set; }

    private IUrlHelperFactory _urlHelperFactory;

    public SortHeaderTagHelper(IUrlHelperFactory helperFactory)
    {
        _urlHelperFactory = helperFactory;
    }

    [ViewContext] [HtmlAttributeNotBound] public ViewContext ViewContext { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        output.TagName = "a";
        var url = urlHelper.Action(Action, new {sortOrder = Property});
        output.Attributes.SetAttribute("href", url);
        if (Current != Property) return;
        
        var tag = new TagBuilder("i");
        tag.AddCssClass("glyphicon");

        tag.AddCssClass(Up ? "glyphicon-chevron-up" : "glyphicon-chevron-down");

        output.PreContent.AppendHtml(tag);
    }
}