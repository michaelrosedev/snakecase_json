using System;
using System.Text.Json;
using NUnit.Framework;
using Sample.Contracts;

namespace Sample.Tests
{
    public class Tests
    {
        private Booking _booking;
        private string _jsonBooking;
        private JsonSerializerOptions _options;

        [SetUp]
        public void Setup()
        {
            _booking = new Booking
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

            _jsonBooking = @"{
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

            _options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true,
                PropertyNamingPolicy = new Serialization.SnakeCaseNamingPolicy()
            };
        }

        [Test]
        public void CanSerializeObjectToJson()
        {
            var booking = JsonSerializer.Serialize(_booking, _options);
            Assert.Pass();
        }

        [Test]
        public void CanDeserializeJsonToObject()
        {
            var booking = JsonSerializer.Deserialize<Booking>(_jsonBooking, _options);
            Assert.Pass();
        }
    }
}