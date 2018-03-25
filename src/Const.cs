namespace BOTG_Refree
{
    public class Const
    {
        public static System.Random random;

        public static int MAXINT = int.MaxValue;
        public static double MAXDOUBLE = double.MaxValue;

        public static bool REMOVEFORESTCREATURES = false;
        public static bool IGNOREITEMS = false;
        public static bool IGNORESKILLS = false;
        public static double TOWERHEALTHSCALE = 1.0;
        public static bool IGNOREBUSHES = false;
        public static int TOWERDAMAGE = 190;

        //MISC
        public static double EPSILON = 0.00001;
        public static double ROUNDTIME = 1.0;
        public static int Rounds = 250;
        public static int MAPWIDTH = 1920;
        public static int MAPHEIGHT = 780;
        public static int HEROCOUNT = 2;
        public static int MAXITEMCOUNT = 4;
        public static int MELEE_UNIT_COUNT = 3;
        public static int RANGED_UNIT_COUNT = 1;
        public static double SELLITEMREFUND = 0.5;

        //TEAM0
        public readonly static Point TOWERTEAM0 = new Point(100, 540);
        public readonly static Point SPAWNTEAM0 = new Point(TOWERTEAM0.x + 60, TOWERTEAM0.y - 50);
        public readonly static Point HEROSPAWNTEAM0 = new Point(TOWERTEAM0.x + 100, TOWERTEAM0.y + 50);
        public readonly static Point HEROSPAWNTEAM0HERO2 = new Point(HEROSPAWNTEAM0.x, TOWERTEAM0.y - 50);

        //TEAM1
        public readonly static Point TOWERTEAM1 = new Point(MAPWIDTH - TOWERTEAM0.x, TOWERTEAM0.y);
        public readonly static Point SPAWNTEAM1 = new Point(MAPWIDTH - SPAWNTEAM0.x, SPAWNTEAM0.y);
        public readonly static Point HEROSPAWNTEAM1 = new Point(MAPWIDTH - HEROSPAWNTEAM0.x, HEROSPAWNTEAM0.y);
        public readonly static Point HEROSPAWNTEAM1HERO2 = new Point(HEROSPAWNTEAM1.x, HEROSPAWNTEAM0HERO2.y);

        //HERO
        public static int SKILLCOUNT = 3;
        public static int MAXMOVESPEED = 450;

        //UNIT
        public static int SPAWNRATE = 15;
        public static int UNITTARGETDISTANCE = 400;
        public static int UNITTARGETDISTANCE2 = UNITTARGETDISTANCE * UNITTARGETDISTANCE;
        public static int AGGROUNITRANGE = 300;
        public static int AGGROUNITRANGE2 = AGGROUNITRANGE * AGGROUNITRANGE;
        public static int AGGROUNITTIME = 3;
        public static double DENYHEALTH = 0.4;

        public static double BUSHRADIUS = 50;

        //TOWERS
        public static int TOWERHEALTH = 3000;

        //NEUTRAL CREEP
        public static int NEUTRALSPAWNTIME = 4;
        public static int NEUTRALSPAWNRATE = 40;
        public static int NEUTRALGOLD = 100;

        //SPELLS
        // KNIGHT
        public static double EXPLOSIVESHIELDRANGE2 = 151 * 151;
        public static int EXPLOSIVESHIELDDAMAGE = 50;

        // LANCER
        public static int POWERUPMOVESPEED = 0;
        public static double POWERUPDAMAGEINCREASE = 0.3;
        public static int POWERUPRANGE = 10;

        //GOLD UNIT VALUES
        public static int MELEE_UNIT_GOLD_VALUE = 30;
        public static int RANGER_UNIT_GOLD_VALUE = 50;
        public static int HERO_GOLD_VALUE = 300;

        public static int GLOBAL_ID = 1;


        //GRAPHICS
        // Hero sprites
        public static string IRONMAN = "iron-man.png";
        public static string HULK = "hulk.png";
        public static string VALKYRIE = "valkyrie.png";
        public static string DEADPOOL = "deadpool.png";
        public static string DOCTOR_STRANGE = "doc-strange.png";

        // avatars
        public static string MAGEAVATAR = "mage.png";

        // environment sprites
        public static string BACKGROUND = "background.jpg";
        public static string BUSH = "bush-orbs.png";

        // neutral creep
        public static string GROOT = "groot.png";

        // team based sprites
        public static string BLUETOWER = "tower-blue.png";
        public static string REDTOWER = "tower-red.png";

        // Items
        public static string POTION = "potion.png";

        //ITEM STATS
        public static string DAMAGE = "damage";
        public static string HEALTH = "health";
        public static string MAXHEALTH = "maxHealth";
        public static string MAXMANA = "maxMana";
        public static string MANA = "mana";
        public static string MOVESPEED = "moveSpeed";
        public static string MANAREGEN = "manaregeneration";
        public static string[] STATS = { DAMAGE, HEALTH, MANA, MOVESPEED, MANAREGEN };
        public static int MINIMUM_STAT_COST = 30;
        public static int NB_ITEMS_PER_LEVEL = 5;


        //Container
        public static Game game = new Game();
        public static MapFactory mapFactory = new MapFactory();

    }
}
