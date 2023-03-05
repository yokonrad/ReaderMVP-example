using Reader.Model.Advanced;

namespace UnitTests.Reader.Model.Advanced.Validate
{
    public class ModelInputTest
    {
        private static IEnumerable<object[]> ModelInputData()
        {
            List<object[]> list = new()
            {
                new object[] { false, "" },
                new object[] { false, " " },
            };

            for (int i = RFID.Api.GetModelMinLength(); i <= RFID.Api.GetModelMaxLength(); i++)
            {
                list.Add(new object[] { true, new string('a', i) });
            }

            for (int i = RFID.Api.GetModelMaxLength() + 1; i <= RFID.Api.GetModelMaxLength() + 5; i++)
            {
                list.Add(new object[] { false, new string('a', i) });
            }

            foreach (object[] row in list)
            {
                yield return row;
            }
        }

        [Test, TestCaseSource(nameof(ModelInputData))]
        public void ModelInputReturnsExpectedValue(bool expected, string value)
        {
            // Arrange
            var _validateModel = new ValidateModel();

            // Act
            var actual = _validateModel.ModelInput(value);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
