#pragma checksum "E:\bookshop-2\bookshop.webui\Views\Publisher\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a805a3d8a4289327285080aa53454993e317fcb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Publisher_List), @"mvc.1.0.view", @"/Views/Publisher/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a805a3d8a4289327285080aa53454993e317fcb3", @"/Views/Publisher/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccc2ae44fcc2ee71314661ba3fa2bcd736a080d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Publisher_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PublisherListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Css", async() => {
                WriteLiteral("\r\n\r\n<link rel=\"stylesheet\" href=\"https://cdn.datatables.net/1.11.5/css/dataTables.bootstrap4.min.css\">\r\n\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script src=""https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js""></script>
<script src=""https://cdn.datatables.net/1.11.5/js/dataTables.bootstrap4.min.js""></script>
<script>
    $(document).ready(function () {
        $('#myTable').DataTable();
    });
</script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 20 "E:\bookshop-2\bookshop.webui\Views\Publisher\List.cshtml"
Write(await Component.InvokeAsync("Publishers"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n            \r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PublisherListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
