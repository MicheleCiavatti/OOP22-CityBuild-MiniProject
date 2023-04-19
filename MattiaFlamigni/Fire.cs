public interface Fire {
    int calculateIntensity();

    void setCost();

    void spendGold(Player player, int cost);
    void performFireAction();
    int getCost();
}
