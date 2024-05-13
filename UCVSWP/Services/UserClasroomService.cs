using Microsoft.AspNetCore.Identity;
using UCVSWP.Models;
using UCVSWP.Repositories;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Services
{
    public class UserClasroomService : IUserClassroomService
    {
        private readonly IUserClassroomRepository _userClassroomRepository;
        public UserClasroomService(IUserClassroomRepository userClassroomRepository)
        {
            _userClassroomRepository = userClassroomRepository;
        }
        public List<UserClassroom> GetAllUserClassrooms()
        {
            _userClassroomRepository.GetAll();
            return null;
        }
        public UserClassroom GetUserClassroomtAndRelatedById(int id)
        {
            _userClassroomRepository.GetById(id);
            return null;
        }
        public bool UserClassroomExists(int id)
        {
            return true; // need to change

        }
        public void AddUserClassroom(UserClassroom entry)
        {
            _userClassroomRepository.Create(entry);
            _userClassroomRepository.Save();
        }
        public void UpdateUserClassroom(UserClassroom entry)
        {
            _userClassroomRepository.Update(entry);
            _userClassroomRepository.Save();
        }
        public void DeleteUserClassrooms(int id)
        {
            var usrcls = _userClassroomRepository.GetById(id);
            if (usrcls != null)
            {
                _userClassroomRepository.Delete(usrcls);
                _userClassroomRepository.Save();
            }
        }
        public IEnumerable<Classroom> GetAllClasses(string UserId)
        {
            return _userClassroomRepository.GetAllClasses(UserId);
        }
        public IEnumerable<IdentityUser> GetAllUsers(int clsid)
        {
            return _userClassroomRepository.GetAllUsers(clsid);
        }

    }
}
