#pragma checksum "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c7f973322c7ec85111b11b72c210c9344757c32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Publisher_Details), @"mvc.1.0.view", @"/Views/Publisher/Details.cshtml")]
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
#line 3 "E:\bookshop-2\bookshop.webui\Views\_ViewImports.cshtml"
using bookshop.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\bookshop-2\bookshop.webui\Views\_ViewImports.cshtml"
using bookshop.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\bookshop-2\bookshop.webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\bookshop-2\bookshop.webui\Views\_ViewImports.cshtml"
using bookshop.webui.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\bookshop-2\bookshop.webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\bookshop-2\bookshop.webui\Views\_ViewImports.cshtml"
using bookshop.webui.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c7f973322c7ec85111b11b72c210c9344757c32", @"/Views/Publisher/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccc2ae44fcc2ee71314661ba3fa2bcd736a080d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Publisher_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PublisherDetailModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<div class=\"row \">\r\n\r\n\r\n\r\n\r\n    <div class=\"col-md-6\">\r\n\r\n\r\n        <h1 class=\"mb-3\">");
#nullable restore
#line 13 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
                    Write(Model.Publisher.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c7f973322c7ec85111b11b72c210c9344757c324769", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 159, "~/logo/", 159, 7, true);
#nullable restore
#line 13 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
AddHtmlAttributeValue("", 166, Model.Publisher.ImageLogo, 166, 26, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span></h1>\r\n\r\n        <hr>\r\n        <div class=\"attributes\">\r\n            <table style=\"width: 100%;\">\r\n\r\n                <tr>\r\n                    <td>Appellation:</td>\r\n                    <td>");
#nullable restore
#line 22 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
                   Write(Model.Publisher.Appellation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Email:</td>\r\n                    <td>");
#nullable restore
#line 26 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
                   Write(Model.Publisher.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Phone:</td>\r\n                    <td>");
#nullable restore
#line 30 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
                   Write(Model.Publisher.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>Website:</td>\r\n                    <td>");
#nullable restore
#line 35 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
                   Write(Model.Publisher.Website);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>Address:</td>\r\n                    <td>");
#nullable restore
#line 40 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
                   Write(Model.Publisher.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n\r\n\r\n\r\n\r\n            </table>\r\n        </div>\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-md-6 p-3 mt-5 \" style=\"  text-align: justify\">\r\n                ");
#nullable restore
#line 51 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
           Write(Html.Raw(Model.Publisher.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"col-md-6\">\r\n        <div class=\"row\">\r\n\r\n");
#nullable restore
#line 61 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
             foreach (var product in Model.Products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4 mt-3\">\r\n                    ");
#nullable restore
#line 64 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"
               Write(await Html.PartialAsync("_product",product));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n");
#nullable restore
#line 67 "E:\bookshop-2\bookshop.webui\Views\Publisher\Details.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PublisherDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
