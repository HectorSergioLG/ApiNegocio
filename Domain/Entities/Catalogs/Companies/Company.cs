using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Catalogs.Companies
{
    public class Company : AggregateRoot
    {
        public CompanyId Id { get; private set; }
        public string Name { get; private set; }
        public string TradeName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public bool IsActive { get; private set; } = true;

        public Company(CompanyId id, string name, bool isActive, string tradeName, Email email, PhoneNumber phoneNumber)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            TradeName = tradeName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public static Company Update(Guid id, string name, bool isActive, string tradeName, Email email, PhoneNumber phoneNumber)
        {
            return new Company(new CompanyId(id), name, isActive, tradeName, email, phoneNumber);
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
