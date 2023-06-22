using DataAccessLibrary;

namespace MarkCapturingSystem.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository userRepository;

        public AuthenticationService()
        {
            userRepository = new UserRepository();
        }

        public bool AuthenticateUser(string username, string password)
        {
            // Logic to validate user credentials against the stored data in our database
            User user = userRepository.GetUserByUsername(username);

            if (user != null && user.Password == password)
            {
                return true;
            }

            return false;
        }
    }
}

