#pragma checksum "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6b9abe5c8d4314fbb91348cf15a73a8a3b93e27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Odjeljenje_PrikaziUcenikeUOdjeljenju), @"mvc.1.0.view", @"/Views/Odjeljenje/PrikaziUcenikeUOdjeljenju.cshtml")]
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
#line 1 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\_ViewImports.cshtml"
using eDnevnik;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\_ViewImports.cshtml"
using eDnevnik.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
using eDnevnik.data.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6b9abe5c8d4314fbb91348cf15a73a8a3b93e27", @"/Views/Odjeljenje/PrikaziUcenikeUOdjeljenju.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2deba05c37979eb846c6c0a8909099215cb7c18c", @"/Views/_ViewImports.cshtml")]
    public class Views_Odjeljenje_PrikaziUcenikeUOdjeljenju : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PrikaziUcenikeUOdjeljenjuVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
  
    ViewData["Title"] = "PrikaziUcenikeUOdjeljenju";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"

<div class=""row"">
    <table id=""myTable"" class=""table"" style=""text-align:center; "">
        <thead class=""thead-dark"">
            <tr>
                <th>Ime i prezime</th>
                <th>Ime roditelja</th>
                <th>Odjeljenje</th>
                <th>Broj u dnevniku</th>
                <th>Zakljucna ocjena</th>
                <th>Akcija</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 25 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
             foreach (var x in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 28 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
                   Write(x.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 28 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
                          Write(x.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
                   Write(x.ImeRoditelja);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
                   Write(x.Odjeljenje);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
                   Write(x.BrojUDnevniku);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
                    Write(x.ZakljucnaOcjena);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1143, "\"", 1245, 4);
            WriteAttributeValue("", 1150, "/Odjeljenje/ZakljuciOcjenu/?ucenikID=", 1150, 37, true);
#nullable restore
#line 34 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
WriteAttributeValue("", 1187, x.UceniciOdjeljenjeID, 1187, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1209, "&predavacId=", 1209, 12, true);
#nullable restore
#line 34 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
WriteAttributeValue("", 1221, x.PredavaciOdjeljenjeID, 1221, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Zaključi ocjenu</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 37 "C:\Users\Kenan\Source\Repos\webapp\eDnevnik\eDnevnik\Views\Odjeljenje\PrikaziUcenikeUOdjeljenju.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PrikaziUcenikeUOdjeljenjuVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591