#pragma checksum "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24c1edaae898b36e0aed3ada800a31f0e5d83d7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\_ViewImports.cshtml"
using CoinsAge;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\_ViewImports.cshtml"
using CoinsAge.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24c1edaae898b36e0aed3ada800a31f0e5d83d7e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd85cd8132af269000beadc4cb6f34f0b18df93e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "News", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-1 text-decoration-none category-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-2 text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100 col-4 text-2 text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"bg-1 text-1 w-100 p-4 px-5\">\r\n");
#nullable restore
#line 6 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
     foreach (var item in @ViewBag.Category)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24c1edaae898b36e0aed3ada800a31f0e5d83d7e5678", async() => {
                WriteLiteral("\r\n            <p class=\"d-inline mr-4\">");
#nullable restore
#line 9 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                Write(item.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                         WriteLiteral(item.CategoryId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<div class=\"row px-5\">\r\n    <div class=\"mt-5 col-8 py-3\">\r\n        <h4 class=\"text-3 font-weight-bold\">TRENDING NOW</h4>\r\n");
#nullable restore
#line 17 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
         foreach (var item in @ViewBag.TrendingNews)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24c1edaae898b36e0aed3ada800a31f0e5d83d7e9124", async() => {
                WriteLiteral("\r\n            <div class=\"w-100 row trendnews-box mt-5 cursor-pointer\">\r\n                <div class=\"col-3\">\r\n                    <img");
                BeginWriteAttribute("src", " src=\"", 817, "\"", 842, 1);
#nullable restore
#line 22 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
WriteAttributeValue("", 823, item.News.ImageURL, 823, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"w-100\">\r\n                </div>\r\n                <div class=\"col-9\">\r\n                    <div class=\"bg-3 text-1 font-size-1 px-3 py-1 d-inline-block font-weight-bold rounded-pill\">");
#nullable restore
#line 25 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                                                                           Write(item.News.Category.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                    <div class=\"text-4 font-size-1 d-inline-block\">");
#nullable restore
#line 26 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                              Write(item.News.PublishDateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                    <h5 class=\"mt-2\">");
#nullable restore
#line 27 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                Write(item.News.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                    <p>");
#nullable restore
#line 28 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                  Write(item.News.Content);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                        WriteLiteral(item.News.NewsId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"mt-5 col-4\">\r\n        <div class=\"p-3 shadow-lg\">\r\n            <h4 class=\"text-3 font-weight-bold\">MOST POPULAR NEWS</h4>\r\n");
#nullable restore
#line 39 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
             foreach (var item in @ViewBag.PopularNews)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24c1edaae898b36e0aed3ada800a31f0e5d83d7e14449", async() => {
                WriteLiteral("\r\n                <div class=\"w-100 row popnews-box mt-4\">\r\n                    <div class=\"col-3\">\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 1845, "\"", 1870, 1);
#nullable restore
#line 44 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
WriteAttributeValue("", 1851, item.News.ImageURL, 1851, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"w-100\">\r\n                    </div>\r\n                    <div class=\"col-9\">\r\n                        <div class=\"bg-3 text-1 font-size-1 px-3 py-1 d-inline-block font-weight-bold rounded-pill\">");
#nullable restore
#line 47 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                                                                               Write(item.News.Category.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div class=\"text-4 font-size-1 d-inline-block\">");
#nullable restore
#line 48 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                                  Write(item.News.PublishDateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <h6 class=\"mt-2\">");
#nullable restore
#line 49 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                    Write(item.News.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                    </div>\r\n\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                            WriteLiteral(item.News.NewsId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <hr />\r\n");
#nullable restore
#line 55 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"row px-5 mt-5\">\r\n    <div class=\"mt-5 col-12 py-3\">\r\n        <h4 class=\"text-3 font-weight-bold\">NEW RELEASE</h4>\r\n        <div class=\"row justify-content-start \">\r\n");
#nullable restore
#line 66 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
             foreach (var item in @ViewBag.News)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24c1edaae898b36e0aed3ada800a31f0e5d83d7e19625", async() => {
                WriteLiteral("\r\n                <div class=\"mx-5 newreleasenews-box mt-5 p-0 shadow-sm\">\r\n                    <img");
                BeginWriteAttribute("src", " src=\"", 2911, "\"", 2931, 1);
#nullable restore
#line 70 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
WriteAttributeValue("", 2917, item.ImageURL, 2917, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"w-100 newreleasenews-img\">\r\n                    <div class=\"p-3\">\r\n                        <div class=\"bg-3 text-1 font-size-1 px-3 py-1 d-inline-block font-weight-bold rounded-pill\">");
#nullable restore
#line 72 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                                                                               Write(item.Category.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div class=\"text-4 font-size-1 d-inline-block float-right\">");
#nullable restore
#line 73 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                                              Write(item.PublishDateTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <h5 class=\"mt-2\">");
#nullable restore
#line 74 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                    Write(item.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                    </div>\r\n\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
                                                            WriteLiteral(item.NewsId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\Jason Liadi\Desktop\APU Y3S6\DDAC\Assignment\CoinsAge\CoinsAge\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        \r\n    </div>\r\n</div>");
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
