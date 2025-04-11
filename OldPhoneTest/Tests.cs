using CodeChallenge;

namespace OldPhoneTest
{
    public class Tests
    {
        [TestCase("33#", "E")]
        [TestCase("227*#", "B")]
        [TestCase("4433555 555666#", "HELLO")]
        [TestCase("83377778#", "TEST")]
        [TestCase("26 6663** 6#", "AMNO")]
        public void OldPhone_ReturnsExpectedOutput(string input, string expected)
        {
            var result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }
    }
}