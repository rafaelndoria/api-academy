using Academy.Domain.Entities;
using Academy.Domain.Enums;

namespace Academy.Tests.Entities
{
    public class SubscriptionTest
    {
        [Fact]
        public void ShouldStartSubscription_StartSubscription_ValidSubscription()
        {
            // Arrange
            var dayNow = DateTime.Now;
            var customerId = 1;
            var planId = 1;

            // Act
            var subscription = new Subscription(dayNow, customerId, 1, planId);

            // Assert
            Assert.NotNull(subscription.AccessPermittedUntil);
        }

        [Fact]
        public void ShouldValidateAcess_ValidateAccess_NotBlokedSubscription()
        {
            // Arrange
            var dayNow = DateTime.Now;
            var customerId = 1;
            var planId = 1;

            // Act
            var subscription = new Subscription(dayNow, customerId, 1, planId);
            var oldStatus = subscription.Status;
            subscription.VerifyAccess();
            var newStatus = subscription.Status;

            // Assert
            Assert.Equal(oldStatus, newStatus);
        }

        [Fact]
        public void ShouldValidateAccess_ValidateAccessUnathourized_BlokedSubscription()
        {
            // Arrange
            var dayNow = DateTime.Now.AddYears(-1);
            var customerId = 1;
            var planId = 1;

            // Act
            var subscription = new Subscription(dayNow, customerId, 1, planId);
            subscription.VerifyAccess();
            var newStatus = subscription.Status;

            // Assert
            Assert.Equal(newStatus, (int)EStatusSubscription.Blocked);
        }

        [Fact]
        public void ShouldRenewSubscriptionAddingDays_RenewSubscriptionLessDate_ValidSubscription()
        {
            // Arrange
            var dayNextMonth = DateTime.Now.AddMonths(2);
            var planId = 1;
            var customerId = 1;

            // Act
            var subscription = new Subscription(dayNextMonth, customerId, 1, planId);
            subscription.RenewSubscription(1);
            var newDayCompare = DateTime.Now.AddMonths(1);

            // Assert
            Assert.NotEqual(subscription.AccessPermittedUntil, newDayCompare);
        }

        [Fact]
        public void ShouldRenewSubscriptionWithoutAddingDays_RenewSubscriptionSameDate_ValidSubscription()
        {
            // Arrange
            var previousMonth = DateTime.Now.AddMonths(-2);
            var plandId = 1;
            var customerId = 1;
            var monthAdded = 1;

            // Act
            var subscription = new Subscription(previousMonth, customerId, 1, plandId);
            subscription.RenewSubscription(monthAdded);
            var newDate = subscription.AccessPermittedUntil.Value.Date;

            // Assert
            Assert.Equal(newDate, DateTime.Now.Date.AddMonths(monthAdded));
        }

        [Fact]
        public void ShouldNotUpdatePlanWithSubscriptionActive_UpdatePlan_ValidUpdate()
        {
            // Arrange
            var currentDay = DateTime.Now;
            var planId = 1;
            var customerId = 1;

            // Act & Assert
            Assert.Throws<Exception>(() =>
            {
                // Act
                var subscription = new Subscription(currentDay, customerId, 1, planId);
                subscription.UpdatePlan(1, 1);
            });
        }

        [Fact]
        public void ShouldUpdatePlanWithSubscriptionInative_UpdatePlan_ValidUpdate()
        {
            // Arrange
            var currentDay = DateTime.Now;
            var planId = 1;
            var customerId = 1;

            // Act
            var subscription = new Subscription(currentDay, customerId, 1, planId);
            var oldSubscription = subscription.AccessPermittedUntil;
            subscription.EndSubscription();
            subscription.UpdatePlan(2, 1);
            var newSubscription = subscription.AccessPermittedUntil;

            // Assert
            Assert.NotEqual(oldSubscription, newSubscription);
            Assert.Equal(subscription.Status, (int)EStatusSubscription.Active);
        }
    }
}
