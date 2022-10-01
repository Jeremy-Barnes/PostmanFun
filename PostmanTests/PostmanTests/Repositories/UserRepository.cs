using PostmanTests.Entities;

namespace PostmanTests.Repositories
{
    public class UserRepository
    {
        public static readonly Dictionary<int, User> pretendItsADb = new Dictionary<int, User>();

        public User CreateUser(User user)
        {
            int maxId = pretendItsADb.Keys.OrderBy(id => id).LastOrDefault(0) + 1;
            user.Id = maxId;

            pretendItsADb.Add(maxId, user);
            return user;
        }

        public User? RetrieveUser(int id)
        {
            return pretendItsADb.ContainsKey(id) ? pretendItsADb[id] : null;
        }

        public User UpdateUser(User user)
        {
            pretendItsADb[user.Id] = user;
            return user;
        }

        public void DeleteUser(int id)
        {
            if (pretendItsADb.ContainsKey(id))
            {
                pretendItsADb.Remove(id);
            }
        }

        public List<User> GetAllUsers()
        {
            return pretendItsADb.Values.ToList();
        }
    }
}
