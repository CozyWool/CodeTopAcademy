import java.util.List;

public class CustomWriter extends Thread {
    private List<String> list;
    private int item;

    public CustomWriter(String name, List<String> list) {
        this.list = list;
        item = 0;
        super.setName(name);
    }

    @Override
    public void run() {
        while (true) {
            try {
                Thread.sleep(1000);
            } catch (InterruptedException ex) {
                ex.printStackTrace();
            }
            String newItem = "element" + item++;
            list.add(newItem);
            System.out.println(super.getName() + ": New element added!");
        }
    }
}
