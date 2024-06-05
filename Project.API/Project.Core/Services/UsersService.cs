using Project.Database.Dtos.Request;
using Project.Database.Entities;
using Project.Database.Repositories;

namespace Project.Core.Services
{
    public class UsersService
    {
        public AuthService authService { get; set; }
        public UsersRepository usersRepository { get; set; }
        public RoleRepository roleRepository { get; set; }
        public UsersService(
            AuthService authService,
            UsersRepository usersRepository,
            RoleRepository roleRepository)
        {
            this.authService = authService;
            this.usersRepository = usersRepository;
            this.roleRepository = roleRepository;
        }
        public void Register(RegisterRequest registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var user = new User();
            user.FirstName = registerData.FirstName;
            user.LastName = registerData.LastName;
            user.Email = registerData.Email;
            user.Password = registerData.Password;
            
            if (GetRole(user) == "Admin")
            {
                user.AssignedRole = roleRepository.GetRoleByName("Admin");
            }
            else
            {
                user.AssignedRole = roleRepository.GetRoleByName("User");
            }

            usersRepository.Add(user);
        }

        public string Login(LoginRequest payload)
        {
            var user = usersRepository.GetByEmail(payload.Email);

            if (payload.Password == user.Password)
            {
                var role = GetRole(user);

                return authService.GetToken(user, role);
            }
            else
            {
                return null;
            }
        }

        public string LoginAdmin(LoginRequest payload)
        {
            var user = usersRepository.GetByEmail(payload.Email);
            var role = GetRole(user);

            if (payload.Password == user.Password && role == "Admin")
            {

                return authService.GetToken(user, role);
            }
            else
            {
                return null;
            }
        }

        private string GetRole(User user)
        {
            if (user.Email.EndsWith("@petshop.com"))
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }
    }
}
