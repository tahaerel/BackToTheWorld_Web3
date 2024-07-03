public class Miner
{
    public int level;
    public float miningCost;

    public Miner(int level)
    {
        this.level = level;
        this.miningCost = level * 10; 
    }
}
