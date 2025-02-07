public class DoubleLinkedListNode<T> {
    public T value;
    private DoubleLinkedListNode<T> next;
    private DoubleLinkedListNode<T> previous;

    public DoubleLinkedListNode(T value) {
        this.value = value;
        setNext(null);
        setPrevious(null);
    }

    public DoubleLinkedListNode<T> getNext() {
        return next;
    }

    public void setNext(DoubleLinkedListNode<T> next) {
        this.next = next;
    }

    public DoubleLinkedListNode<T> getPrevious() {
        return previous;
    }

    public void setPrevious(DoubleLinkedListNode<T> previous) {
        this.previous = previous;
    }

    @Override
    public String toString() {
        return value.toString();
    }
}
