using HomeControl.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace HomeControl.Components
{
    public class AuthComponentBase : ComponentBase
    {
        [Inject]
        private AuthService AuthService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string AuthToken { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!await AuthService.Auth(AuthToken))
                NavigationManager.NavigateTo("NotAuthorized");

            await base.OnInitializedAsync();
        }
    }
}
