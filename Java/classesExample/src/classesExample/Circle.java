package classesExample;

public class Circle extends Figure implements Moveable{
    public int x;
    public int y;
    public int r;

    public Circle(String color, int x, int y, int r) {
        super(color);
        this.x = x;
        this.y = y;
        this.r = r;
    }

    @Override
    public void draw() {
        System.out.printf("Окружность: x = %d y = %d r = %d цвет = %s\n", x, y, r, color);
    }

    @Override
    public void moveRight() {
        x++;
    }

    @Override
    public void moveLeft() {
        x--;
    }

    @Override
    public void moveUp() {
        y++;
    }

    @Override
    public void moveDown() {
        y--;
    }
}
