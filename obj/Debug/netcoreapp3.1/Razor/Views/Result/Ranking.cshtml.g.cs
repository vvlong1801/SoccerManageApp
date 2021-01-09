#pragma checksum "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac177dee6ef78d4d385b68d7c6dfa6e3b879dee7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Result_Ranking), @"mvc.1.0.view", @"/Views/Result/Ranking.cshtml")]
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
#line 1 "/home/quanbka/SoccerManageApp/Views/_ViewImports.cshtml"
using SoccerManageApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/quanbka/SoccerManageApp/Views/_ViewImports.cshtml"
using SoccerManageApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac177dee6ef78d4d385b68d7c6dfa6e3b879dee7", @"/Views/Result/Ranking.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eeabaf9f8ad7170056c4446b96cf24acfb114dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Result_Ranking : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SoccerManageApp.Dtos.RankingDto>>
    {
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
#nullable restore
#line 4 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
  
    ViewData["Title"]="Details Match";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
  
    int position=1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h3>Ranking</h3>
<table border=""1"" cellpadding=""15"">
    <thead>
        <th>Position</th>
        <th>Team Name</th>
        <th>Match Played</th>
        <th>Win Match</th>
        <th>Draw Match</th>
        <th>Lost Match</th>
        <th>Goal For</th>
        <th>Goal Against</th>
        <th>Point</th>
        
    </thead>
    <tbody>
");
#nullable restore
#line 25 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 28 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
               Write(position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 674, "\"", 718, 2);
            WriteAttributeValue("", 681, "/Team/Details?teamName=", 681, 23, true);
#nullable restore
#line 29 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
WriteAttributeValue("", 704, item.TeamName, 704, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ac177dee6ef78d4d385b68d7c6dfa6e3b879dee74754", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 730, "~/Image/", 730, 8, true);
#nullable restore
#line 29 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
AddHtmlAttributeValue("", 738, item.TeamImage, 738, 15, false);

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
            WriteLiteral(" ");
#nullable restore
#line 29 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
                                                                                                   Write(item.TeamName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\n                <td>");
#nullable restore
#line 30 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
               Write(item.MatchPlayed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 31 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
               Write(item.WinMatch);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 32 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
               Write(item.DrawMatch);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 33 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
               Write(item.LoseMatch);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 34 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
               Write(item.GoalFor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                 <td>");
#nullable restore
#line 35 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
                Write(item.GoalAgainst);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 36 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
               Write(item.Point);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 38 "/home/quanbka/SoccerManageApp/Views/Result/Ranking.cshtml"
             position++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("       \n    </tbody>\n</table>\n<a class=\"btn btn-primary\" href=\"/Match/ListMatches\" >Back</a>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> _signInManage { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SoccerManageApp.Dtos.RankingDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
