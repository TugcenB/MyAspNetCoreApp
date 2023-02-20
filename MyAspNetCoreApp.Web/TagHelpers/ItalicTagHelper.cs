using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Xml.Serialization;

namespace MyAspNetCoreApp.Web.TagHelpers
{
    public class ItalicTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<i>");

            output.PostContent.SetHtmlContent("</i>");
        }
    }
}
