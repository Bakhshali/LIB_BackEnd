#pragma checksum "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7da784d36369e22c4cae3177e0c3d19ce3db3e9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_LibAdmin_Views_Slider_Delete), @"mvc.1.0.view", @"/Areas/LibAdmin/Views/Slider/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7da784d36369e22c4cae3177e0c3d19ce3db3e9e", @"/Areas/LibAdmin/Views/Slider/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f6c4353c99618323d404a5f02aee4d2d9d40131", @"/Areas/LibAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_LibAdmin_Views_Slider_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Slider>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:400px;height:250px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"m-4\">\r\n    <div>\r\n        <h4 >Image</h4>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7da784d36369e22c4cae3177e0c3d19ce3db3e9e4706", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 167, "~/assets/img/slider/", 167, 20, true);
#nullable restore
#line 10 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
AddHtmlAttributeValue("", 187, Model.Image, 187, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        <h4 class=\"mt-3\">Title</h4>\r\n        <p>");
#nullable restore
#line 14 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
      Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        <h4>");
#nullable restore
#line 17 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
             if(@Model.Subtitle==null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
            Write(" ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
                      
                ;
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
            Write("Subtitle");

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
                             ;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </h4>\r\n        <p>");
#nullable restore
#line 27 "C:\Users\Ali\source\repos\LIBSchool_FinalProjectBackEnd\LIBSchool_FinalProjectBackEnd\Areas\LibAdmin\Views\Slider\Delete.cshtml"
      Write(Model.Subtitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da784d36369e22c4cae3177e0c3d19ce3db3e9e8422", async() => {
                WriteLiteral("\r\n            <button  class=\"btn btn-danger mt-2\">Delete</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Slider> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
