using System.Linq;


namespace DataAccessLibrary
{
    public class UserRepository
    {
        private readonly NSC_VraagpunteStelselEntities dbContext;

        public UserRepository()
        {
            dbContext = new NSC_VraagpunteStelselEntities();
        }

        public User GetUserByUsername(string username)
        {
            return dbContext.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User GetUserById(string userId)
        {
            return dbContext.Users.FirstOrDefault(u => u.ID_Number == userId);
        }

        public void AddUser(User user) //For later purposes when we want to add new users
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void DeleteUser(string userId)
        {
            User userToDelete = dbContext.Users.FirstOrDefault(u => u.ID_Number == userId);
            if (userToDelete != null)
            {
                dbContext.Users.Remove(userToDelete);
                dbContext.SaveChanges();
            }
        }
    }
}

