public static void main(String[] args) {
    clientSocketExample();
}

private static void clientSocketExample() {
    ClientChat client = new ClientChat();
    while (true){
        client.setConnection();
    }
}