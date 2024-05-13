using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;

namespace UCVSWP.Repositories
{
    public class UserClassroomRepository : IUserClassroomRepository
    {
        private readonly UCVSWPContext _context;

        public UserClassroomRepository(UCVSWPContext context)
        {
            _context = context;

        }
        public void Create(UserClassroom entry)
        {
            _context.UserClassroom.Add(entry);
        }

        public void Delete(UserClassroom entry)
        {
            _context.Remove(entry);
        }

        public IEnumerable<UserClassroom> GetAll()
        {
            return _context.UserClassroom.Include(p => p.User).Include(p => p.Classroom).ToList();
        } 
        public UserClassroom GetById(int id)
        {
            return _context.UserClassroom.Find(id);
        }

        public UserClassroom GetByIdWithRelatedEntities(int id)
        {
            return _context.UserClassroom.Include(p => p.User).Include(p => p.Classroom).FirstOrDefault(p => p.UserClassroomId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(UserClassroom entry)
        {
            _context.Update(entry);
        }

        public IEnumerable<Classroom> GetAllClasses(string UserId)
        {
            var classrooms = _context.Classroom
            .Join(_context.UserClassroom,
                c => c.ClassroomID,
                uc => uc.ClassroomID,
                (c, uc) => new { Classroom = c, UserClassroom = uc })
            .Where(joined => joined.UserClassroom.UserId == UserId)
            .Select(joined => joined.Classroom)
            .ToList();

            return classrooms;
        }

        public IEnumerable<IdentityUser> GetAllUsers(int clsid)
        {
            var users = _context.Users
            .Join(_context.UserClassroom,
                u => u.Id,
                uc => uc.UserId,
                (u, uc) => new { User = u, UserClassroom = uc })
            .Where(joined => joined.UserClassroom.ClassroomID == clsid)
            .Select(joined => joined.User)
            .ToList();

            return users;
        }
    }
}
