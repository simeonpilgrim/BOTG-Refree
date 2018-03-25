using System.Collections.Generic;

namespace BOTG_Refree
{
    public enum CreatureState
    {
        peacefull, runningback, aggressive
    }

    public class Creature : Unit {

        Point camp;
        public CreatureState state = CreatureState.peacefull;
        string creatureType;
        public Creature(double x, double y) : base(x, y, 1, -1, 300, null)
        {
            this.camp = new Point(x, y);
        }

        override public string getType() {
            return this.creatureType;
        }


        void findAction(List<Unit> allUnits) {
            if (isDead || stunTime > 0) return;
            if (this.state == CreatureState.aggressive) {
                aggressiveBehavior(allUnits);
            } else if (this.state == CreatureState.runningback) {
                runningBackBehavior();
            }
        }

        void aggressiveBehavior(List<Unit> allUnits) {
            Unit attacker = allUnits.stream()
                    .filter(u->u instanceof Hero)
                    .sorted((u1, u2) ->u1.Distance2(this) < u2.Distance2(this) ? -1 : 1)
                    .findFirst()
                    .get();
            Point target = attacker;
            if (Distance2(camp) < Const.AGGROUNITRANGE2) {
                this.attackUnitOrMoveTowards((Unit)target, 0.0);
            } else {
                this.state = CreatureState.runningback;
                this.runTowards(camp);
            }
        }

        void runningBackBehavior() {
            this.runTowards(camp);
            if (Distance(camp) < 2) {
                this.state = CreatureState.peacefull;
                this.health = maxHealth;
                //Const.viewController.addEffect(this, this, "default", 0);
            }
        }
    }
}