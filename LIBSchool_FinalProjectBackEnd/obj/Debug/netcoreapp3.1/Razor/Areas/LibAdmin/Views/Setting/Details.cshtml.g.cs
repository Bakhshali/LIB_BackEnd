#pragma checksum "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "341815715ff74b7e9bdf54126ec69fdf6a1b1b34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_LibAdmin_Views_Setting_Details), @"mvc.1.0.view", @"/Areas/LibAdmin/Views/Setting/Details.cshtml")]
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
#line 3 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\_ViewImports.cshtml"
using LIBSchool_FinalProjectBackEnd.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\_ViewImports.cshtml"
using LIBSchool_FinalProjectBackEnd.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"341815715ff74b7e9bdf54126ec69fdf6a1b1b34", @"/Areas/LibAdmin/Views/Setting/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f6c4353c99618323d404a5f02aee4d2d9d40131", @"/Areas/LibAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_LibAdmin_Views_Setting_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Setting>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "setting", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success mt-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"m-4\">\r\n    <div>\r\n        <h4 class=\"mt-3\">Key</h4>\r\n        <p>");
#nullable restore
#line 13 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
      Write(Model.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        <h4 class=\"mt-3\">Value</h4>\r\n        <p>\r\n            ");
#nullable restore
#line 18 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
       Write(Model.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div>\r\n        <h4>\r\n");
#nullable restore
#line 23 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
             if (@Model.URL == null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
            Write(" ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
                      
                ;
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
            Write("URL");

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
                        
                ;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </h4>\r\n        <p>");
#nullable restore
#line 34 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Setting\Details.cshtml"
      Write(Model.URL);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "341815715ff74b7e9bdf54126ec69fdf6a1b1b347402", async() => {
                WriteLiteral("Geri");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Setting> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
