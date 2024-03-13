namespace Academy.Domain.Entities
{
    public class Payment : Entity
    {
        public Payment(double value, int typePaymentId)
        {
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
    }
}