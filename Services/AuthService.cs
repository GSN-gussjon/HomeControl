using HomeControl.DBModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeControl.Services
{
    public class AuthService
    {
        private SqlService sqlService;

        public bool IsAuthenticated { get; set; }
        public User LoggedUser { get; set; }

        public AuthService(SqlService sqlServiceq)
        {
            this.sqlService = sqlServiceq;
        }

        public async Task<bool> Auth(string token)
        {
            if (IsAuthenticated)
                return true;

            token = "ADMTok";

            LoggedUser = await sqlService.GetUserByToken(token);
            IsAuthenticated = LoggedUser != null;

            return IsAuthenticated;
        }

        public async Task<bool> Login(string login, string passowrd)
        {
            LoggedUser = await sqlService.GetUserByLoginPassword(login, passowrd);
            IsAuthenticated = LoggedUser != null;

            return IsAuthenticated;
        }
    }
}
