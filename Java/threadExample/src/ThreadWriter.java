import java.io.*;

public class ThreadWriter extends Thread {
    private final Object lockObject;
    private final String fileName;
    private final Bus bus;

    public ThreadWriter(Object lockObject, String fileName, Bus bus) {
        this.lockObject = lockObject;
        this.fileName = fileName;
        this.bus = bus;
    }

    @Override
    public void run() {
        synchronized (lockObject) {
            try (var bw = new BufferedWriter(new FileWriter(fileName))) {
                while (true) {
                    lockObject.wait();

                    if (!bus.hasLine()) {
                        lockObject.notify();
                        return;
                    }

                    bw.write(bus.getLine() + System.lineSeparator());
                    System.out.println("Записали: " + bus.getLine());
                    lockObject.notify();
                }
            } catch (IOException e) {
                throw new RuntimeException(e);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
