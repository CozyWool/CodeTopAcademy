
import org.junit.Assert;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

public class PluralTest {

    @ParameterizedTest
    @CsvSource({"0, рублей",
            "1000052, рубля",
            "25, рублей",
            "3, рубля",
            "20, рублей",
            "23, рубля",
            "22, рубля",
            "27, рублей",
            "122, рубля",
            "28, рублей",
            "7, рублей",
            "126, рублей",
            "24, рубля",
            "1002, рубля",
            "1, рубль",
            "1000, рублей",
            "6, рублей",
            "1000055, рублей",
            "100008, рублей",
            "100009, рублей",
            "26, рублей",
            "1004, рубля",
            "8, рублей",
            "4, рубля",
            "29, рублей",
            "9, рублей",
            "1005, рублей",
            "2, рубля",
            "5, рублей",
            "111, рублей",
            "10, рублей",
            "100, рублей",
            "101, рубль",
            "102, рубля",
            "103, рубля",
            "104, рубля",
            "11, рублей",
            "12, рублей",
            "13, рублей",
            "14, рублей",
            "15, рублей",
            "16, рублей",
            "17, рублей",
            "18, рублей",
            "19, рублей",
            "21, рубль",
            "30, рублей",
            "31, рубль",
            "32, рубля",
            "102, рубля",
            "112, рублей"})
    public void pluralizeRubles_ShouldSomething_ReturnSomething(int count, String rubles) {
        var result = Plural.pluralizeRubles(count);
        Assert.assertEquals(rubles, result);
    }
}