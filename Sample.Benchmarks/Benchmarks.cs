using System;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sample.Contracts;

namespace Sample.Benchmarks
{
    [MemoryDiagnoser] 
    public class Benchmarks
    {
        private const string JsonBooking = @"{
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
        
        private readonly Booking _booking = new Booking
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
        
        private static readonly DefaultContractResolver ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };
        
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = ContractResolver
        };
        
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new Serialization.SnakeCaseNamingPolicy()
        };
        
        private readonly JsonSerializerOptions _spanOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new Serialization.SnakeCaseNamingPolicySpan()
        };
        
        [Benchmark]
        public string SerializeWithNewtonsoft()
        {
            var result = JsonConvert.SerializeObject(_booking, Formatting.Indented, _jsonSerializerSettings);
            return result;
        }

        [Benchmark]
        public string SerializeWithSystemTextJson()
        {
            var result = System.Text.Json.JsonSerializer.Serialize(_booking, _options);
            return result;
        }
        
        [Benchmark]
        public string SerializeWithSystemTextJsonSpan()
        {
            var result = System.Text.Json.JsonSerializer.Serialize(_booking, _spanOptions);
            return result;
        }

        [Benchmark]
        public Booking DeserializeWithNewtonsoft()
        {
            var result = JsonConvert.DeserializeObject<Booking>(JsonBooking, _jsonSerializerSettings);
            return result;
        }

        [Benchmark]
        public Booking DeserializeWithSystemTextJson()
        {
            var result = System.Text.Json.JsonSerializer.Deserialize<Booking>(JsonBooking, _options);
            return result;
        }
        
        [Benchmark]
        public Booking DeserializeWithSystemTextJsonSpan()
        {
            var result = System.Text.Json.JsonSerializer.Deserialize<Booking>(JsonBooking, _spanOptions);
            return result;
        }
    }
}