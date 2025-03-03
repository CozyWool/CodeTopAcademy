namespace PluralConsoleApp.Tests;

public class Tests
{
    [TestCase(0, "рублей")]
    [TestCase(1000052, "рубля")]
    [TestCase(25, "рублей")]
    [TestCase(3, "рубля")]
    [TestCase(20, "рублей")]
    [TestCase(23, "рубля")]
    [TestCase(22, "рубля")]
    [TestCase(27, "рублей")]
    [TestCase(122, "рубля")]
    [TestCase(28, "рублей")]
    [TestCase(7, "рублей")]
    [TestCase(126, "рублей")]
    [TestCase(24, "рубля")]
    [TestCase(1002, "рубля")]
    [TestCase(1, "рубль")]
    [TestCase(1000, "рублей")]
    [TestCase(6, "рублей")]
    [TestCase(1000055, "рублей")]
    [TestCase(100008, "рублей")]
    [TestCase(100009, "рублей")]
    [TestCase(26, "рублей")]
    [TestCase(1004, "рубля")]
    [TestCase(8, "рублей")]
    [TestCase(4, "рубля")]
    [TestCase(29, "рублей")]
    [TestCase(9, "рублей")]
    [TestCase(1005, "рублей")]
    [TestCase(2, "рубля")]
    [TestCase(5, "рублей")]
    [TestCase(111, "рублей")]
    [TestCase(10, "рублей")]
    [TestCase(100, "рублей")]
    [TestCase(101, "рубль")]
    [TestCase(102, "рубля")]
    [TestCase(103, "рубля")]
    [TestCase(104, "рубля")]
    [TestCase(11, "рублей")]
    [TestCase(12, "рублей")]
    [TestCase(13, "рублей")]
    [TestCase(14, "рублей")]
    [TestCase(15, "рублей")]
    [TestCase(16, "рублей")]
    [TestCase(17, "рублей")]
    [TestCase(18, "рублей")]
    [TestCase(19, "рублей")]
    [TestCase(21, "рубль")]
    [TestCase(30, "рублей")]
    [TestCase(31, "рубль")]
    [TestCase(32, "рубля")]
    [TestCase(102, "рубля")]
    [TestCase(112, "рублей")]
    public void PluralizeRubles_ShouldSomething_ReturnSomething(int count, string expectedResult)
    {
        var result = Plural.PluralizeRubles(count);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    // [Test]
    // public void Test1()
    // {
    //     var result = Plural.PluralizeRubles(1);
    //     Assert.That(result, Is.EqualTo("рубль"));
    // }
}

