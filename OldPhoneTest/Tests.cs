using CodeChallenge;

namespace OldPhoneTest
{
    public class Tests
    {
        [TestCase("6444222 2#", "MICA")]
        [TestCase("227*#", "B")]
        [TestCase("4433555 555666#", "HELLO")]
        [TestCase("83377778#", "TEST")]
        [TestCase("2555 665** 555339999*#", "ALLEY")]
        [TestCase("44335666****555 555666069999999072555", "HELLO MY PAL")]
 

        public void OldPhone_ReturnsExpectedOutput(string input, string expected)
        {
            var result = OldPhone.OldPhonePad(input);
            Assert.AreEqual(expected, result);
        }
    }
}