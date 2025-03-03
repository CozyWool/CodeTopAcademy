import java.io.*;

public class ThreadReader extends Thread {
    private final Object lockObject;
    private final String fileName;
    private final Bus bus;

    public ThreadReader(Object lockObject, String fileName, Bus bus) {
        this.lockObject = lockObject;
        this.fileName = fileName;
        this.bus = bus;
    }

    @Override
    public void run() {
        synchronized (lockObject) {
            try (var br = new BufferedReader(new FileReader(fileName))) {
                String line;
                while ((line = br.readLine()) != null) {
                    bus.writeLine(line);
                    System.out.println("Прочитали: " + bus.getLine());
                    lockObject.notify();
                    lockObject.wait();
                }
                bus.writeLine(line);
                lockObject.notify();
            } catch (IOException e) {
                throw new RuntimeException(e);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}

