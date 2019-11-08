using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreASPNETRouteMVC.CustomTagHelpers
{
    [HtmlTargetElement("image", TagStructure= TagStructure.WithoutEndTag)]
    public class imageTagHelper : TagHelper
    {
        public string imagepath { get; set; }
        public string fallbackpath { get; set; }
        public static IHttpContextAccessor httpContextAccessor;

        public imageTagHelper(IHttpContextAccessor httpContextAccessors)
        {
            httpContextAccessor = httpContextAccessors;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.TagMode = TagMode.SelfClosing;
            HttpClient httpClient = new HttpClient();
            if(imagepath.StartsWith("http") || imagepath.StartsWith("https"))
            {
                var webURl = new Uri(imagepath);
                httpClient.BaseAddress = new Uri($"{webURl.Scheme}://{webURl.Host}");
                imagepath = webURl.LocalPath;
            }
            else
            {
                var baseUrl = httpContextAccessor.HttpContext.Request.GetDisplayUrl();
                httpClient.BaseAddress = new Uri(baseUrl);
            }

            using(HttpResponseMessage response = await httpClient.GetAsync(imagepath))
            {
                if(response.IsSuccessStatusCode)
                    output.Attributes.SetAttribute("src", imagepath);
                else
                    output.Attributes.SetAttribute("src", fallbackpath);
            }
            //if (!string.IsNullOrWhiteSpace(imagepath))
            //{
            //    if (!File.Exists(imagepath))
            //    {
            //        output.Attributes.SetAttribute("src", $"/images/default.png");
            //    }
            //    else { output.Attributes.SetAttribute("src", $"{imagepath}"); }
            //}
            //else { output.Attributes.SetAttribute("src", $"{imagepath}"); }
        }
    }
}
