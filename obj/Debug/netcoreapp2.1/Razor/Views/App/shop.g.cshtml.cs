#pragma checksum "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\App\shop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "193c903a000a58d734595ba2a44969e4dd3608f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_App_shop), @"mvc.1.0.view", @"/Views/App/shop.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/App/shop.cshtml", typeof(AspNetCore.Views_App_shop))]
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
#line 1 "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\_ViewImports.cshtml"
using DutchTreat.Controllers;

#line default
#line hidden
#line 2 "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\_ViewImports.cshtml"
using DutchTreat.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\_ViewImports.cshtml"
using DutchTreat.Data.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"193c903a000a58d734595ba2a44969e4dd3608f1", @"/Views/App/shop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"402ff29ed5304f90d7247425045b59e26db665d3", @"/Views/_ViewImports.cshtml")]
    public class Views_App_shop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 27, true);
            WriteLiteral("\r\n<h1>Shop</h1>\r\n<p>Count: ");
            EndContext();
            BeginContext(57, 13, false);
#line 4 "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\App\shop.cshtml"
     Write(Model.Count());

#line default
#line hidden
            EndContext();
            BeginContext(70, 8, true);
            WriteLiteral("</p>\r\n\r\n");
            EndContext();
#line 6 "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\App\shop.cshtml"
 foreach(var p in Model)
{

#line default
#line hidden
            BeginContext(107, 8, true);
            WriteLiteral("    <li>");
            EndContext();
            BeginContext(116, 7, false);
#line 8 "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\App\shop.cshtml"
   Write(p.Title);

#line default
#line hidden
            EndContext();
            BeginContext(123, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 9 "C:\Users\Riku Das\source\repos\DutchTreat\DutchTreat\Views\App\shop.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
