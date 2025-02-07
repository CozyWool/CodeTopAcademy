package classesExample;

public class Rectangle extends Figure {
    public int a;
    public int b;

    public Rectangle(String color, int a, int b) {
        super(color);
        this.a = a;
        this.b = b;
    }

    @Override
    public void draw() {
        System.out.printf("Прямоугольник: a = %d b = %d цвет = %s\n", a, b, color);
    }
}
