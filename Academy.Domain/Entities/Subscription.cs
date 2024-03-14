using Academy.Domain.Enums;
using Academy.Domain.Validations;

namespace Academy.Domain.Entities
{
    public class Subscription : Entity
    {
        public Subscription(DateTime dateSubscription, int customerId, int planId)
        {
            ValidateDomain(dateSubscription, customerId, planId);

            DateSubscription = dateSubscription;
            CustomerId = customerId;
            PlanId = planId;

            Status = (int)EStatusSubscription.Inactive;
        }

        public DateTime DateSubscription { get; private set; }
        public int Status { get; private set; }
        public DateTime? AccessPermittedUntil { get; private set; }  

        public int CustomerId { get; set; }      
        public Customer? Customer { get; set; }
        public int PlanId { get; set; }
        public Plan? Plan { get; set; }

        public void StartSubscription(EPlanType periodInMonths)
        {
            AccessPermittedUntil = DateSubscription.AddMonths((int)periodInMonths);
            Status = (int)EStatusSubscription.Active;
        }

        public void EndSubscription()
        {
            Status = (int)EStatusSubscription.Blocked;
            AccessPermittedUntil = null;
        }

        public void BlockSubscription()
        {
            Status = (int)EStatusSubscription.Blocked;
        }

        public void RenewSubscription(EPlanType periodInMonths)
        {
            DateTime dayNow = DateTime.Now;
            int addDaysSubscription = 0;

            if (AccessPermittedUntil != null && dayNow < AccessPermittedUntil)
                addDaysSubscription = (int)(AccessPermittedUntil - dayNow).Value.TotalDays;

            AccessPermittedUntil = dayNow.AddDays(addDaysSubscription).AddMonths((int)periodInMonths);
            Status = (int)EStatusSubscription.Active;
        }

        public void VerifyAccess()
        {
            if (AccessPermittedUntil == null)
               EndSubscription();

            if (DateTime.Now > AccessPermittedUntil)
                EndSubscription();
        }

        private void ValidateDomain(DateTime dateSubscription, int customerId, int planId)
        {
            DomainExceptionValidation.When(dateSubscription == null || dateSubscription == DateTime.MinValue, "Invalid dateSubscription. DateSubscription is required");

            DomainExceptionValidation.When(customerId == 0, "Invalid customerId. CustomerId is required");

            DomainExceptionValidation.When(planId == 0, "Invalid planId. PlanId is required");
        }
    }
}