import org.junit.Test;

import static org.junit.Assert.*;

public class CalculatorTest {

    @Test
    public void add() {
        Calculator calculator = new Calculator();
        double result = calculator.add(8.5, 3);
        assertEquals(11.5, result, 0.01);
    }

    @Test
    public void div() {
        Calculator calculator = new Calculator();
        Exception exception = assertThrows(ArithmeticException.class, () -> {
            int result = calculator.div(12, 0);
        });
        assertTrue(exception.getClass().equals(ArithmeticException.class));
    }
}