import java.io.Serializable;

public class Fish implements Serializable /*implements Comparable<Fish>*/ {
    private String name;
    private double weight;
    private double price;

    public Fish(String name, double weight, double price) {
        this.setName(name);
        this.setWeight(weight);
        this.setPrice(price);
    }

    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Fish f)) return false;

        return f.getName().equals(this.getName()) &&
                f.getPrice() == this.getPrice() &&
                f.getWeight() == this.getWeight();
    }

    public int hashCode() {
        int code = 17;
        code = 31 * code + this.getName().hashCode();
        code = 31 * code + (int) this.getWeight();
        code = 31 * code + (int) this.getPrice();
        return code;
    }

    @Override
    public String toString() {
        return getName() + " " + getWeight() + " " + getPrice();
    }

//    @Override
//    public int compareTo(Fish o) {
//        return (int)(getPrice() * 100 - o.getPrice() * 100);
//    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getWeight() {
        return weight;
    }

    public void setWeight(double weight) {
        this.weight = weight;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }
}