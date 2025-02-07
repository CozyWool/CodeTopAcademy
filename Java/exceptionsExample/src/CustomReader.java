import java.util.List;

public class CustomReader extends Thread {
    private List<String> list;

    public CustomReader(String name, List<String> list) {
        this.list = list;
        super.setName(name);
    }

    public void run() {
        while (true) {
            StringBuilder info = new StringBuilder(super.getName() + ": ");
            for (String el : list) {
                info.append(" ").append(el);
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException ex) {
                    ex.printStackTrace();
                }
            }
            System.out.println(info);
        }
    }
}
