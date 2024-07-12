using LibraryWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LibraryWebApplication.TagHelpers;

public class PageLinkTagHelper : TagHelper
{
    private readonly IUrlHelperFactory _urlHelperFactory;

    [ViewContext] [HtmlAttributeNotBound] public ViewContext ViewContext { get; set; }

    public PagedModel<BookModel> PageModel { get; set; }
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
        tag.Attributes.Add("style", "float: right");
        tag.InnerHtml.AppendHtml(CreatePageSizeInputTag());

        var currentItem = CreateTag(helper, PageModel.CurrentPage);

        if (PageModel.HasPreviousPage)
        {
            var prevItem = CreateTag(helper, PageModel.CurrentPage - 1);
            tag.InnerHtml.AppendHtml(prevItem);
        }

        tag.InnerHtml.AppendHtml(currentItem);

        if (PageModel.HasNextPage)
        {
            var nextItem = CreateTag(helper, PageModel.CurrentPage + 1);
            tag.InnerHtml.AppendHtml(nextItem);
        }

        output.Content.AppendHtml(tag);
    }


    private TagBuilder CreateTag(IUrlHelper urlHelper, int pageNumber)
    {
        var item = new TagBuilder("li");
        var link = new TagBuilder("a");
        if (pageNumber == PageModel.CurrentPage)
        {
            item.AddCssClass("active");
        }
        else
        {
            link.Attributes["href"] =
                urlHelper.Action(PageAction, new {currentPage = pageNumber, pageSize = PageModel.PageSize});
        }

        item.AddCssClass("page-item");
        link.AddCssClass("page-link");
        link.InnerHtml.Append(pageNumber.ToString());
        item.InnerHtml.AppendHtml(link);

        return item;
    }

    private TagBuilder CreatePageSizeInputTag()
    {
        var input = new TagBuilder("input")
        {
            Attributes =
            {
                ["type"] = "number",
                ["name"] = "pageSize"
            }
        };
        input.AddCssClass("form-control form-control-sm display-inline w-25 me-2");

        var button = new TagBuilder("button")
        {
            Attributes =
            {
                ["type"] = "submit"
            }
        };
        button.AddCssClass("display-inline btn btn-secondary me-2 btn-sm ");
        button.InnerHtml.Append("Обновить");

        var text = new TagBuilder("p");
        text.InnerHtml.Append("Размер страницы");
        text.AddCssClass("display-inline mx-1");

        var label = new TagBuilder("label")
        {
            Attributes =
            {
                ["for"] = "pageSize",
                ["style"] = "text-align: right"
            }
        };
        label.InnerHtml.AppendHtml(text);
        label.InnerHtml.AppendHtml(input);
        label.InnerHtml.AppendHtml(button);

        var innerDiv = new TagBuilder("div");
        innerDiv.AddCssClass("form-group");
        innerDiv.InnerHtml.AppendHtml(label);

        var form = new TagBuilder("form")
        {
            Attributes =
            {
                ["method"] = "get",
                ["asp-controller"] = "Cinema",
                ["asp-action"] = "Index"
            }
        };
        form.InnerHtml.AppendHtml(innerDiv);

        return form;
    }
}