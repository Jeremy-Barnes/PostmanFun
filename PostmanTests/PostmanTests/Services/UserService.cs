using PostmanTests.Entities;
using PostmanTests.Repositories;

namespace PostmanTests.Services
{
    public class UserService
    {
        private UserRepository userRepo;
        public UserService(UserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public User CreateUser(User user)
        {
            if(user == null)
            {
                throw new BadHttpRequestException("User must not be null");
            }
            return userRepo.CreateUser(user);
        }

        public User UpdateUser(User user)
        {
            if (user == null)
            {
                throw new BadHttpRequestException("User must not be null");
            }
            if (user.Id < 1)
            {
                throw new BadHttpRequestException("User must already exist to be updated");
            }
            return userRepo.UpdateUser(user);
        }

        public User GetUser(int id)
        {
            return userRepo.RetrieveUser(id);
        }

        public void DeleteUser(int id)
        {
            userRepo.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return userRepo.GetAllUsers();
        }

    }
}
