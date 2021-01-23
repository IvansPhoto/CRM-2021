#pragma checksum "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8866356e94c58f61ce0a0c54eb4d15499beb4fc"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorCRM.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using BlazorCRM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\dotNET\CRM-2021\BlazorCRM\_Imports.razor"
using BlazorCRM.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
using BlazorCRM.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
using BlazorCRM.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/users")]
    public partial class Users : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 b-1tksimbofw>Users</h1>\r\n");
            __builder.AddMarkupContent(1, "<p b-1tksimbofw>This component demonstrates fetching data from a service.</p>");
#nullable restore
#line 10 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
 if (_users == null || _isLoading)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p b-1tksimbofw><em b-1tksimbofw>Loading...</em></p>");
#nullable restore
#line 15 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
}
else if (_users.Count == 0)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(3, "<p b-1tksimbofw>There is no user.</p>");
#nullable restore
#line 19 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "id", "UserList");
            __builder.AddAttribute(6, "b-1tksimbofw");
            __builder.AddMarkupContent(7, "<p b-1tksimbofw>Id</p>\r\n\t\t");
            __builder.AddMarkupContent(8, "<p b-1tksimbofw>Name</p>\r\n\t\t");
            __builder.AddMarkupContent(9, "<p b-1tksimbofw>Surname</p>\r\n\t\t");
            __builder.AddMarkupContent(10, "<p b-1tksimbofw>Phone</p>\r\n\t\t");
            __builder.AddMarkupContent(11, "<p b-1tksimbofw>Email</p>");
#nullable restore
#line 28 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
         foreach (var user in _users)
		{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(12, "p");
            __builder.AddAttribute(13, "b-1tksimbofw");
            __builder.AddContent(14, 
#nullable restore
#line 30 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                user.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n\t\t\t");
            __builder.OpenElement(16, "p");
            __builder.AddAttribute(17, "b-1tksimbofw");
            __builder.AddContent(18, 
#nullable restore
#line 31 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                user.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n\t\t\t");
            __builder.OpenElement(20, "p");
            __builder.AddAttribute(21, "b-1tksimbofw");
            __builder.AddContent(22, 
#nullable restore
#line 32 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                user.Surname

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n\t\t\t");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "phone-list");
            __builder.AddAttribute(26, "b-1tksimbofw");
#nullable restore
#line 34 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                 if (user.Phones.Count <= 0)
				{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(27, "p");
            __builder.AddAttribute(28, "b-1tksimbofw");
            __builder.AddContent(29, 
#nullable restore
#line 36 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                        user.Phones.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 37 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
				}
				else
				{
					

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                     foreach (var phone in user.Phones)
					{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(30, "p");
            __builder.AddAttribute(31, "b-1tksimbofw");
            __builder.AddContent(32, 
#nullable restore
#line 42 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                             phone.PhoneNumber ?? "null"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 43 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
					}

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                     
				}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n\t\t\t");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "phone-list");
            __builder.AddAttribute(36, "b-1tksimbofw");
#nullable restore
#line 47 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                 if (user.Emails.Count <= 0)
				{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(37, "p");
            __builder.AddAttribute(38, "b-1tksimbofw");
            __builder.AddContent(39, 
#nullable restore
#line 49 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                        user.Emails.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 50 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
				}
				else
				{
					

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                     foreach (var phone in user.Emails)
					{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(40, "p");
            __builder.AddAttribute(41, "b-1tksimbofw");
            __builder.AddContent(42, 
#nullable restore
#line 55 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                            phone.EmailAddress

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 56 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
					}

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
                     
				}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 59 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
		}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 61 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 63 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Users.razor"
       

	private List<User> _users;
	private bool _isLoading = true;

	protected override async Task OnInitializedAsync()
	{
		_isLoading = true;
	// _users = await UserService.GetUsers();
		_users = await UserService.GetUsersDapper();
		_isLoading = false;
	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserService UserService { get; set; }
    }
}
#pragma warning restore 1591
