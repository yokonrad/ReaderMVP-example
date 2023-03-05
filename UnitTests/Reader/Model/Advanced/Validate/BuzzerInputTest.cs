using Reader.Model.Advanced;

namespace UnitTests.Reader.Model.Advanced.Validate
{
    public class BuzzerInputTest
    {
        private static IEnumerable<object[]> BuzzerInputData()
        {
            List<object[]> list = new();

            for (int i = -5; i <= -1; i++)
            {
                list.Add(new object[] { false, i });
            }

            foreach (var item in RFID.Api.GetBuzzerItems().Select((value, i) => new { i, value }))
            {
                list.Add(new object[] { true, item.i });
            }

            for (int i = RFID.Api.GetBuzzerItems().Length + 1; i <= RFID.Api.GetBuzzerItems().Length + 5; i++)
            {
                list.Add(new object[] { false, i });
            }

            foreach (object[] row in list)
            {
                yield return row;
            }
        }

        [Test, TestCaseSource(nameof(BuzzerInputData))]
        public void BuzzerInputReturnsExpectedValue(bool expected, int index)
        {
            // Arrange
            var _validateModel = new ValidateModel();

            // Act
            var actual = _validateModel.BuzzerInput(index);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}