import javax.swing.*;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

public class ClientChat {
    Socket client = null;
    ObjectInputStream in = null;
    ObjectOutputStream out = null;
    String message;
    int port = 12345;

    public void setConnection() {
        try {
            client = new Socket("127.0.0.1", port);
            System.out.println("Подключаемся к серверу");
            out = new ObjectOutputStream(client.getOutputStream());
            out.flush();
            in = new ObjectInputStream(client.getInputStream());

            message = JOptionPane.showInputDialog(this, "Введите сообщение");
            sendMessage(message);
            try {
                message = (String) in.readObject();
                System.out.println("server " + message);
            } catch (ClassNotFoundException e) {
                System.out.println(e);
            }
        } catch (IOException ex) {
            System.out.println(ex);
        } finally {
            try {
                if (out != null) out.close();
                if (in != null) in.close();
                if (client != null) client.close();
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
    }

    private void sendMessage(String message) {
        try {
            out.writeObject(message);
            out.flush();
        } catch (IOException ex) {
            System.out.println(ex);
        }
    }
}
