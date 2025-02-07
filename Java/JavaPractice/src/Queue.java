public class Queue<T> {
    private final DoubleLinkedList<T> list;

    public Queue() {
        this.list = new DoubleLinkedList<T>();
    }

    public T front() {
        return list.getHead().value;
    }

    public T back() {
        return list.getTail().value;
    }

    public void pushFront(T value) {
        list.add(value, 0);
    }

    public void pushBack(T value) {
        list.add(value, -1);
    }

    public T popFront() {
        return list.delete(0);
    }

    public T popBack() {
        return list.delete(-1);
    }

    public int size(){
        return list.size();
    }
}
