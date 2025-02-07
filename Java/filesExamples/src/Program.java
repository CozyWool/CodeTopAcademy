import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;

public static void main(String[] args) {
//    example1();
//    example2();
//    example3();
//    example4();
//    example5();
//    example6();
//    example7();
//    example8();
//    try {
//        example9();
//    } catch (IOException e) {
//        throw new RuntimeException(e);
//    }
//    example10();
    try {
//        example11();
//        example12();
//        example13();
//        example14();
//        example15();
        example16();
    } catch (Exception ex) {
        ex.printStackTrace();
    }
}

private static void example16() throws IOException, ClassNotFoundException {
    FishExternalizable f = new FishExternalizable("Окунь", 30, 341);

    FileOutputStream fout = null;
    ObjectOutputStream objOut = null;
    FileInputStream fin = null;
    ObjectInputStream objIn = null;

    try {
        fout = new FileOutputStream("fishExt.txt");
        objOut = new ObjectOutputStream(fout);
        objOut.writeObject(f);

        fin = new FileInputStream("fishExt.txt");
        objIn = new ObjectInputStream(fin);
        FishExternalizable f2 = (FishExternalizable) objIn.readObject();
        System.out.println(f2);

    } finally {
        if (objOut != null) objOut.close();
        if (fout != null) fout.close();
        if (objIn != null) objIn.close();
        if (fin != null) fin.close();
    }

}

private static void example15() {
    BufferedReader bufReader = new BufferedReader(new InputStreamReader(System.in));
    try {
        String line = bufReader.readLine();
        System.out.println(line);

    } catch (Exception ex) {
        System.out.println(ex);
    }
}

private static void example14() throws IOException {
    try (FileReader fr = new FileReader("input.txt"); FileWriter fw = new FileWriter("output.txt")) {
        BufferedReader br = new BufferedReader(fr);
        BufferedWriter bw = new BufferedWriter(fw);

        String line;
        int count = 0;
        while ((line = br.readLine()) != null) {
            if (count++ % 2 == 0) {
                System.out.println(line);
                bw.write(line + System.lineSeparator());
            }
        }
        bw.flush();
    }
}


private static void example13() throws IOException {
    String line = "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн. Его популяризации в новое время послужили публикация листов Letraset с образцами Lorem Ipsum в 60-х годах и, в более недавнее время, программы электронной вёрстки типа Aldus PageMaker, в шаблонах которых используется Lorem Ipsum.";
    ByteArrayInputStream bIn = new ByteArrayInputStream(line.getBytes());
    int ch;
    StringBuilder sb = new StringBuilder();

    byte[] buffer = new byte[2];
    while ((buffer[0] = (byte) bIn.read()) != -1) {
        if (buffer[0] < 0) {
            buffer[1] = (byte) bIn.read();
            sb.append(new String(buffer, 0, 2, StandardCharsets.UTF_8));
        } else {
            sb.append(Character.toChars(buffer[0]));
        }
    }
    System.out.println(sb);
}

private static void example12() throws IOException, ClassNotFoundException {
    Fish f = new Fish("окунь", 10, 110);
    FileOutputStream fout = null;
    ObjectOutputStream objOut = null;
    fout = new FileOutputStream("fish.txt");
    objOut = new ObjectOutputStream(fout);
    objOut.writeObject(f);

    FileInputStream fin = null;
    ObjectInputStream objIn = null;
    fin = new FileInputStream("fish.txt");
    objIn = new ObjectInputStream(fin);
    Fish f2 = (Fish) objIn.readObject();
    System.out.println(f2);

    fout.close();
    fin.close();
    objIn.close();
    objOut.close();
}

private static void example11() throws IOException {
    var file = new File("1.jpg");
    BufferedImage bImage = ImageIO.read(file);
    var bOut = new ByteArrayOutputStream();
    ImageIO.write(bImage, "jpg", bOut);
    byte[] imageInBytes = bOut.toByteArray();
}

private static void example10() {
    InputStream in = null;
    OutputStream out = null;
    byte[] buffer = new byte[8 * 1024];
    try {
        in = new FileInputStream("text.txt");
        out = new FileOutputStream("outfile.tmp");
        int bytesRead = 0;
        while ((bytesRead = in.read(buffer)) != -1) {
            out.write(buffer, 0, bytesRead);
        }
    } catch (IOException ex) {
        //
    } finally {
        try {
            in.close();
            out.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

private static void example9() throws FileNotFoundException, IOException {
        /*InputStream in = null;
        OutputStream out = null;
        byte[] buffer = null;
        try {
            in = new FileInputStream(new File("test.txt"));
            System.out.println("Available bytes: " + in.available());
            buffer = new byte[in.available()];
            in.read(buffer);
            File file = new File("out.tmp");
            out = new FileOutputStream(file);
            out.write(buffer);
        }
        catch(FileNotFoundException ex) {
            //
        }
        catch(IOException ex) {
            //
        }
        finally {
            try {
                in.close();
                out.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }*/
    File file = new File("out.tmp");
    try (InputStream in = new FileInputStream(new File("test.txt")); var out = new FileOutputStream(file)) {
        var buffer = new byte[in.available()];
        in.read(buffer);
        out.write(buffer);
    }
}

private static void example8() {
    String fileName = "test.txt";
    String dirName = System.getProperty("user.dir");
    String fullName = dirName + File.separator + fileName;
    System.out.println("Path: " + fullName);
    File file = new File(fullName);

    try {
        if (file.createNewFile()) {
            System.out.println("File create");
        }
    } catch (IOException ex) {
        System.out.println(ex);
    }
}

private static void example7() {
    var result = Stream.of("щука", "карась", "окунь").filter(f -> f.length() > 4);
    result.forEach(System.out::println);
}

private static void example6() {
    List<Fish> array = new ArrayList<>();
    array.add(new Fish("карась", 1, 120));
    array.add(new Fish("окунь", 4, 121));
    array.add(new Fish("щука", 2, 120));
    array.add(new Fish("щука", 3, 120));

    array.forEach(System.out::println);

    System.out.println();

    array.stream().peek(f -> f.setPrice(f.getPrice() * 2)).forEach(System.out::println);

}

private static void example5() {
    List<Fish> array = new ArrayList<>();
    array.add(new Fish("карась", 1, 120));
    array.add(new Fish("окунь", 4, 121));
    array.add(new Fish("щука", 2, 120));
    array.add(new Fish("щука", 3, 120));

    array.stream().filter(f -> f.getPrice() > 120).forEach(f -> f.setPrice(f.getPrice() * 0.9));

    array.forEach(System.out::println);
}

private static void example4() {
    List<Fish> array = new ArrayList<>();
    array.add(new Fish("карась", 1, 120));
    array.add(new Fish("окунь", 4, 121));
    array.add(new Fish("щука", 2, 120));
    array.add(new Fish("щука", 3, 120));

    array.forEach(fish -> {
        if (fish.getPrice() > 120) {
            System.out.println(fish);
        }
    });
}

private static void example3() {
//    Predicate<Fish> predicate = new Predicate<Fish>() {
//        @Override
//        public boolean test(Fish fish) {
//            return fish.getWeight() > 3;
//        }
//    };

    List<Fish> array = new ArrayList<>();
    array.add(new Fish("карась", 1, 120));
    array.add(new Fish("окунь", 4, 121));
    array.add(new Fish("щука", 2, 120));
    array.add(new Fish("щука", 3, 120));

    System.out.println(array);
    getByPredicate(array, f -> f.getWeight() > 2, f -> f.getPrice() == 120);
}

public static void getByPredicate(List<Fish> array, Predicate<Fish> predicate1, Predicate<Fish> predicate2) {
    array.stream().filter(fish -> predicate1.and(predicate2).test(fish)).forEach(System.out::println);
}

private static void example2() {
    List<Fish> array = new ArrayList<>();
    array.add(new Fish("карась", 1, 120));
    array.add(new Fish("окунь", 4, 121));
    array.add(new Fish("щука", 2, 120));
    array.add(new Fish("щука", 3, 120));

    System.out.println(array);

//    array.sort(new Comparator<Fish>() {
//        @Override
//        public int compare(Fish f1, Fish f2) {
//            return (int) f1.getWeight() * 100 - (int) f2.getWeight() * 100;
//        }
//    });

    array.sort((f1, f2) -> (int) f1.getWeight() * 100 - (int) f2.getWeight() * 100);
    System.out.println(array);

}

private static void example1() {
    Group pinkFloyd = new Group() {
        @Override
        public String bestAlbum() {
            return "Wish You Were Here";
        }
    };
    String album = pinkFloyd.bestAlbum();
    System.out.println(album);
    showGroup(pinkFloyd);
}

public static void showGroup(Group group) {
    System.out.println(group.bestAlbum());
}

