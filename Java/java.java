// start
// definition
public interface MyComparator {
    boolean compare(int a1, int a2);
}

// usage
HashMap<String, MyComparator> hashMap = new HashMap<>();
hashMap.put("", new MyComparator() {
    @Override
    public boolean compare(int a1, int a2) {
        System.out.println("" + a1 + ":" + a2);
        return false;
    }
});
hashMap.get("").compare(0, 2);
// end
