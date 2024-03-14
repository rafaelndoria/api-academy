using Academy.Domain.Validations;

namespace Academy.Domain.Entities
{
    public class Payment : Entity
    {
        public Payment(double value, int typePaymentId)
        {
            ValidateDomain(DateTime.Now, value, typePaymentId);
            
            Value = value;
            TypePaymentId = typePaymentId;

            DatePayment = DateTime.Now;
        }

        public Payment(DateTime datePayment, double value, int typePaymentId)
        {
            DatePayment = datePayment;
            Value = value;
            TypePaymentId = typePaymentId;
        }

        public DateTime DatePayment { get; private set; }
        public double Value { get; private set; }

        public int TypePaymentId { get; set; }
        public TypePayment? TypePayment { get; set; }

        private void ValidateDomain(DateTime datePayment, double value, int typePaymentId)
        {
            DomainExceptionValidation.When(datePayment == null || datePayment == DateTime.MinValue, "Invalid datePayment. DatePayment is required");

            DomainExceptionValidation.When(value == 0, "Invalid value. Value is required");

            DomainExceptionValidation.When(typePaymentId == 0, "Invalid typePaymentId. TypePaymentId is required");
        }
    }
}