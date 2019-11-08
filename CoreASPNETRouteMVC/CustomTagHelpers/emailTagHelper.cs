using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreASPNETRouteMVC.CustomTagHelpers
{
    [HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)]
    public class emailTagHelper : TagHelper
    {
        public string address { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("href", $"mailto:{address}");
            output.Content.SetContent($"Send mail to {address}");
            //base.Process(context, output);
        }
    }
}
