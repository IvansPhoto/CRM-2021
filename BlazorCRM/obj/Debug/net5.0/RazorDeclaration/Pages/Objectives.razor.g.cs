// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 2 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Objectives.razor"
using BlazorCRM.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Objectives.razor"
using BlazorCRM.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/objectives")]
    public partial class Objectives : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 86 "D:\dotNET\CRM-2021\BlazorCRM\Pages\Objectives.razor"
       
	private bool _isLoading;
	private List<Objective> _objectives;
	private Objective _newObjective;
	
	protected override async Task OnInitializedAsync()
	{
		_isLoading = true;
		_objectives = await ObjectiveService.GetObjectives();
		_newObjective = ObjectiveService.NewObjective;
		_newObjective.ResponsibleUser = await UserService.GetUserEntity(1);
		_isLoading = false;
	}

	private async void SaveObjective()
	{
		await ObjectiveService.SaveObjective(_newObjective);
	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserService UserService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IObjectiveService ObjectiveService { get; set; }
    }
}
#pragma warning restore 1591
