public class DecThread extends Thread {
    int limit;

    public DecThread(int limit) {
        this.limit = limit;
    }

    @Override
    public void run() {
        for (int i = 0; i < limit; i++) {
            synchronized (ThreadCounter.locker) {
                ThreadCounter.counter--;
            }
        }
    }
}
