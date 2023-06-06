using OnlineShopWebApp.Models;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class RolesRepository : IRolesRepository
    {
        private readonly List<Role> roles = new List<Role>();

        public List<Role> GetAll() 
        {
            return roles;
        }
        public Role TryGetByName(string name) 
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }
        public void Add(Role newRole) 
        {
            roles.Add(newRole);
        }
        public void Remove(string name) 
        {
            roles.RemoveAll(x => x.Name == name);
        }
    }
}
