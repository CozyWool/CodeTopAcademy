using CrudWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CrudWeb.TagHelpers;

public class PageLinkTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;

    [ViewContext] [HtmlAttributeNotBound] public ViewContext ViewContext { get; set; }

    public PageViewModel<ProductModel> PageModel { get; set; }

    public string PageAction { get; set; }

    public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var helper = _urlHelperFactory.GetUrlHelper(ViewContext);
        output.TagName = "div";

        var tag = new TagBuilder("ul");
        tag.AddCssClass("pagination");

        var currentItem = CreateTag(helper, PageModel.PageNumber);

        if (PageModel.HasPreviousPage)
        {
            var prevItem = CreateTag(helper, PageModel.PageNumber - 1);
            tag.InnerHtml.AppendHtml(prevItem);
        }

        tag.InnerHtml.AppendHtml(currentItem);

        if (PageModel.HasNextPage)
        {
            var nextItem = CreateTag(helper, PageModel.PageNumber + 1);
            tag.InnerHtml.AppendHtml(nextItem);
        }

        output.Content.AppendHtml(tag);
    }


    private TagBuilder CreateTag(IUrlHelper urlHelper, int pageNumber)
    {
        var item = new TagBuilder("li");
        var link = new TagBuilder("a");
        if (pageNumber == PageModel?.PageNumber)
        {
            item.AddCssClass("active");
        }
        else
        {
            link.Attributes["href"] = urlHelper.Action(PageAction, new {page = pageNumber, pageSize = PageModel?.PageSize});
        }

        item.AddCssClass("page-item");
        link.AddCssClass("page-link");
        link.InnerHtml.Append(pageNumber.ToString());
        item.InnerHtml.AppendHtml(link);

        return item;
    }
}