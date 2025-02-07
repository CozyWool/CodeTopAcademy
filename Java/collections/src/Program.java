public static void main(String[] args) {
//    example1();
//    example2();
//    example3();
    example4();
}

private static void example4() {
    FishComparator comparator = new FishComparator();
    TreeSet<Fish> fishes = new TreeSet<Fish>(comparator);

    fishes.add(new Fish("карась", 1, 120));
    fishes.add(new Fish("окунь", 1, 120));
    fishes.add(new Fish("щука", 1, 120));
    fishes.add(new Fish("щука", 1, 120));

    System.out.println(fishes);
    System.out.println(fishes.size());
}
private static void example3() {
    TreeSet<Fish> fishes = new TreeSet<Fish>();

    fishes.add(new Fish("карась", 1, 120));
    fishes.add(new Fish("окунь", 1, 121));
    fishes.add(new Fish("щука", 1, 120));
    fishes.add(new Fish("щука", 1, 120));

    System.out.println(fishes);
    System.out.println(fishes.size());
}

private static void example2() {
    TreeSet<String> set = new TreeSet<String>();
    set.add("Россия");
    set.add("США");
    set.add("Германия");
    set.add("Англия");
    System.out.println(set);
}

private static void example1() {
    HashSet<Fish> fishes = new HashSet<Fish>();

    fishes.add(new Fish("карась", 1, 120));
    fishes.add(new Fish("окунь", 1, 120));
    fishes.add(new Fish("щука", 1, 120));
    fishes.add(new Fish("щука", 1, 120));

    System.out.println(fishes);
    System.out.println(fishes.size());
}