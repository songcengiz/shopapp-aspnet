#pragma checksum "E:\bookshop-2\bookshop.webui\Views\Home\GetProductsFromRestApi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b05e0379df22b45e01da2bd680d585bb89b40a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetProductsFromRestApi), @"mvc.1.0.view", @"/Views/Home/GetProductsFromRestApi.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b05e0379df22b45e01da2bd680d585bb89b40a7", @"/Views/Home/GetProductsFromRestApi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccc2ae44fcc2ee71314661ba3fa2bcd736a080d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetProductsFromRestApi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\bookshop-2\bookshop.webui\Views\Home\GetProductsFromRestApi.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <p>");
#nullable restore
#line 5 "E:\bookshop-2\bookshop.webui\Views\Home\GetProductsFromRestApi.cshtml"
          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>");
#nullable restore
#line 6 "E:\bookshop-2\bookshop.webui\Views\Home\GetProductsFromRestApi.cshtml"
          Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 8 "E:\bookshop-2\bookshop.webui\Views\Home\GetProductsFromRestApi.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
