public class Bus {
    String message = null;

    public void writeLine(String message) {
        this.message = message;
    }

    public String getLine() {
        return this.message;
    }

    public boolean hasLine() {
        return this.message != null;
    }
}
