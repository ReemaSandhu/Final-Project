#pragma checksum "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\Home\BookNow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0162521081f76c30e28f0d08b7a9aeaa2db3791"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_BookNow), @"mvc.1.0.view", @"/Views/Home/BookNow.cshtml")]
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
#line 1 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\_ViewImports.cshtml"
using Travel_Booking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\_ViewImports.cshtml"
using Travel_Booking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0162521081f76c30e28f0d08b7a9aeaa2db3791", @"/Views/Home/BookNow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb1b37d1955515d7722a5449540e2259fb941c6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_BookNow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TravelEntities.CustomEntities.CombinedModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 54 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\Home\BookNow.cshtml"
 foreach (var item in (IEnumerable<TravelEntities.CustomEntities.CombinedModel>)TempData["Data"])
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 56 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\Home\BookNow.cshtml"
  Write(item.SearchHotels.CheckIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 57 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\Home\BookNow.cshtml"
  Write(item.SearchHotels.CheckOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 58 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\Home\BookNow.cshtml"
  Write(item.SearchHotels.CityId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 59 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\Home\BookNow.cshtml"
  Write(item.SearchHotels.NoOfPeople);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 60 "E:\.net\Project(travel Booking)\Travel Booking\Travel Booking\Views\Home\BookNow.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TravelEntities.CustomEntities.CombinedModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
