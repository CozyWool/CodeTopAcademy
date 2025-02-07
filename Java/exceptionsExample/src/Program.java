public static void main(String[] args) {
//    try {
//        example1();
//    } catch (IllegalAccessException e) {
//        System.out.println("IllegalAccessException");
//    } catch (CustomException e) {
//        System.out.println("CustomException");
//    }
//
//    example3();
//    example4();


}

private static void example4() {
    CopyOnWriteArrayList<String> concList = new CopyOnWriteArrayList<>();
    concList.add("Бельгия");
    concList.add("США");
    concList.add("Бразилия");
    concList.add("Канада");

    Thread writer = new CustomWriter("MyCustomWriter", concList);
    writer.start();

    Thread reader = new CustomReader("MyCustomReader", concList);
    reader.start();
}

private static void example3() {
//    Collections.synchronizedList(null);
//    Map<Integer, String> unsafeMap = new HashMap<>();
//    Map<Integer, String> safeMap = Collections.synchronizedMap(unsafeMap);

    ArrayList<String> safeArray = (ArrayList<String>) Collections.synchronizedList(new ArrayList<String>());
    safeArray.add("123");
    safeArray.add("456");
    synchronized (safeArray) {
        var iterator = safeArray.iterator();
        while (iterator.hasNext()) {
            System.out.println(iterator.next());
        }
    }
}

private static void example1() throws
        ArrayIndexOutOfBoundsException, ArithmeticException, IllegalAccessException, CustomException {
    int a, b;
    try {
        int[] array = {1};
        array[2] = 0;
        a = 10;
        b = 0;
        a = a / b;
        System.out.println(a / b);
    } catch (ArithmeticException ex) {
        System.out.println("Ошибка деления на ноль");
        throw ex;
    } catch (ArrayIndexOutOfBoundsException ex) {
        System.out.println("Выход за границы массива");
        throw ex;
    } finally {
        System.out.println("А я все равно выведусь!");

    }
    System.out.println("Если произошла исключение, то оно была обработано");
}