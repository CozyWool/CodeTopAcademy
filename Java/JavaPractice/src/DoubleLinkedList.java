public class DoubleLinkedList<T> {
    private DoubleLinkedListNode<T> head;
    private DoubleLinkedListNode<T> tail;

    public DoubleLinkedList() {
        head = null;
        tail = null;
    }

    public DoubleLinkedListNode<T> getHead() {
        return head;
    }

    public DoubleLinkedListNode<T> getTail() {
        return tail;
    }

    public void add(T value, int index) throws IllegalArgumentException {
        var newNode = new DoubleLinkedListNode<T>(value);
        if (head == null) {
            head = newNode;
            tail = newNode;
            return;
        }
        if ((index < 0 || index > size() - 1) && index != -1) {
            throw new IllegalArgumentException("Индекс вне границ списка");
        }
        if (index == 0) {
            head.setPrevious(newNode);
            newNode.setNext(head);
            head = newNode;
            return;
        }
        if (index == size() - 1 || index == -1) {
            tail.setNext(newNode);
            newNode.setPrevious(tail);
            tail = newNode;
            return;
        }

        var currentNode = getAt(index);
        var previousNode = currentNode.getPrevious();
        newNode.setPrevious(previousNode);
        newNode.setNext(currentNode);
        previousNode.setNext(newNode);
        currentNode.setPrevious(newNode);
    }

    public void add(T value) {
        add(value, -1);
    }

    public T delete(int index) {
        if ((index < 0 || index > size() - 1) && index != -1) {
            throw new IllegalArgumentException("Индекс вне границ списка");
        }
        T value;
        if (index == 0) {
            value = head.value;
            var nextNode = head.getNext();
            head.setNext(null);
            nextNode.setPrevious(null);
            head = nextNode;
            return value;
        }
        if (index == -1 || index == size() - 1) {
            value = tail.value;

            var previousNode = tail.getPrevious();
            previousNode.setNext(null);
            tail.setPrevious(null);
            tail = previousNode;
            return value;
        }

        var node = getAt(index);
        var previousNode = node.getPrevious();
        var nextNode = node.getNext();
        previousNode.setNext(nextNode);
        nextNode.setPrevious(previousNode);

        // хз нужно ли это, сборщик и так уничтожит
        node.setPrevious(null);
        node.setNext(null);

        return node.value;
    }

    public int size() {
        int size = 0;
        DoubleLinkedListNode<T> node = head;
        while (node != null) {
            size++;
            node = node.getNext();
        }
        return size;
    }

    public DoubleLinkedListNode<T> getAt(int index) throws IllegalArgumentException {
        if (index < 0 || index >= size()) {
            throw new IllegalArgumentException("Индекс вне границ списка");
        }
        DoubleLinkedListNode<T> node = head;
        while (node != null && index != 0) {
            index--;
            node = node.getNext();
        }
        return node;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        DoubleLinkedListNode<T> node = head;
        while (node != null) {
            sb.append(node);
            node = node.getNext();
            if (node != null)
                sb.append(" ");
        }
        return sb.toString();
    }
}
