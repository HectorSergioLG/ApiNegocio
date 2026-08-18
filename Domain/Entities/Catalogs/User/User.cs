using Domain.ValueObjects;

namespace Domain.Entities.Catalogs.User

{
    public class User
    {
        public UserId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string FistLastName { get; private set; }
        public string SecondLastName { get; private set; }
        public Email Email { get; private set; }
        //public Role RoleUser { get; private set; }
        public string UserName { get; private set; } = string.Empty;
        public Password? Password { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool Active { get; private set; }
    }
}
