using System;
using System.Collections.Generic;

namespace BOTG_Refree
{

    public class Hero : Unit {

        public Skills.SkillBase[] skills = new Skills.SkillBase[Const.SKILLCOUNT];
        public string heroType;
        public int mana;
        public int manaregeneration;
        public int maxMana;
        int channeling;
        int visibilityTimer;
        public List<Item> items = new List<Item>();
        string avatar = Const.MAGEAVATAR;

        public Hero(double x, double y, int health, int team, int moveSpeed, Player player, string heroType) : base(x, y, health, team, moveSpeed, player)
        {
            this.goldValue = Const.HERO_GOLD_VALUE;
            this.heroType = heroType;
            this.channeling = 0;
        }

        override void afterRound() {
            base.afterRound();
            visibilityTimer = Math.max(0, visibilityTimer - 1);
            mana += manaregeneration;
            if (mana > maxMana) mana = maxMana;
            for (Skills.SkillBase skill : skills) {
                if (skill == null) continue;
                skill.cooldown = Math.max(0, skill.cooldown - 1);
            }
        }

        void addItem(Item item) {
            if (item == null) {
                return;
            }

            addCharacteristics(item, 1);
            if (!item.isPotion) {
                items.Add(item);
            }
        }

        void removeItem(Item item) {
            if (!items.Contains(item)) return;
            items.Remove(item);
            addCharacteristics(item, -1);
        }

        void addCharacteristics(Item item, int amplitude) {
            Map<string, Integer> characteristics = item.stats;
            Class <?> c = this.getClass();
            characteristics.forEach((k, v) -> {
                try {
                    Field f = c.getDeclaredField(k);
                    f.set(this, f.getInt(this) + v * amplitude);
                } catch (Exception e) {
                }
            });

            Class <?> c2 = this.getClass().getSuperclass();
            characteristics.forEach((k, v) -> {
                try {
                    Field f = c2.getDeclaredField(k);
                    f.set(this, f.getInt(this) + v * amplitude);
                } catch (Exception e) {
                }
            });

            if (mana > maxMana) mana = maxMana;
            if (health > maxHealth) health = maxHealth;
            if (mana < 0) mana = 0;
            if (health <= 0) health = 1;
            if (moveSpeed > Const.MAXMOVESPEED) moveSpeed = Const.MAXMOVESPEED;
        }

        public bool isVisible(Player player) {
            return (!isDead && (visible || player == this.player));
        }

        override
        public string getType() {
            return "HERO";
        }

        override
        protected string getExtraProperties() {
            return
                skills[0].cooldown + " " +
                skills[1].cooldown + " " +
                skills[2].cooldown + " " +
                mana + " " +
                maxMana + " " +
                manaregeneration + " " +
                heroType + " " +
                (visible ? 1 : 0) + " " +
                items.Count;
        }
    }

}