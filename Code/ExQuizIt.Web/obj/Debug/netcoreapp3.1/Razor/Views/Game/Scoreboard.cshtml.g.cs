#pragma checksum "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "208894566b6baa5721a1ac370b83f66f82d04fd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Scoreboard), @"mvc.1.0.view", @"/Views/Game/Scoreboard.cshtml")]
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
#line 1 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\_ViewImports.cshtml"
using ExQuizIt.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\_ViewImports.cshtml"
using ExQuizIt.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\_ViewImports.cshtml"
using ExQuizIt.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"208894566b6baa5721a1ac370b83f66f82d04fd2", @"/Views/Game/Scoreboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e10dad5bdd6d5ed3f65fff5e50e73aee3a4c4286", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Scoreboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ExQuizIt.Models.GamePlayer>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Games", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml"
  
	ViewData["Title"] = "Scoreboard";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Scoreboard</h1>\r\n\r\n<table class=\"table\">\r\n\t<thead>\r\n\t\t<tr class=\"table-active\">\r\n\t\t\t<th>\r\n\t\t\t\t");
#nullable restore
#line 14 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml"
           Write(Html.DisplayNameFor(model => model.Player.Displayname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t</th>\r\n\t\t\t<th>\r\n\t\t\t\t");
#nullable restore
#line 17 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml"
           Write(Html.DisplayNameFor(model => model.Score));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n");
#nullable restore
#line 22 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml"
         foreach (var item in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr class=\"table-active\">\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 26 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.Player.Displayname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td>\r\n\t\t\t\t\t");
#nullable restore
#line 29 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml"
               Write(Html.DisplayFor(modelItem => item.Score));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n");
#nullable restore
#line 32 "D:\Documenten\NMCT\Semester_4\Backend Development\QuizProject\ExQuizIt\ExQuizIt.Web\Views\Game\Scoreboard.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n</table>\r\n\r\n<div>\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "208894566b6baa5721a1ac370b83f66f82d04fd26658", async() => {
                WriteLiteral("Back to Games");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ExQuizIt.Models.GamePlayer>> Html { get; private set; }
    }
}
#pragma warning restore 1591