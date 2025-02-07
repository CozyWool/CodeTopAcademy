package classesExample;

public class Student {
    private String fullName;
    private int age;

    public Student(String fullName, int age) {
        setFullName(fullName);
        setAge(age);
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    @Override
    public String toString() {
        return fullName + " " + age;
    }

    public final void deduction(){
        System.out.printf("Студент %s отчислился\n", fullName);
    }

    public void recovered(){
        System.out.printf("Студент %s восстановился\n", fullName);
    }
}
