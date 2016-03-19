# jamboard:
## Realtime Roller Derby Penalty Tracking 
a class project for &lt;code Louisville&gt;

## Introducing Roller Derby

Like Basketball, Roller derby is team sport with two teams of five players each. Unlike most team games, both teams are simultaneously playing offense and defense. The game is played on an oval track. Player are referred to as 'skaters'. One special skater for each team is the 'jammer', and she scores points by lapping members of the opposing team. Various rules conspire to keep non-jammer skaters - called 'blockers' - from moving as fast as the jammers, so the game becomes a full-contact sport rather than a speed skating contest. 

Games are subdivided 'jams' (like 'plays' in football). Typically, each skater substitutes out at the end of every jam.  Simply recording who is in play is a full-time job for two different officials - one keeps track of each team's fielded skaters. 

## Introducing jamboard

Jamboard is proof-of-concept for a web-and-tablet-based, multi-headed, real time skater tracking system. Unlike most projects, it's intended to run on an intranet, with a database with less than 1000 rows total. Arguably, it should instead have been a server of _not_-http, just sitting on some port listening for tcp connections, reading configuration files and grinding out log files as output, with the UI done by a few mobile apps. That would certainly be more performant. But hey, http / html is very portable, and nobody hires people to write that kind of application anymore, and there's no class in it I need to pass, so the http / html architecture is defensible. :)

## Workflow

Prior to a game, both teams submit rosters of players. Teams and players are entered into the DB by officials. Note that running the db-initalizing migration will seed the db with two teams and dozens of players. In a real game, these tables would have to be dropped before real data entry. But the idea is to make it easier for &lt;Code Louisville&gt; reviewers. 

Prior to every jam, an official for each team records that team's fielded skaters.

## Data Model

Building the data model from C# using Code First and Entity Framework 6 consisted of the bulk of my time spent on this project. Here is the model:

There are many Teams. Since games are between two teams, one might expect there to a a hard limit of 2 somewhere. But there isn't. There's just a potential sea of teams. 

#### Many-to-One Relationships

Teams have many skaters. Skaters belong to exactly one team. 

Jams belong to exactly one team. Teams have many jams. In "the real world", a jam doesn't belong to one team or the other. But I tagged a "jam" object with a team to allow each tablet-weilding official to do simultaneous data-entry, and have some blindingly obvious way of telling each other's work apart. 

These relationships were specified in C# model files, were detected by Entity Framework, and are compiled into the database schema by a 'code first migration' included in this repository. 

Controller and View scaffolding was generated and tweaked to allow the user to edit teams, skaters, and jams. Nearly full CRUD is supported. See 'Pictures of CRUD' below

#### The Many-to-Many Relationship

Skaters participate in many jams. Jams have five skaters, though internally it's of course any number. This is a classic many-to-many relationship. 

This relationship was specified in C# model files, was detected by Entity Framework, and is compiled into the database schema by a 'code first migration' included in this repository. This includes the SkaterJams join table. 

Since SkaterJams is an implementation detail, and not a UI concept we want to put in the user's face, I didn't generate a controller or views for SkaterJams. Instead, the SkaterJam rows are manipulated implicitly through the CRUD of Jams. 


#### Pictures of CRUD


#### CRUD Warts

###### The Cascading Delete Cycle Issue

I made the decision to not support deletion of teams from the web interface. The way I understand it is this: leaving it in was causing a cascading delete cycle: Deleting a team deletes all it's skaters (reasonable), and deletes all it's jams (also reasonable). Deleting either a skater or a jam should delete any associated skaterJams (also, also reasonable). But having a skaterJam deletable from two different directions causes SQL to refuse to play ball with the whole sequence of cascading deletes.

To break the cycle, I tried to move the automatic deletions from SQL Server into the C# code's deletion method. I disabled cascading deletes for teams to jams and skaters, and did it in code. I was getting all kinds of complaints about trashing lists as I was iterating through them, null pointer exceptions, and whatnot. In the interest of time I decided to fall back to removing deletion of teams from the web interface. So Teams don't have full web CRUD. They just have 'CRU'. 

###### Jams
SkateJams are created implicitly via the web interface for creating Jams. I barely had time to make this interface work. It uses a ugly multiple-select list box. The original plan was to have a pretty grid of buttons representing players, but I ran out of time. I also didn't have time to support update of Jams, which isn't terrible - they can be 'updated' through delete-then-create, but I think it's worth mentioning. 

###### Lack of Polished CRUD
In general the views are not polished or pretty. They're proof-of-concept that the database works. Since massaging CSS is grunt work for me at this point, but learning a new MVC framework is uncertain and difficult, I prioritized the scary and hard thing. Thus stuff I'm actually good at remains undone, and stuff that was hard barely works.


#### ViewBags and ViewModels
