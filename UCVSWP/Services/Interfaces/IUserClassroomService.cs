using Microsoft.AspNetCore.Identity;
using UCVSWP.Models;

namespace UCVSWP.Services.Interfaces
{
    public interface IUserClassroomService
    {
        List<UserClassroom> GetAllUserClassrooms();
        UserClassroom GetUserClassroomtAndRelatedById(int id);
        bool UserClassroomExists(int id);
        void AddUserClassroom(UserClassroom entry);
        void UpdateUserClassroom(UserClassroom entry);
        void DeleteUserClassrooms(int id);
        IEnumerable<Classroom> GetAllClasses(string UserId);
        IEnumerable<IdentityUser> GetAllUsers(int clsid);

    }
}
