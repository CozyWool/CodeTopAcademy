public static void main(String[] args) {
    DoubleLinkedList<Integer> list = new DoubleLinkedList<Integer>();
    list.add(5);
    list.add(6);
    list.add(7);
    list.add(8);

    System.out.println("Список: " + list);
    System.out.println("Голова: " + list.getHead());
    System.out.println("Элемент с индексом 1: " + list.getAt(1));
    System.out.println("Хвост: " + list.getTail());

//    for (int i = 0; i < list.size(); i++) {
//        System.out.print(list.getAt(i) + " ");
//    }
    System.out.println("\nУдалили элемент с индексом 2\n");
    list.delete(2);

    System.out.println("Голова: " + list.getHead());
    System.out.println("Элемент с индексом 2: " + list.getAt(2));
    System.out.println("Хвост: " + list.getTail());

    System.out.println("Список: " + list);

    Queue<Integer> queue = new Queue<>();
    queue.pushFront(5);
    queue.pushFront(4);
    queue.pushBack(6);

    System.out.println("\nQueue:");
    System.out.println("Front: " + queue.front());
    System.out.println("Back: " + queue.back());

    System.out.println("\nPushed back 10\n");
    queue.pushBack(10);

    System.out.println("Front: " + queue.front());
    System.out.println("Back: " + queue.back());

    System.out.println("\nPopped front\n");
    var val = queue.popFront();

    System.out.println("Popped value: " + val);
    System.out.println("Front: " + queue.front());
    System.out.println("Back: " + queue.back());
}