public static void main(String[] args) {
// example1();
//    example2();
//    example3();
//    example4();
//  example5();
//    example6();
    example7();
}

private static void example7() {
    try (ExecutorService executor = Executors.newSingleThreadExecutor()) {

        var future = executor.submit(new Runnable() {
            @Override
            public void run() {
                String threadName = Thread.currentThread().getName();
                System.out.println(threadName);
            }
        });

        try {
            if (future.get() == null) {
                System.out.println("Задача выполнена успешно");
            }
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } catch (ExecutionException e) {
            throw new RuntimeException(e);
        }

        try {
            if (!executor.awaitTermination(60, TimeUnit.SECONDS))
                executor.shutdownNow();
            else {
                executor.shutdown();
            }
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }
}

private static void example6() {
    int threadCount = 20;
//    MySemaphore s = new MySemaphore(5);
//    for (int i = 0; i < threadCount; i++) {
//        Thread t = new Thread(s);
//        t.start();
//    }
    Runnable task = new Runnable() {
        Semaphore s = new Semaphore(5);

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
    };
    for (int i = 0; i < 20; i++) {
        Thread t = new Thread(task);
        t.start();
    }
}

private static void example5() {
    Bus bus = new Bus();
    Object lockObject = new Object();
    ThreadReader readerThread = new ThreadReader(lockObject, "line_in.txt", bus);
    ThreadWriter writerThread = new ThreadWriter(lockObject, "line_out.txt", bus);
    readerThread.setDaemon(true);
    writerThread.setDaemon(true);

    writerThread.start();
    readerThread.start();
    try {
        readerThread.join();
        writerThread.join();
    } catch (InterruptedException e) {
        throw new RuntimeException(e);
    }
}

private static void example4() {
    Object lockObject = new Object();
    ThreadReader readerThread = new ThreadReader(lockObject, "line_in.txt", null);
    ThreadWriter writerThread = new ThreadWriter(lockObject, "line_out.txt", null);
    readerThread.setDaemon(true);
    writerThread.setDaemon(true);

    writerThread.start();
    readerThread.start();
    try {
        readerThread.join();
        writerThread.join();
    } catch (InterruptedException e) {
        throw new RuntimeException(e);
    }
}

private static void example3() {
    int limit = 1000;
    IncThread t1 = new IncThread(limit);
    DecThread t2 = new DecThread(limit);
    t1.start();
    t2.start();
    try {
        t1.join();
        t2.join();
        System.out.println(ThreadCounter.counter);
    } catch (InterruptedException e) {
        throw new RuntimeException(e);
    }
}

private static void example2() {
    MyThread t1 = new MyThread(5);
    t1.setDaemon(true);
    MyThread t2 = new MyThread(3);
    t2.setDaemon(true);
    t1.start();
    t2.start();
    try {
        int count = 100;
        while (count-- > 0) {
            System.out.println(".");
        }
        t1.join();
        t2.join();
    } catch (InterruptedException e) {
        throw new RuntimeException(e);
    }
}

private static void example1() {
    MyThread t1 = new MyThread(1);
    t1.setDaemon(true);
    t1.setName("Thread 1");
    t1.setPriority(Thread.MAX_PRIORITY);
    t1.start();

    int count = 100;
    while (count-- > 0) {
        System.out.println(". " + t1.getName());
    }
}