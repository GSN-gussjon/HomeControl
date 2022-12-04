using Blazored.LocalStorage;
using HomeControl.DBModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeControl.Services
{
    public class AuthService
    {
        private SqlService sqlService;
        private ISyncLocalStorageService localStorage;
        private NavigationManager navigationManager;

        public bool IsAuthenticated { get; set; }
        public User LoggedUser { get; set; }

        public AuthService(SqlService sqlServiceq, ISyncLocalStorageService localStorage, NavigationManager navigationManager)
        {
            this.sqlService = sqlServiceq;
            this.localStorage = localStorage;
            this.navigationManager = navigationManager;
        }

        public async Task<bool> Auth(string token)
        {
            if (IsAuthenticated)
                return true;

            LoggedUser = await sqlService.GetUserByToken(token);
            IsAuthenticated = LoggedUser != null;

            return IsAuthenticated;
        }

        public async Task<bool> Login(string login, string passowrd, bool remember = false)
        {
            LoggedUser = await sqlService.GetUserByLoginPassword(login, passowrd);
            IsAuthenticated = LoggedUser != null;

            if (IsAuthenticated && remember)
                localStorage.SetItem("user", LoggedUser);

            return IsAuthenticated;
        }

        public bool CheckLogin()
        {
            LoggedUser = localStorage.GetItem<User>("user");
            IsAuthenticated = LoggedUser != null;

            return IsAuthenticated;
        }

        public void Logout()
        {
            localStorage.RemoveItem("user");
            navigationManager.NavigateTo("login");
        }
    }
}
