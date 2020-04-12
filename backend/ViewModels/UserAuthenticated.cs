using backend.Models;

namespace backend.ViewModels
{
    public class UserAuthenticated
    {
        public UserAuthenticated(Ong ong, string token)
        {
            Ong = ong;
            Token = token;
        }

        public Ong Ong { get; private set; }
        public string Token { get; private set; }
    }
}