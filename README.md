# jamboard:
## Realtime Roller Derby Penalty Tracking 
a class project for &lt;code Louisville&gt;

## Introducing Roller Derby

Like Basketball, Roller derby is team sport with two teams of five players each. Unlike most team games, both teams are simultaneously playing offense and defense. The game is played on an oval track. Player are referred to as 'skaters'. One special skater for each team is the 'jammer', and she scores points by lapping members of the opposing team. Various rules conspire to keep non-jammer skaters - called 'blockers' - from moving as fast as the jammers, so the game becomes a full-contact sport rather than a speed skating contest. 

Games are subdivided 'jams' (like 'plays' in football). Typically, each skater substitutes out at the end of every jam.  Simply recording who is in play is a full-time job for two different officials - one keeps track of each team's fielded skaters. 

## Introducing jamboard

Jamboard is proof-of-concept for a web-and-tablet-based, multi-headed, real time skater tracking system. Unlike most projects, it's intended to run on an intranet, with a database with less than 1000 rows total. Arguably, it should instead have been a server of _not_-http, just sitting on some port listening for tcp connections, reading configuration files and grinding out log files as output, with the UI done by a few mobile apps. That would certainly be more performant. But hey, http / html is very portable, and nobody hires people to write that kind of application anymore, and there's no class in it I need to pass, so the http / html architecture is defensible. :)
