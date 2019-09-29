using NUnit.Framework;

namespace Sample.Serialization.Tests
{
    [TestFixture]
    public class SnakeCaseTests
    {
        [Test]
        public void SimpleStringCanBeConvertedToSnakeCase()
        {
            const string Input = "Id";
            const string ExpectedOutput = "id";

            var result = Input.ToSnakeCase();
            
            Assert.That(
                result,
                Is.EqualTo(ExpectedOutput)
            );
        }

        [Test]
        public void MultiWordStringCanBeConvertedToSnakeCase()
        {
            const string Input = "MyName";
            const string ExpectedOutput = "my_name";

            var result = Input.ToSnakeCase();
            
            Assert.That(
                result,
                Is.EqualTo(ExpectedOutput)
            );
        }

        [Test]
        public void TripleWordStringCanBeConvertedToSnakeCase()
        {
            const string Input = "ExpectedDeliveryDate";
            const string ExpectedOutput = "expected_delivery_date";

            var result = Input.ToSnakeCase();
            
            Assert.That(
                result,
                Is.EqualTo(ExpectedOutput)
            );
        }

        [Test]
        public void NullStringDoesNotCauseAnException()
        {
            const string Input = (string) null;

            Assert.DoesNotThrow(() => { Input.ToSnakeCase(); });
        }

        [Test]
        public void EmptyStringDoesNotCauseAnException()
        {
            var input = string.Empty;
            
            Assert.DoesNotThrow(() => { input.ToSnakeCase();});
        }
    }
}