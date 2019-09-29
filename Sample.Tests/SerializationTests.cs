using System;
using System.Text.Json;
using NUnit.Framework;
using Sample.Contracts;

namespace Sample.Tests
{
    public class Tests
    {
        private JsonSerializerOptions _options;

        [SetUp]
        public void Setup()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new Serialization.SnakeCaseNamingPolicy()
            };
        }

        [Test]
        public void CanSerializeObjectToJson()
        {
            var booking = new Booking
            {
                BookingDate = new DateTimeOffset(2019, 06, 23, 22, 00, 00, TimeSpan.FromHours(1)),
                Id = "af43ea6f-b3ff-4640-9a9a-dbfc7544a4a4",
                Title = "Sample Booking",
                Premium = false,
                Price = new Price
                {
                    Value = 9.99M,
                    Currency = "GBP"
                },
                Member = new Member
                {
                    EmailAddress = "sample.member@somedomain.com",
                    FirstName = "William",
                    LastName = "McDowell",
                    Id = "7ce13464-a9df-4630-a50b-7fdd8a3661c4"
                }
            };
            var json = JsonSerializer.Serialize(booking, _options);
            Assert.That(
                json.Contains("booking_date"),
                Is.EqualTo(true)
            );
        }

        [Test]
        public void CanDeserializeJsonToObject()
        {
            const string JsonBooking = @"{
                ""id"": ""4f9ca774-81b9-4296-a35e-b31b96cedfb7"",
                ""title"": ""Sample Booking"",
                ""booking_date"": ""2019-05-06T16:45:00+02:00"",
                ""premium"": true,
                ""price"": {
                    ""value"": 12.95,
                    ""currency"": ""EUR""
                  },
                ""member"": {
                    ""id"": ""64cc7df1-5635-44d1-bfbc-00289abd3603"",
                    ""first_name"": ""Jessica"",
                    ""last_name"": ""Smithsson"",
                    ""email_address"": ""jessica99987@mmail.com""
                  }
                }";
            var booking = JsonSerializer.Deserialize<Booking>(JsonBooking, _options);
            Assert.That(
                booking.Title,
                Is.EqualTo("Sample Booking")
            );
        }
    }
}