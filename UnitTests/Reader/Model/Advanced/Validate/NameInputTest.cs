using Reader.Model.Advanced;

namespace UnitTests.Reader.Model.Advanced.Validate
{
    public class NameInputTest
    {
        private static IEnumerable<object[]> NameInputData()
        {
            List<object[]> list = new()
            {
                new object[] { false, "" },
                new object[] { false, " " },
            };

            for (int i = RFID.Api.GetNameMinLength(); i <= RFID.Api.GetNameMaxLength(); i++)
            {
                list.Add(new object[] { true, new string('a', i) });
            }

            for (int i = RFID.Api.GetNameMaxLength() + 1; i <= RFID.Api.GetNameMaxLength() + 5; i++)
            {
                list.Add(new object[] { false, new string('a', i) });
            }

            foreach (object[] row in list)
            {
                yield return row;
            }
        }

        [Test, TestCaseSource(nameof(NameInputData))]
        public void NameInputReturnsExpectedValue(bool expected, string value)
        {
            // Arrange
            var _validateModel = new ValidateModel();

            // Act
            var actual = _validateModel.NameInput(value);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
