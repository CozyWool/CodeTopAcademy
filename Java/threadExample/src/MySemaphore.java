import java.util.concurrent.Semaphore;

public class MySemaphore extends Thread {
    Semaphore s;

    MySemaphore(int threadCount) {
        this.s = new Semaphore(threadCount);
    }

    @Override
    public void run() {
        try {
            s.acquire();
            System.out.println(Thread.currentThread().getName());
            Thread.currentThread().sleep(500);
            System.out.println(Thread.currentThread().getName() + " finished");
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } finally {
            s.release();
        }
    }
}
