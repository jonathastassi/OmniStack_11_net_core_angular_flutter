namespace backend.Dtos
{
    public class OngLogin
    {
        public OngLogin(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}