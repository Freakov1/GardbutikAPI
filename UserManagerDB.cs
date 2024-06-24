using GårdbutikAPI.Models;

namespace GårdbutikAPI.Managers
{
    public class UserManagerDB
    {
        private GårdbutikContext _context;

        public UserManagerDB(GårdbutikContext context)
        {
            _context = context;
        }

        //Returns all users as a IEnumerable//
        public IEnumerable<User> GetAll()
        {
            return _context.users;
        }

        //Add a user to the DB//
        public User Add(User newuser)
        {
            _context.users.Add(newuser);
            _context.SaveChanges();
            return newuser;
        }

        public User? GetById(int Id)
        {
            return _context.users.FirstOrDefault(user => user.Id == Id);
        }

        public User? Delete(int Id)
        {
            User? founduser = GetById(Id);

            if (founduser != null)
            {
                _context.users.Remove(founduser);
                _context.SaveChanges();
            }
            return founduser;
        }

        public User? Update(int Id, User updates)
        {
            User userToBeUpdated = GetById(Id);
            userToBeUpdated.username = updates.username;
            userToBeUpdated.password = updates.password;
            userToBeUpdated.farm = updates.farm;

            _context.SaveChanges();

            return userToBeUpdated;
        }
    }
}
