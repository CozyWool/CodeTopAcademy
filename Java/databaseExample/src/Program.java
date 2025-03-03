import java.sql.*;

public static void main(String[] args) {
//    createExample();
//    updateExample();
//    deleteExample();
    selectExample();
}

private static void deleteExample() {
    Connection connection = null;
    try {
        Class.forName("org.postgresql.Driver");
        String connectionString = "jdbc:postgresql://localhost:5432/ProductsDb";
        String username = "postgres";
        String password = "1";

        connection = DriverManager.getConnection(connectionString, username, password);
        System.out.println("Подключение успешно!");

        String deleteQuery = "DELETE FROM \"Products\" WHERE \"Name\" = ?";
        var statement = connection.prepareStatement(deleteQuery);

        var name = "Some new Product";
        statement.setString(1, name);

        statement.execute();

        System.out.println("Успешно удалено!");

        connection.close();
    } catch (Exception e) {
        e.printStackTrace();
    } finally {
        if (connection != null) {
            try {
                connection.close();
            } catch (SQLException e) { /* Ignored */}
        }
    }
}

private static void updateExample() {
    Connection connection = null;
    try {
        Class.forName("org.postgresql.Driver");
        String connectionString = "jdbc:postgresql://localhost:5432/ProductsDb";
        String username = "postgres";
        String password = "1";

        connection = DriverManager.getConnection(connectionString, username, password);
        System.out.println("Подключение успешно!");


        var statement = connection.prepareStatement("SELECT * FROM \"Products\"" +
                "WHERE \"Name\" = ? " +
                "ORDER BY \"Id\" DESC " +
                "LIMIT 1");
        statement.setString(1, "Laptop");
        ResultSet set = statement.executeQuery();
        if (!set.next()) {
            System.out.println("Объект не найден");
            throw new SQLException("Not found");
        }

        var id = set.getObject("id", UUID.class);
        var name = set.getString("Name");
        var price = set.getInt("Price");
        System.out.printf("From table: %s %s %d%n", id, name, price);

        name = "Super laptop";
        price *= 2;
        System.out.printf("Updated row: %s %s %d%n", id, name, price);
        var updateStatement = connection.prepareStatement("UPDATE \"Products\" " +
                "SET \"Name\" = ?, \"Price\" = ?" +
                " WHERE \"Id\" = ?");
        updateStatement.setString(1, name);
        updateStatement.setInt(2, price);
        updateStatement.setObject(3, id);

        updateStatement.execute();
        System.out.println("Успешно обновлено!");

    } catch (Exception e) {
        e.printStackTrace();
    } finally {
        if (connection != null) {
            try {
                connection.close();
            } catch (SQLException e) { /* Ignored */}
        }
    }
}

private static void createExample() {
    Connection connection = null;
    try {
        Class.forName("org.postgresql.Driver");
        String connectionString = "jdbc:postgresql://localhost:5432/ProductsDb";
        String username = "postgres";
        String password = "1";

        connection = DriverManager.getConnection(connectionString, username, password);
        System.out.println("Подключение успешно!");

        String createQuery = "INSERT INTO \"Products\" VALUES (?, ?, ?)";
        var statement = connection.prepareStatement(createQuery);

        var id = UUID.randomUUID();
        var name = "Some new Product";
        var price = 200;
        statement.setObject(1, id);
        statement.setString(2, name);
        statement.setInt(3, price);
        statement.execute();
        System.out.println("Успешно добавлено!");

    } catch (Exception e) {
        e.printStackTrace();
    } finally {
        if (connection != null) {
            try {
                connection.close();
            } catch (SQLException e) { /* Ignored */}
        }
    }
}

private static void selectExample() {
    Connection connection = null;
    try {
        Class.forName("org.postgresql.Driver");
        String connectionString = "jdbc:postgresql://localhost:5432/ProductsDb";
        String username = "postgres";
        String password = "1";

        connection = DriverManager.getConnection(connectionString, username, password);
        System.out.println("Подключение успешно!");

        String selectQuery = "SELECT * FROM \"Products\" ORDER BY \"Price\" DESC";
        Statement statement = connection.createStatement();
        ResultSet set = statement.executeQuery(selectQuery);
        while (set.next()) {
            String id = set.getString("id");
            String name = set.getString("Name");
            int price = set.getInt("Price");
            System.out.printf("%s %s %d%n", id, name, price);
        }
    } catch (Exception e) {
        e.printStackTrace();
    } finally {
        if (connection != null) {
            try {
                connection.close();
            } catch (SQLException e) { /* Ignored */}
        }
    }
} 