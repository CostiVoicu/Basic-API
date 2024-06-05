using Project.Database.Context;
using Project.Database.Entities;
using Project.Infrastructure.Exceptions;

namespace Project.Database.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(PetShopDbContext petShopDbContext) : base(petShopDbContext)
        {
        }

        public void Add(User user)
        {
            petShopDbContext.Users.Add(user);
            petShopDbContext.SaveChanges();
        }
        public User GetByEmail(string email)
        {
            var result = petShopDbContext.Users

                .Where(e => e.Email == email)

                .FirstOrDefault();

            if (result == null)
                throw new ResourceMissingException("User not found");

            return result;
        }
    }
}
