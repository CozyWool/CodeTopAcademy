package classesExample;

public class Aspirant extends Student {
    private String workName;

    public Aspirant(String fullName, int age, String workName) {
        super(fullName, age);
        setWorkName(workName);
    }

    public String getWorkName() {
        return workName;
    }

    public void setWorkName(String workName) {
        this.workName = workName;
    }

    @Override
    public String toString() {
        return super.toString() + " " + workName;
    }

    @Override
    public void recovered() {
        System.out.printf("Аспирант %s восстановился\n", getFullName());
    }

}
