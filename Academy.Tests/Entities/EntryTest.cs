using Academy.Domain.Entities;

namespace Academy.Tests.Entities
{
    public class EntryTest
    {
        [Fact]
        public void Entry_WhenDateIsValid_NotThrowsException()
        {
            // Arrange
            var date = DateTime.Now;
            var timeIn = "08:00";
            var timeOn = "12:00";
            var customerId = 1;

            // Act
            var entry = new Entry(date, timeIn, customerId);
            entry.SetTimeOn(timeOn);

            // Assert
            Assert.Equal(entry.TimeOn, timeOn);
        }

        [Fact]
        public void Entry_WhenDateIsInvalid_ThrowsException()
        {
            // Arrange
            var date = DateTime.Now;
            var timeIn = "08:00";
            var timeOn = "test";
            var customerId = 1;

            // Act & Assert
            Assert.Throws<Exception>(() => 
            {
                // Act
                var entry = new Entry(date, timeIn, customerId);
                entry.SetTimeOn(timeOn);
            });
        }

        [Fact]
        public void Entry_WhenTimeOnIsLessThanTimeIn_ThrowsException()
        {
            // Arrange
            var date = DateTime.Now;
            var timeIn = "08:00";
            var timeOn = "07:00";
            var customerId = 1;

            // Act & Assert
            Assert.Throws<Exception>(() => 
            {
                // Act
                var entry = new Entry(date, timeIn, customerId);
                entry.SetTimeOn(timeOn);
            });
        }
    }
}