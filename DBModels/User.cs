namespace HomeControl.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public int PermissionsLevel { get; set; }
        public string Password { get; set; }
    }
}
