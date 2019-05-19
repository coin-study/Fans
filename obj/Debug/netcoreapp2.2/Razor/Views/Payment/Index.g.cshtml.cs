#pragma checksum "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1590e7aef96fa4bd1ec3780290a21a70cd224fc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment_Index), @"mvc.1.0.view", @"/Views/Payment/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payment/Index.cshtml", typeof(AspNetCore.Views_Payment_Index))]
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
#line 1 "/Users/jackal/Projects/fans/Views/_ViewImports.cshtml"
using fans;

#line default
#line hidden
#line 2 "/Users/jackal/Projects/fans/Views/_ViewImports.cshtml"
using fans.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1590e7aef96fa4bd1ec3780290a21a70cd224fc8", @"/Views/Payment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59f5af1e23df866fd0786fb46cd36341589c404d", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<fans.Models.Payment.PaymentIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Member", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(49, 616, true);
            WriteLiteral(@"
<div class=""title"">
    <i class=""fas fa-hryvnia""></i>  付款紀錄
</div>

<div class=""content content-bkg table-responsive"">
    <table class=""table table-hover table-sm table-bordered table-striped table-sortable"" id=""userIndexTable"">
        <thead class=""thead-dark"">
            <tr>
                <th>#</th>
                <th>Member</th>
                <th>Club</th>
                <th>Limit</th>
                <th>Amount</th>
                <th>Bank</th>
                <th>Customer</th>
                <th>Confirm</th>
                <th>Paid</th>


            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 25 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
             foreach(var payment in Model.Payments)
            {

#line default
#line hidden
            BeginContext(731, 86, true);
            WriteLiteral("                <tr class=\"userRow\">\n                    <td>\n                        ");
            EndContext();
            BeginContext(818, 10, false);
#line 29 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.Id);

#line default
#line hidden
            EndContext();
            BeginContext(828, 142, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        <!-- <a asp-controller=\"Member\" asp-action=\"Detail\" asp-route-id=\"");
            EndContext();
            BeginContext(971, 16, false);
#line 32 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                                                                                     Write(payment.MemberId);

#line default
#line hidden
            EndContext();
            BeginContext(987, 31, true);
            WriteLiteral("\">\n                            ");
            EndContext();
            BeginContext(1019, 16, false);
#line 33 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                       Write(payment.MemberId);

#line default
#line hidden
            EndContext();
            BeginContext(1035, 58, true);
            WriteLiteral("\n                        </a> -->\n                        ");
            EndContext();
            BeginContext(1093, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1590e7aef96fa4bd1ec3780290a21a70cd224fc85875", async() => {
                BeginContext(1139, 29, true);
                WriteLiteral("\n                            ");
                EndContext();
                BeginContext(1169, 16, false);
#line 36 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                       Write(payment.MemberId);

#line default
#line hidden
                EndContext();
                BeginContext(1185, 25, true);
                WriteLiteral("\n                        ");
                EndContext();
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
            EndContext();
            BeginContext(1214, 76, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
            EndContext();
            BeginContext(1291, 16, false);
#line 40 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.ClubName);

#line default
#line hidden
            EndContext();
            BeginContext(1307, 76, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
            EndContext();
            BeginContext(1384, 13, false);
#line 43 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.Limit);

#line default
#line hidden
            EndContext();
            BeginContext(1397, 76, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
            EndContext();
            BeginContext(1474, 14, false);
#line 46 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(1488, 76, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
            EndContext();
            BeginContext(1565, 19, false);
#line 49 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.PaymentBank);

#line default
#line hidden
            EndContext();
            BeginContext(1584, 76, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
            EndContext();
            BeginContext(1661, 23, false);
#line 52 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.PaymentCustomer);

#line default
#line hidden
            EndContext();
            BeginContext(1684, 76, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
            EndContext();
            BeginContext(1761, 22, false);
#line 55 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.PaymentConfirm);

#line default
#line hidden
            EndContext();
            BeginContext(1783, 76, true);
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
            EndContext();
            BeginContext(1860, 12, false);
#line 58 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
                   Write(payment.Paid);

#line default
#line hidden
            EndContext();
            BeginContext(1872, 51, true);
            WriteLiteral("\n                    </td>\n\n\n                </tr>\n");
            EndContext();
#line 63 "/Users/jackal/Projects/fans/Views/Payment/Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1937, 36, true);
            WriteLiteral("        </tbody>\n    </table>\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<fans.Models.Payment.PaymentIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
