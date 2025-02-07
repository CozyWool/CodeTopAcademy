public static void main(String[] args) {
    while (true) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Введите номер задания (1 - 12, 0 - выход): ");
        int n = scanner.nextInt();
        switch (n) {
            case 1, 2:
                task1();
                break;
            case 3:
                task3();
                break;
            case 4:
                task4();
                break;
            case 5:
                task5();
                break;
            case 6:
                task6();
                break;
            case 7:
                task7();
                break;
            case 0:
                System.out.println("Пока!");
                return;
        }
    }
}

private static void task7() {
    Scanner scanner = new Scanner(System.in);
//    System.out.print("Введите название файла(с расширением): ");
//    var fileName = scanner.next();
    var fileName = "input.txt";
    System.out.print("Введите запрещенные слова через пробел: ");
    var restrictedWords = scanner.nextLine().split(" ");
    var hashMap = new HashMap<String, Integer>();
    for (var word : restrictedWords) {
        hashMap.put(word, 0);
    }

    var path = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName;

    System.out.println("\tСодержимое файла");
    StringBuilder resultLine = new StringBuilder();
    try (var in = new BufferedReader(new FileReader(path))) {
        String line;
        while ((line = in.readLine()) != null) {
            System.out.println(line);
            for (var word : restrictedWords) {
                var result = deleteWordFromLine(line, word);
                hashMap.put(word, hashMap.get(word) + result.counter);
                line = result.line;
            }
            resultLine.append(line).append("\n");
        }
    } catch (IOException e) {
        e.printStackTrace();
    }
    for (var entry : hashMap.entrySet()) {
        var word = entry.getKey();
        var counter = entry.getValue();
        System.out.printf("Слово %s удалено в файле %d раз\n", word, counter);
    }

    var outputPath = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + "outputTask7.txt";

    try (var out = new BufferedWriter(new FileWriter(outputPath))) {
        out.write(resultLine.toString());
    } catch (IOException e) {
        e.printStackTrace();
    }
}

private static MyResult deleteWordFromLine(String line, String searchedWord) {
    var counter = 0;
    int index = line.indexOf(searchedWord);
    if (index != -1) {
        line = line.substring(0, index).trim() + line.substring(index + searchedWord.length()).trim();
        counter++;
    }
    return new MyResult(line, counter);
}

private static class MyResult {
    public String line;
    public int counter;

    public MyResult(String line, int counter) {
        this.line = line;
        this.counter = counter;
    }
}

private static void task6() {
    var fileName1 = "input.txt";
    var fileName2 = "input2.txt";
    var fileName3 = "input3.txt";
    var path1 = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName1;
    var path2 = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName2;
    var path3 = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName3;
    var outputPath = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + "output.txt";

    var resultLine = getLineFromFile(path1) + getLineFromFile(path2) + getLineFromFile(path3);

    try (var out = new BufferedWriter(new FileWriter(outputPath))) {
        out.write(resultLine);
        long bytesRead = Files.size(Path.of(path1)) + Files.size(Path.of(path2)) + Files.size(Path.of(path3));
        System.out.println("Прочитано байт: " + bytesRead);
    } catch (IOException e) {
        e.printStackTrace();
    }
}

private static String getLineFromFile(String path) {
    StringBuilder result = new StringBuilder();
    try (var in = new BufferedReader(new FileReader(path))) {
        String line;
        while ((line = in.readLine()) != null) {
            result.append(line).append(System.lineSeparator());
        }
    } catch (IOException e) {
        e.printStackTrace();
    }
    return result.toString();
}

private static void task5() {
    Scanner scanner = new Scanner(System.in);
//    System.out.print("Введите название файла(с расширением): ");
//    var fileName = scanner.next();
    var fileName = "input.txt";
    System.out.print("Введите искомое слово: ");
    var searchedWord = scanner.next();
    System.out.print("Введите слово, на которое нужно заменить: ");
    var replaceWord = scanner.next();
    var path = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName;
    var counter = 0;

    System.out.println("\tСодержимое файла");
    try (var in = new BufferedReader(new FileReader(path))) {
        String line;
        while ((line = in.readLine()) != null) {
            int index = line.indexOf(searchedWord);
            if (index != -1) {
                line = line.substring(0, index) + replaceWord + line.substring(index + searchedWord.length());
                counter++;
            }
            System.out.println(line);
        }
    } catch (IOException e) {
        e.printStackTrace();
    }
    System.out.printf("\nСлово %s заменено на %s в файле %d раз\n", searchedWord, replaceWord, counter);
}

private static void task4() {
//    Scanner scanner = new Scanner(System.in);
    //    System.out.print("Введите название файла(с расширением): ");
//    var fileName = scanner.next();
    var fileName = "input.txt";
    var path = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName;
    var letterCounter = 0;
    var digitsCounter = 0;
    var punctuationCounter = 0;
    var punctuationSigns = "!?.,;:()\"'/_-[]";

    System.out.println("\tСодержимое файла");
    try (var in = new BufferedReader(new FileReader(path))) {
        int ch;
        while ((ch = in.read()) != -1) {
            letterCounter += Character.isLetter(ch) ? 1 : 0;
            digitsCounter += Character.isDigit(ch) ? 1 : 0;
            punctuationCounter += punctuationSigns.indexOf(ch) != -1 ? 1 : 0;
            System.out.print((char) ch);
        }
        System.out.println();
    } catch (IOException e) {
        e.printStackTrace();
    }
    System.out.println("\nКол-во букв: " + letterCounter);
    System.out.println("Кол-во цифр: " + digitsCounter);
    System.out.println("Кол-во знаков препинания: " + punctuationCounter);
}

private static void task3() {
    Scanner scanner = new Scanner(System.in);
//    System.out.print("Введите название файла(с расширением): ");
//    var fileName = scanner.next();
    var fileName = "input.txt";
    System.out.print("Введите искомое слово: ");
    var searchedWord = scanner.next();
    var path = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName;
    var counter = 0;

    System.out.println("\tСодержимое файла");
    try (var in = new BufferedReader(new FileReader(path))) {
        String line;
        while ((line = in.readLine()) != null) {
            if (line.toLowerCase().contains(searchedWord.toLowerCase())) {
                counter++;
            }
            System.out.println(line);
        }
    } catch (IOException e) {
        e.printStackTrace();
    }
    System.out.printf("\nСлово %s встречается в файле %d раз\n", searchedWord, counter);
}

private static void task1() {
//    Scanner scanner = new Scanner(System.in);
    //    System.out.print("Введите название файла(с расширением): ");
//    var fileName = scanner.next();
    var fileName = "input.txt";
    var path = System.getProperty("user.dir") + FileSystems.getDefault().getSeparator() + fileName;
    try (var in = new BufferedReader(new FileReader(path))) {
        String line;
        while ((line = in.readLine()) != null) {
            System.out.println(line);
        }
    } catch (IOException e) {
        e.printStackTrace();
    }
}
