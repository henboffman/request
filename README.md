# reQuest Documentation
## Todo

* Separate each category into a tab
* Enemies
* Armor
* Items
* Weapons - projectiles
* Elemental damage
* Blue weapons (prefix/suffix)
* Orange Weapons
* Purple Weapons
* Environments
* Rooms
* Random Generator
* Experience/levels
* Customization
* Drop rate
* Auction House
* Display average damage of weapons for a selected type on weapon create screen


## Ideas

* Very expensive item that passively quests with chance of items. Levels like a regular player (it's basically a diablo 2 bot) but requires maintenance
* Auction house
* Emphasis on visual/audio of gaining experience/leveling


## Notes


### Adding new tables

1. design table in excel
2. identify dependencies/foreign keys
3. create table in SQL
4. add relationships if needed
5. update edmx model
6. Create new scaffolded controller (webapi 2 w/ EF)
7. Add methods (get all, create) to dataservice
8. Add functionality to gamedata site

### Monsters
In multiplayer, when a monster is created, its Hit Points are multiplied by the number of players in the game: (Life = Hit Points * (Number of Players + 1) / 2). The monster's base experience value is determined by the following formula:
Experience = X * (n + 1) / 2


