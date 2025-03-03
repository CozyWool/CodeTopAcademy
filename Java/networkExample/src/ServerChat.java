import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ServerChat {
    ServerSocket listener = null;
    Socket client = null;
    ObjectInputStream in = null;
    ObjectOutputStream out = null;
    int port = 12345;
    String message;


    public void listen() {
        try {
            listener = new ServerSocket(port);

            do {
                try {
                    System.out.println("Ждём подключение");

                    client = listener.accept();

                    System.out.println("Клиент подключился " + client.getInetAddress().getHostAddress());
                    out = new ObjectOutputStream(client.getOutputStream());
                    out.flush();

                    in = new ObjectInputStream(client.getInputStream());
                    message = (String) in.readObject();
                    System.out.println("client " + message);
                    DateFormat df = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
                    Date d = new Date();
                    sendMessage("Время получения сообщения " + df.format(d));
                } catch (ClassNotFoundException e) {
                    System.out.println(e);
                }
            } while (!message.equals("exit"));

        } catch (IOException ex) {
            System.out.println(ex);
        } finally {
            try {
                if (in != null) in.close();
                if (out != null) out.close();
                if (listener != null) listener.close();
            } catch (IOException ex) {
                System.out.println(ex);
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
