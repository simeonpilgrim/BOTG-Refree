TEAM-1 (Wildum, Illedan and AntiSquid)
# Botters of the Galaxy

There will be no other bugfixes, unless they are critical.

Content:
- Balance notes multi
- Balance notes
- Bugs
- Unit stats
- Skill stats
- Item information
- Game loop
- Attacktime

## Balance notes
- Towers deal 190 damage.
- Lane units select first an enemy unit as target and then an enemy hero as target if not aggroed.
- Item maximum cost reduced from 1500 to 1200. Legendary items should now be easier to purchase.

## Balance notes
- VALKYRIE JUMP cast time increased to 0.15. 
- Burning ground damage increased to 5*manaregn + 30
- DR. Strange pull has ranged increased to 400
- Dr. Strange shield is now 0.5*maxmana + 50 and has a manacost of 40
- HULK CHARGE lowered range to 300 and reduced his damage when landing to 50%. Still -150 movespeed

## Bugs

Known bugs:
- VALK jumping closest to an invisible unit will try to attack the invisible unit(and be denied the action) while there was an availiable target.
- Pull does not allways pull. 

Fixed:
- Wire does now stuns correctly. (is updated during thursday)
- Can move / bash tower
- Mana used in Burning ground and AOE heal now uses mana at time of usage.
- Inputs with stunned allied
- Attacking a unit when distance to the unit matches hero's range. (exact match at start of turn)
	- This caused the hero to move towards the target.
- Possible to deny your allied unit if it has 40% of your hero's maxhp. 
   - It is intended to be 40% of the unit's maxhp. (This check is done when the attack starts.)
- Valkyrie no longer deals damage to allied units when flipping them
- Fireball doesn't allways hit targets, because of a rounding error.
- Dead hero in a bush, makes enemies in the same bush visible. Lasts the rest of the game.
- Printing `MOVE NaN NaN`
- 2 heroes killing a forrest creature at the exact same time with equal damage. Gives right player the kill.
   - Both players will get 100% of the gold.
- Missing cast times and some invalid durations in the Statement.
- Printing `MOVE Infinity Infinity`

## Stats
 - Generated by PrintStats
### UNITS:

|TYPE|MEELE|HEALTH|DAMAGE|RANGE|MOVESPEED|ATTACKTIME|GOLD|MANA|MANAREG|
|--|--|--|--|--|--|--|--|--|--|
|TOWER|false|3000|190|400|0|0.2|0|0|0|
|UNIT|true|400|25|90|150|0.2|30|0|0|
|UNIT|false|250|35|300|150|0.2|50|0|0|
|GROOT|true|400|35|150|250|0.2|100|0|0|
|HERO-VALKYRIE|true|1400|65|130|200|0.1|300|155|2|
|HERO-DEADPOOL|true|1380|80|110|200|0.1|300|100|1|
|HERO-IRONMAN|false|820|60|270|200|0.1|300|200|2|
|HERO-DOCTOR_STRANGE|false|955|50|245|200|0.1|300|300|2|
|HERO-HULK|true|1450|80|95|200|0.1|300|90|1|

### SKILLS:

|HERO|NAME|MANACOST|COOLDOWN|DURATION|CASTTIME|RANGE|TARGETTYPE|TARGETTEAM|
|--|--|--|--|--|--|--|--|--|
|VALKYRIE|SPEARFLIP|20|3|1|0.0|155|UNIT|BOTH|
|VALKYRIE|JUMP|35|3|1|0.15|250|POSITION|ENEMY|
|VALKYRIE|POWERUP|50|7|4|0.0|0|SELF|NONE|
|DEADPOOL|COUNTER|40|5|1|0.0|350|SELF|ENEMY|
|DEADPOOL|WIRE|50|9|2|0.0|200|POSITION|ENEMY|
|DEADPOOL|STEALTH|30|6|5|1.0|0|POSITION|NONE|
|IRONMAN|BLINK|16|3|1|0.05|200|POSITION|NONE|
|IRONMAN|FIREBALL|60|6|1|0.0|900|POSITION|ENEMY|
|IRONMAN|BURNING|50|5|1|0.01|250|POSITION|ENEMY|
|DOCTOR_STRANGE|AOEHEAL|50|6|1|0.01|250|POSITION|ALLIED|
|DOCTOR_STRANGE|SHIELD|40|6|3|0.0|500|UNIT|ALLIED|
|DOCTOR_STRANGE|PULL|40|5|1|0.1|400|UNIT|BOTH|
|HULK|CHARGE|20|4|1|0.05|300|UNIT|ENEMY|
|HULK|EXPLOSIVESHIELD|30|8|4|0.0|100|SELF|ENEMY|
|HULK|BASH|40|10|2|0.1|150|UNIT|ENEMY|

### ITEMS:

|STAT|PRICE|MAXCOUNT|
|--|--|--|
|damage|7.2|100000000|
|health|0.7|2500|
|mana|0.5|100|
|moveSpeed|3.6|150|
|manaregeneration|50.0|50|

### ITEM PRICERANGES:

Every game includes 3 potions: 500 health, 100 health and 50 mana.

Items in each pricerange: 5.


|PRICE RANGE|MIN|MAX|
|--|--|--|
|Bronze|50|200|
|Silver|200|550|
|Golden|550|1300|
|Legendary|1300|3000|

Formula used to calculate end price. This is done after the creation given a price range:
```
Math.max(Math.ceil(totalCost/2), Math.ceil(totalCost-(totalCost*totalCost/6000)))
```

## Game loop

```
void play() {
	SpawnLaneUnits();
	SpawnGroots();

	GetPlayerCommands();
	CreateEventsFromPlayerCommands();
	
	FindActionForLaneUnits();
	FindActionForTower();
	FindActionForGroot();
	
	RecalculateEventsIncludingMovingUnits();

	  double t = 0.0;

	  while (t <= 1.0) {
	  	CheckGameOver();
		
		FindNextEvent();
		
		MoveUnitsToEventTime();
		
		FindAllEventsAtSameTime();
		
		PlayEvents();
		
		HandleDamage();
		
		RecalculateEventsOfChangedUnits();
  	}
	
	MoveUnitsToT1();
	
	RemoveEventsNotValid(); 
	
	UpdateAfterRoundOnUnits(); // stun, cooldown, mana, visibility timer, rounding x/y
	
	UpdateVisibility();
}
```


## Attacktime

This method returns at what time your attack will hit a target, while assuming the target doesn't move.


```
public double AttackTime(Unit unit)
{
	var dist = Distance(unit);
	double t = 0;
	if (dist > attackRange)
	{
		t = (dist - attackRange) / movementSpeed;
		dist = attackRange;
	}

	t += attackTime;
	if (attackRange > 150)
	{
		t += attackTime * (dist / attackRange);
	}

	return t;
}

