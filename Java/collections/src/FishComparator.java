import java.util.Comparator;

public class FishComparator implements Comparator<Fish> {
    @Override
    public int compare(Fish o1, Fish o2) {
        return (int)(o1.getWeight() * 100 - o2.getWeight() * 100);
    }
}
