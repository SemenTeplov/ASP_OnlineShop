using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class UsersManager : IUsersManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return users;
        }
        public void Add(UserAccount user)
        {
            users.Add(user);
        }
        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.UserName == name);
        }
        public void ChangePassword(string name, string password)
        {
            var account = TryGetByName(name);
            account.Password = password;
        }
    }
}
