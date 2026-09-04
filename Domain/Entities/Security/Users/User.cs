using Domain.Entities.Security.Roles;
using Domain.ValueObjects;
using System.Xml.Linq;


namespace Domain.Entities.Security.Users

{
    public class User
    {
        public User()
        {
        }

        public User(UserId id, string name, string fistLastName, string secondLastName, Email email, List<Role>? roles, string userName, Password? password, DateTime registrationDate, bool isActive)
        {
            Id = id;
            Name = name;
            FistLastName = fistLastName;
            SecondLastName = secondLastName;
            Email = email;
            Roles = roles;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
            IsActive = isActive;
        }

        public UserId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string FistLastName { get; private set; }
        public string SecondLastName { get; private set; }
        public Email Email { get; private set; }
        public List<Role> Roles { get; private set; }
        public string UserName { get; private set; } = string.Empty;
        public Password? Password { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool IsActive { get; private set; }



        public void AssignRole(Role role) {
            if (!Roles.Contains(role))
            {
                Roles.Add(role);
            }
        }

        public void RemoveRole(Role role)
        {
            if (!Roles.Contains(role))
            {
                Roles.Remove(role);
            }
        }

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }

        public static User UpdateUser(UserId id, string name, string fistLastName, string secondLastName, Email email, List<Role>? roles, string userName, Password? password)
        {
            return new User{Id=id, 
                Name=name, 
                FistLastName= fistLastName, 
                SecondLastName= secondLastName, 
                Email=email, 
                Roles=roles, 
                UserName=userName,
                Password=password 
                };
        }
    }
}
