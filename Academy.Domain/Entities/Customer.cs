using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Academy.Domain.Validations;

namespace Academy.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {

        }

        public Customer(string name, string phoneNumber, string email, string cpf, int planId)
        {
            ValidateDomain(name, phoneNumber, email, cpf, planId);

            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            CPF = cpf;
            PlanId = planId;

            Active = true;
            DateCreated = DateTime.Now;
        }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }

        public int PlanId { get; set; }
        public Plan? Plan { get; set; }
        [JsonIgnore]
        public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        [JsonIgnore]
        public IEnumerable<Entry> Entries { get; set; } = new List<Entry>();

        public void Inactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }

        private void ValidateDomain(string name, string phoneNumber, string email, string cpf, int planId)
        {
            if (Name != name)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
                DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name must have at least 3 characters");
                DomainExceptionValidation.When(name.Length > 50, "Invalid name. Name must have a maximum of 50 characters");
            }
            if (PhoneNumber != phoneNumber)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), "Invalid phone number. Phone number is required");
                DomainExceptionValidation.When(phoneNumber.Length != 11, "Invalid phone number. Phone number must have a 11 characters");
            }
            if (Email != email)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Invalid email. Email is required");
                DomainExceptionValidation.When(email.Length > 150, "Invalid email. Email must have a maximum of 150 characters");
                DomainExceptionValidation.When(!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"), "Invalid email. Email is invalid");
            }
            if (CPF != cpf)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "Invalid CPF. CPF is required");
                DomainExceptionValidation.When(cpf.Length != 11, "Invalid CPF. CPF must have a 11 characters");
            }
            if (PlanId != planId || planId <= 0)
            {
                DomainExceptionValidation.When(planId <= 0, "Invalid planId. PlanId is required");
            }
        }

        public void Update(string name, string phoneNumber, string email, string cpf, int planId)
        {
            ValidateDomain(name, phoneNumber, email, cpf, planId);

            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            CPF = cpf;
            PlanId = planId;
        }
    }
}