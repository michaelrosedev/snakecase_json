
using NUnit.Framework;

namespace Sample.Serialization.Tests
{
    [TestFixture]
    public class SnakeCaseNamingPolicyTests
    {
        private SnakeCaseNamingPolicy _sut;

        [SetUp]
        public void _Setup()
        {
            _sut = new SnakeCaseNamingPolicy();
        }
        
        [Test]
        public void NullStringDoesNotCauseAnException()
        {
            Assert.DoesNotThrow(() => { _sut.ConvertName((string) null); });
        }

        [Test]
        public void EmptyStringDoesNotCauseAnException()
        {
            Assert.DoesNotThrow(() => { _sut.ConvertName(string.Empty); });
        }

        [TestCase("Id", "id")]
        [TestCase("Forename", "forename")]
        [TestCase("PeopleCarrier", "people_carrier")]
        [TestCase("MultiWordString", "multi_word_string")]
        public void InputStringIsReturnedInSnakeCase(string input, string expectedOutput)
        {
            var result = _sut.ConvertName(input);
            
            Assert.That(
                result,
                Is.EqualTo(expectedOutput)
            );
        }
    }
}