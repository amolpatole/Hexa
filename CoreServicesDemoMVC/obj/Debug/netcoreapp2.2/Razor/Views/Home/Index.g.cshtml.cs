#pragma checksum "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3afa0eb79e77eb4cbd4232fec4d337f4468722a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\_ViewImports.cshtml"
using CoreServicesDemoMVC;

#line default
#line hidden
#line 2 "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\_ViewImports.cshtml"
using CoreServicesDemoMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3afa0eb79e77eb4cbd4232fec4d337f4468722a7", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea6845b49976d605df4049f7e6663ff4c7f1dbda", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 197, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n\r\n<h2>");
            EndContext();
            BeginContext(243, 15, false);
#line 10 "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\Home\Index.cshtml"
Write(ViewBag.message);

#line default
#line hidden
            EndContext();
            BeginContext(258, 18, true);
            WriteLiteral("</h2>\r\n<br />\r\n<p>");
            EndContext();
            BeginContext(277, 12, false);
#line 12 "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\Home\Index.cshtml"
Write(ViewBag.name);

#line default
#line hidden
            EndContext();
            BeginContext(289, 30, true);
            WriteLiteral("</p>\r\n\r\n<br />\r\n<p>UserName : ");
            EndContext();
            BeginContext(320, 16, false);
#line 15 "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\Home\Index.cshtml"
         Write(ViewBag.Username);

#line default
#line hidden
            EndContext();
            BeginContext(336, 25, true);
            WriteLiteral("</p>\r\n\r\n<br />\r\n<p>Age : ");
            EndContext();
            BeginContext(362, 11, false);
#line 18 "C:\Users\r1m1nrao\source\repos\CoreServicesDemoMVC\Views\Home\Index.cshtml"
    Write(ViewBag.Age);

#line default
#line hidden
            EndContext();
            BeginContext(373, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
