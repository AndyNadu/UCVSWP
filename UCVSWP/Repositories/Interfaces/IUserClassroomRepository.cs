using Microsoft.AspNetCore.Identity;
using UCVSWP.Models;

namespace UCVSWP.Repositories.Interfaces
{
    public interface IUserClassroomRepository
    {
        IEnumerable<UserClassroom> GetAll();
        UserClassroom GetByIdWithRelatedEntities(int id);
        UserClassroom GetById(int id);
        IEnumerable<Classroom> GetAllClasses(string UserId);
        IEnumerable<IdentityUser> GetAllUsers(int clsid);
        void Create(UserClassroom entry);
        void Update(UserClassroom entry);
        void Delete(UserClassroom entry);
        void Save();
    }
}
