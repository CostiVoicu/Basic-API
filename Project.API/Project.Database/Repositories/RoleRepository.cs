using Project.Database.Context;
using Project.Database.Entities;
using Project.Infrastructure.Exceptions;

namespace Project.Database.Repositories
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(PetShopDbContext petShopDbContext) : base(petShopDbContext)
        {
        }

        public Role GetRoleByName(string name)
        {
            var result = petShopDbContext.Roles
                .Where(e => e.Name == name)
                .FirstOrDefault();

            if (result == null)
                throw new ResourceMissingException("Role not found");

            return result;
        }
    }
}
