public static void main(String[] args) {
//    example1();
//    example2();
    serverSocketExample();
}

private static void serverSocketExample() {
    ServerChat server = new ServerChat();
    server.listen();
}

private static void example2() {
    try {
        ServerSocket listener = new ServerSocket(12345);
        while (true) {
            Socket client = null;
            while (client == null) {
                client = listener.accept();
                // some code
            }

        }
    } catch (IOException e) {
        throw new RuntimeException(e);
    }
}

private static void example1() {
    try {
        InetAddress address1 = InetAddress.getByName("127.0.0.1");
        InetAddress address2 = InetAddress.getByName("google.com");
        InetAddress address3 = InetAddress.getLocalHost();
        System.out.println(address1.getHostAddress());
        System.out.println(address2.getHostAddress());
        System.out.println(address3.getHostAddress());
        System.out.println(address3.getCanonicalHostName());
    } catch (UnknownHostException e) {
        e.printStackTrace();
    }
}