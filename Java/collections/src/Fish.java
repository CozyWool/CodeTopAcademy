public class Fish implements Comparable<Fish>{
    private String name;
    private double weight;
    private double price;

    public Fish(String name, double weight, double price) {

        this.name = name;
        this.weight = weight;
        this.price = price;
    }


    @Override
    public String toString() {
        return name + " " + getWeight() + " " + getPrice();
    }

    @Override
    public int hashCode() {
        int code = 23;
        code = 31 * code + this.name.hashCode();
        code = 31 * code + (int) this.getWeight();
        code = 31 * code + (int) this.getPrice();
        return code;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Fish)) return false;
        Fish f = (Fish) o;
        return f.name == this.name && f.getPrice() == this.getPrice() && this.getWeight() == f.getWeight();
    }

    @Override
    public int compareTo(Fish o) {
        return (int)(getPrice() * 100 - o.getPrice() * 100);
    }

    public double getWeight() {
        return weight;
    }

    public double getPrice() {
        return price;
    }
}

