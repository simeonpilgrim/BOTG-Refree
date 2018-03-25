using System;
using System.Collections.Generic;

namespace BOTG_Refree
{
    public class LaneUnit : Unit
    {
        Point targetPoint;
        Unit aggroUnit;
        int aggroTimeLeft;
        double aggroTset;

        public LaneUnit(double x, double y, int health, int team, int moveSpeed, Point targetPoint, Player player) : base(x, y, health, team, moveSpeed, player)
        {
            this.targetPoint = targetPoint;
        }

        override void afterRound()
        {
            base.afterRound();
            aggroTimeLeft--;
        }

        override public string getType()
        {
            return "UNIT";
        }

        void findAction()
        {
            if (isDead || stunTime > 0) return;
            if (aggroUnit != null && aggroTimeLeft > 0 && Distance(aggroUnit) < Const.AGGROUNITRANGE && aggroUnit.visible)
            {
                attackUnitOrMoveTowards(aggroUnit, 0.0);
                return;
            }

            aggroTset = 1.0;
            aggroUnit = null;
            aggroTimeLeft = -1;

            Unit closest = findClosestOnOtherTeam("UNIT");
            if (canAttack(closest))
            {
                fireAttack(closest);
            } else if (closest != null && distance2(closest) < Const.AGGROUNITRANGE2)
            {
                attackUnitOrMoveTowards(closest, 0);
            } else
            {
                closest = findClosestOnOtherTeam("HERO");
                if (canAttack(closest))
                {
                    fireAttack(closest);
                } else if (closest != null && distance2(closest) < Const.AGGROUNITRANGE2 && allowedToAttack(closest))
                {
                    attackUnitOrMoveTowards(closest, 0);
                } else
                {
                    moveAttackTowards(targetPoint);
                }
            }
        }
    }
}
