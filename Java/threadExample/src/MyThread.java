public class MyThread extends Thread {
    private int seconds;

    public MyThread(int seconds) {
        this.seconds = seconds;
    }

    @Override
    public void run() {
        while (seconds > 0) {
            try {
                System.out.printf("%s going to sleep\n", getName());
                Thread.sleep(1000);
                System.out.printf("%s awoke. %d seconds left to terminate\n", getName(), seconds);
                seconds--;
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }

        }
    }
}
