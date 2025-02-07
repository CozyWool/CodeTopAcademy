package classesExample;

import java.util.*;

public class Program {
    public static void main(String[] args) {
//        example1();
//        example2();
//        example3();
//        example4();
//        example5();
//        example6();
//        example7();
//        example8();
        example9();
    }

    private static void example9() {
        PriorityQueue<Integer> priorityQueue = new PriorityQueue<>();

        priorityQueue.add(4);
        priorityQueue.add(3);
        priorityQueue.add(1);
        priorityQueue.add(9);

        while (!priorityQueue.isEmpty()) {
            System.out.println(priorityQueue.remove());
        }
    }


    private static void example8() {
        Queue<String> customerQueue = new LinkedList<>();
        customerQueue.add("Анна");
        customerQueue.add("Петр");
        customerQueue.add("Мария");

        while (!customerQueue.isEmpty()) {
            String nextCustomer = customerQueue.poll();
            System.out.println("Обслуживается: " + nextCustomer);
        }
    }

    private static void example7() {
        var stack = new Stack<Integer>();
        stack.push(5);
        stack.push(4);
        while (!stack.isEmpty()) {
            System.out.println(stack.pop());
        }
    }

    private static void example6() {
        var vector = new Vector<Integer>();
        vector.add(5);
        vector.add(4);
        vector.add(2);
        for (Integer i : vector) {
            System.out.println(i);
        }
    }

    private static void example5() {
        var circle = new Circle("red", 10, 20, 5);
        circle.draw();
        circle.moveDown();
        circle.draw();
    }

    private static void example4() {
        Figure[] figures = new Figure[3];
        figures[0] = new Circle("red", 1, 2, 3);
        figures[1] = new Circle("yellow", 10, 20, 5);
        figures[2] = new Rectangle("red", 10, 20);

        for (int i = 0; i < figures.length; i++) {
            figures[i].draw();
        }
    }

    private static void example3() {
        Ball.count++;
        var b1 = new Ball();
        System.out.println(b1.count);

        Ball.count++;
        var b2 = new Ball();
        System.out.println(b1.count);
        System.out.println(b2.count);
    }

    private static void example2() {
        var student = new Student("Иван", 20);
        System.out.println(student);

        var aspirant = new Aspirant("Петр", 22, "Очень важная работа");
        System.out.println(aspirant);

        var student2 = new Aspirant("Петр", 22, "Еще одна работа в стол");
        System.out.println(student2);

        student2.deduction();
        student2.recovered();

    }

    private static void example1() {
        var student = new Student("Иван", 20);
        System.out.println(student);
    }
}