#pragma checksum "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Branch\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41a3a00f9844981cf887f56f645b50a014bef937"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_LibAdmin_Views_Branch_Delete), @"mvc.1.0.view", @"/Areas/LibAdmin/Views/Branch/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41a3a00f9844981cf887f56f645b50a014bef937", @"/Areas/LibAdmin/Views/Branch/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f6c4353c99618323d404a5f02aee4d2d9d40131", @"/Areas/LibAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_LibAdmin_Views_Branch_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Branch>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Branch\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"m-4\">\r\n    <div>\r\n        <h4 class=\"mt-3\">Name</h4>\r\n        <p>");
#nullable restore
#line 9 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Branch\Delete.cshtml"
      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h4 class=\"mt-3\">Location</h4>\r\n        <p>");
#nullable restore
#line 13 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Branch\Delete.cshtml"
      Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h4 class=\"mt-3\">PhoneNumber</h4>\r\n        <p>");
#nullable restore
#line 17 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Branch\Delete.cshtml"
      Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h4 class=\"mt-3\">OfficeNumber</h4>\r\n        <p>");
#nullable restore
#line 21 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Branch\Delete.cshtml"
      Write(Model.OfficeNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div class=\"mt-3\">\r\n        <h4 class=\"mt-3\">Map</h4>\r\n        <p><iframe");
            BeginWriteAttribute("src", " src=\"", 545, "\"", 561, 1);
#nullable restore
#line 25 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Branch\Delete.cshtml"
WriteAttributeValue("", 551, Model.Map, 551, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"500\" height=\"300\" style=\"border:0;\"");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 605, "\"", 623, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe></p>\r\n    </div>\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41a3a00f9844981cf887f56f645b50a014bef9376363", async() => {
                WriteLiteral("\r\n            <button  class=\"btn btn-danger mt-2\">Delete</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Branch> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
