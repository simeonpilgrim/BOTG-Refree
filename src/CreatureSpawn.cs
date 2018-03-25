namespace BOTG_Refree
{
    public class CreatureSpawn : Point
    {
        CreatureSpawn(int x, int y): base(x,y)
        {
        }

        public string getPlayerString()
        {
            return "SPAWN " + (int)x + " " + (int)y + " 0";
        }
    }
}