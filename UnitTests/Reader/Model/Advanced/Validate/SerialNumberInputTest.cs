using Reader.Model.Advanced;

namespace UnitTests.Reader.Model.Advanced.Validate
{
    public class SerialNumberInputTest
    {
        private static IEnumerable<object[]> SerialNumberInputData()
        {
            List<object[]> list = new()
            {
                new object[] { false, "" },
                new object[] { false, " " },
            };

            for (int i = RFID.Api.GetSerialNumberMinLength(); i <= RFID.Api.GetSerialNumberMaxLength(); i++)
            {
                list.Add(new object[] { true, new string('a', i) });
            }

            for (int i = RFID.Api.GetSerialNumberMaxLength() + 1; i <= RFID.Api.GetSerialNumberMaxLength() + 5; i++)
            {
                list.Add(new object[] { false, new string('a', i) });
            }

            foreach (object[] row in list)
            {
                yield return row;
            }
        }

        [Test, TestCaseSource(nameof(SerialNumberInputData))]
        public void SerialNumberInputReturnsExpectedValue(bool expected, string value)
        {
            // Arrange
            var _validateModel = new ValidateModel();

            // Act
            var actual = _validateModel.SerialNumberInput(value);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
