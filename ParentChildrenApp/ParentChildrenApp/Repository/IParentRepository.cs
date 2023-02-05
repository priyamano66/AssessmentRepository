using System.Threading.Tasks;
using ParentChildrenApp.Models;
using ParentChildrenApp.Models.DTO;

namespace ParentChildrenApp.Repository
{
    public interface IParentRepository
    {
        ParentDTO GetUser(string username);
        bool CreateUser(ParentRegistrationModel smodel);
        bool UpdateUser(ParentDTO smodel);
        ParentDTO GetUserByID(int id);
    }
}
