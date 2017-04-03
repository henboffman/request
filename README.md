<div>
  <h1>reQuest Documentation</h1>
  <h3>Todo</h3>
  <ul>
    <li>Separate each category into a tab</li>
    <li>Enemies</li>
    <li>Armor</li>
    <li>Items</li>
    <li>Weapons - projectiles</li>
    <li>Elemental damage</li>
    <li>Blue weapons (prefix/suffix)</li>
    <li>Orange Weapons</li>
    <li>Purple Weapons</li>
    <li>Environments</li>
    <li>Rooms</li>
    <li>Random Generator</li>
    <li>Experience/levels</li>
    <li>Customization</li>
    <li>Drop rate</li>
    <li>Auction House</li>
    <li>Display average damage of weapons for a selected type on weapon create screen</li>    
  </ul>

  <h3>Ideas</h3>
  <ul>
    <li>Very expensive item that passively quests with chance of items. Levels like a regular player (it's basically a diablo 2 bot) but requires maintenance</li>
    <li>Auction house</li>
    <li>Emphasis on visual/audio of gaining experience/leveling</li>
  </ul>

  <h2>Notes</h2>
  <div>
    <h3>Adding new tables</h3>
    <ol>
      <li>design table in excel</li>
      <li>identify dependencies/foreign keys</li>
      <li>create table in SQL</li>
      <li>add relationships if needed</li>
      <li>Create new scaffolded controller (webapi 2 w/ EF)</li>
      <li>Add methods (get all, create) to dataservice</li>
      <li>Add functionality to gamedata site</li>
    </ol>
    <h3>Monsters</h3>
    <span> In multiplayer, when a monster is created, its Hit Points are multiplied by the number of players in the game: (Life = Hit Points * (Number of Players + 1) / 2). The monster's base experience value is determined by the following formula:
Experience = X * (n + 1) / 2</span>
  </div>
</div>
