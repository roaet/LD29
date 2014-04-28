using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Tokens
* a = boy
* b = girl
* c = heart
* d = brokenheart
* e = nukes
* f = cat
* g = rainbowdash
* h = fire
* i = lightbulb
* j = world

* ----------------
* */
public enum StoryState
{ //LR Parsing
start/*done*/,
boy/*done*/,
boys/*done*/,
boyloves/*done*/,
boyslove/*done*/,
boyhappy/*done*/,
boyexcited,
boyhates/*done*/,
boyshate/*done*/,
boysenv/*done*/,
boysbreak/*done*/,
boysheal/*done*/,
boyanger/*done*/,
boybully/*done*/,
boydestruction/*done*/,
boyevil/*done*/,
rainbowboy/*done*/,
girl/*done*/,
girls/*done*/,
girlloves/*done*/,
girlhates/*done*/,
girlslove/*done*/,
girlhappy/*done*/,
girlexcited,
girlshate/*done*/,
girlsenv/*done*/,
girlsbreak/*done*/,
girlsheal/*done*/,
girlanger/*done*/,
girlbully/*done*/,
girldestruction/*done*/,
girlevil/*done*/,
rainbowgirl/*done*/,
romance/*done*/,
kids/*done*/,
baddate/*done*/,
honey/*done*/,
world/*done*/,
love/*done*/,
hate/*done*/,
scottpilgrim/*done*/,
jane/*done*/,
friends/*done*/,
passion/*done*/,
life/*done*/,
emo/*done*/,
bromance/*done*/,
bffs/*done*/,
nuke/*done*/,
panic/*done*/,
annihilation/*done*/,
unfortunate,
cat/*done*/,
litcat,
catwarm,
catscratch,
meow,
mreow,
biggles,
comfort/*done*/,
rainbow/*done*/,
rainbowdash/*done*/,
rainbowblush/*done*/,
rainbowpower/*done*/,
rainbowpowertwo/*done*/,
rainbowwarrior/*done*/,
rainbowsaveone/*done*/,
rainbowsavetwo/*done*/,
rainbowsavethree/*done*/,
rainbowsavior,
rainbowsad,
rainbowhoney/*done*/,
rainbowdashpilgrimforce,
megabadascott,
videogameviolence,
rainbowdashofthejungle,
janesurvival,
primitive,
rainbowcat/*done*/,
rainbowcomfort,
doublerainbow/*done*/,
brony,
fire,
bulb,
sheldoncooper,
amyfowler,
greaterlight,
spock


}

public class StoryGenerator
{
/*wordList[#].getPOS will return a string of
verb, adjective, person, place, thing
wordList[#].getWord will return the actual word in string form
*/
private string _story;
private List<string> wordList;
public int verbs, adjectives, persons, places, things;
private bool madLibStyle;

public StoryGenerator (List<string> wordList)
{
		this.wordList = wordList;
		generate ();
		madLibStyle = false;
}

private void generateThroughFSM ()
{
	StoryState currentState = StoryState.start; // current state is set to starting because there is no words loaded
	int i = 0;

	while (i < wordList.Count) {
			string token = wordList [i];
			// state stuff

			if (currentState == StoryState.start) {
				switch (token) {
					case "boy":
						currentState = StoryState.boy; break;
					case "girl":
						currentState = StoryState.girl; break;
					case "world":
						currentState = StoryState.world; break;
					case "heart":
						currentState = StoryState.love; break;
					case "brokenheart":
						currentState = StoryState.hate; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "cat":
						currentState = StoryState.cat; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "fire":
						currentState = StoryState.romance; break;
					case "bulb":
						currentState = StoryState.bulb; break;
						
					}
			} else if (currentState == StoryState.boy) {
				switch (token) {
					case "boy":
						currentState = StoryState.boys; break;
					case "girl":
						currentState = StoryState.kids; break;
					case "heart":
						currentState = StoryState.boyloves; break;
					case "brokenheart":
						currentState = StoryState.boyhates; break;
					case "world":
						currentState = StoryState.scottpilgrim; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "cat":
						currentState = StoryState.boyexcited; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "bulb":
						currentState = StoryState.bulb; break;
				}
			} else if (currentState == StoryState.boys) {
				switch (token) {
					case "heart":
						currentState = StoryState.boyslove; break;
					case "girl":
						currentState = StoryState.kids; break;
					case "brokenheart":
						currentState = StoryState.boyshate; break;
					case "world":
						currentState = StoryState.boysenv; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "cat":
						currentState = StoryState.boysheal; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "bulb":
						currentState = StoryState.bulb; break;
				}
			} else if (currentState == StoryState.girl) {
				switch (token) {
					case "boy":
						currentState = StoryState.kids; break;
					case "girl":
						currentState = StoryState.girls; break;
					case "heart":
						currentState = StoryState.girlloves; break;
					case "brokenheart":
						currentState = StoryState.girlhates; break;
					case "world":
						currentState = StoryState.jane; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "cat":
						currentState = StoryState.girlexcited; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "bulb":
						currentState = StoryState.bulb; break;
				}
			} else if (currentState == StoryState.girls) {
				switch (token) {
					case "boy":
						currentState = StoryState.kids; break;
					case "heart":
						currentState = StoryState.girlslove; break;
					case "brokenheart":
						currentState = StoryState.girlshate; break;
					case "world":
						currentState = StoryState.girlsenv; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "cat":
						currentState = StoryState.girlsheal; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "bulb":
						currentState = StoryState.bulb; break;
				}
			} else if (currentState == StoryState.boyloves) {
				switch (token) {
					case "boy":
						currentState = StoryState.bromance; break;
					case "girl":
						currentState = StoryState.romance; break;
					case "brokenheart":
						currentState = StoryState.emo; break;
					case "world":
						currentState = StoryState.life; break;
					case "nuke":
						currentState = StoryState.boyevil; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
					case "cat":
						currentState = StoryState.boyhappy; break;
				}
			} else if (currentState == StoryState.boyhappy) {
				switch (token) {
					case "girl":
						currentState = StoryState.love; break;
					case "brokenheart":
						currentState = StoryState.mreow; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
				}
			} else if (currentState == StoryState.boyexcited) {
				switch (token) {
					case "girl":
						currentState = StoryState.romance; break;
					case "rainbow":
						currentState = StoryState.rainbowboy; break;
				}
			} else if (currentState == StoryState.boyhates) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyanger; break;
					case "girl":
						currentState = StoryState.boyanger; break;
					case "world":
						currentState = StoryState.emo; break;
					case "heart":
						currentState = StoryState.emo; break;
					case "nuke":
						currentState = StoryState.boysenv; break;
					case "cat":
						currentState = StoryState.mreow; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.boyslove) {
				switch (token) {
					case "girl":
						currentState = StoryState.friends; break;
					case "world":
						currentState = StoryState.boysenv; break;
					case "brokenheart":
						currentState = StoryState.boysbreak; break;
					case "nuke":
						currentState = StoryState.boyevil; break;
					case "cat":
						currentState = StoryState.meow; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
				}
			} else if (currentState == StoryState.boyshate) {
				switch (token) {
					case "world":
						currentState = StoryState.boysbreak; break;
					case "heart":
						currentState = StoryState.boysheal; break;
					case "boy":
						currentState = StoryState.boybully; break;
					case "girl":
						currentState = StoryState.boybully; break;
					case "nuke":
						currentState = StoryState.boysenv; break;
					case "cat":
						currentState = StoryState.mreow; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.boysenv) {
				switch (token) {
					case "girl":
						currentState = StoryState.life; break;
					case "brokenheart":
						currentState = StoryState.boysbreak; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "rainbow":
						currentState = StoryState.rainbowwarrior; break;
				}
			} else if (currentState == StoryState.boysbreak) {
				switch (token) {
					case "heart":
						currentState = StoryState.boysheal; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.boysheal) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbow; break;
				}
			} else if (currentState == StoryState.boyanger) {
				switch (token) {
					case "boy":
						currentState = StoryState.boybully; break;
					case "girl":
						currentState = StoryState.boybully; break;
					case "world":
						currentState = StoryState.boysbreak; break;
					case "heart":
						currentState = StoryState.boyhates; break;
					case "nuke":
						currentState = StoryState.boyevil; break;
					case "cat":
						currentState = StoryState.mreow; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.boybully) {
				switch (token) {
					case "boy":
						currentState = StoryState.boydestruction; break;
					case "girl":
						currentState = StoryState.boydestruction; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
					
				}
			} else if (currentState == StoryState.boyevil) {
				switch (token) {
					case "heart":
						currentState = StoryState.boysheal; break;
					case "brokenheart":
						currentState = StoryState.boydestruction; break;
					case "nuke":
						currentState = StoryState.annihilation; break;
					case "cat":
						currentState = StoryState.biggles; break;
					case "rainbow":
						currentState = StoryState.rainbowsaveone; break;
				}
			} else if (currentState == StoryState.girlloves) {
				switch (token) {
					case "boy":
						currentState = StoryState.romance; break;
					case "girl":
						currentState = StoryState.bffs; break;
					case "brokenheart":
						currentState = StoryState.emo; break;
					case "world":
						currentState = StoryState.life; break;
					case "nuke":
						currentState = StoryState.girlevil; break;
					case "cat":
						currentState = StoryState.girlhappy; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
				}
			} else if (currentState == StoryState.girlhappy) {
				switch (token) {
					case "boy":
						currentState = StoryState.love; break;
					case "brokenheart":
						currentState = StoryState.mreow; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
				}
			} else if (currentState == StoryState.girlexcited) {
				switch (token) {
					case "boy":
						currentState = StoryState.romance; break;
					case "rainbow":
						currentState = StoryState.rainbowgirl; break;
				}
			} else if (currentState == StoryState.girlhates) {
				switch (token) {
					case "girl":
						currentState = StoryState.girlanger; break;
					case "boy":
						currentState = StoryState.girlanger; break;
					case "world":
						currentState = StoryState.emo; break;
					case "heart":
						currentState = StoryState.emo; break;
					case "nuke":
						currentState = StoryState.girlsenv; break;
					case "cat":
						currentState = StoryState.mreow; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.girlslove) {
				switch (token) {
					case "boy":
						currentState = StoryState.friends; break;
					case "world":
						currentState = StoryState.girlsenv; break;
					case "brokenheart":
						currentState = StoryState.girlsbreak; break;
					case "nuke":
						currentState = StoryState.girlevil; break;
					case "cat":
						currentState = StoryState.meow; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
					case "fire":
						currentState = StoryState.girlslove; break;
				}
			} else if (currentState == StoryState.girlshate) {
				switch (token) {
					case "world":
						currentState = StoryState.girlsbreak; break;
					case "heart":
						currentState = StoryState.girlsheal; break;
					case "boy":
						currentState = StoryState.girlbully; break;
					case "nuke":
						currentState = StoryState.girlsenv; break;
					case "cat":
						currentState = StoryState.mreow; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.girlsenv) {
				switch (token) {
					case "boy":
						currentState = StoryState.life; break;
					case "brokenheart":
						currentState = StoryState.girlsbreak; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "rainbow":
						currentState = StoryState.rainbowwarrior; break;
				}
			} else if (currentState == StoryState.girlsbreak) {
				switch (token) {
					case "heart":
						currentState = StoryState.girlsheal; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}					
			} else if (currentState == StoryState.girlsheal) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbow; break;
				}										
			} else if (currentState == StoryState.girlanger) {
				switch (token) {
					case "boy":
						currentState = StoryState.girlbully; break;
					case "girl":
						currentState = StoryState.girlbully; break;
					case "world":
						currentState = StoryState.girlsbreak; break;
					case "heart":
						currentState = StoryState.girlhates; break;
					case "nuke":
						currentState = StoryState.girlevil; break;
					case "cat":
						currentState = StoryState.mreow; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}										
			} else if (currentState == StoryState.girlbully) {
				switch (token) {
					case "boy":
						currentState = StoryState.girldestruction; break;
					case "girl":
						currentState = StoryState.girldestruction; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
					
				}
			} else if (currentState == StoryState.girlevil) {
				switch (token) {
					case "heart":
						currentState = StoryState.girlsheal; break;
					case "brokenheart":
						currentState = StoryState.girldestruction; break;
					case "nuke":
						currentState = StoryState.annihilation; break;
					case "cat":
						currentState = StoryState.biggles; break;
					case "rainbow":
						currentState = StoryState.rainbowsaveone; break;
				}
			} else if (currentState == StoryState.kids) {
				switch (token) {
					case "world":
						currentState = StoryState.life; break;
					case "brokenheart":
						currentState = StoryState.emo; break;
					case "heart":
						currentState = StoryState.friends; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "cat":
						currentState = StoryState.meow; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "fire":
						currentState = StoryState.romance; break;
				}
			} else if (currentState == StoryState.romance) {
				switch (token) {
					case "brokenheart":
						currentState = StoryState.kids; break;
					case "nukes":
						currentState = StoryState.baddate; break;
					case "fire":
						currentState = StoryState.baddate; break;
					case "world":
						currentState = StoryState.honey; break;
					case "boy":
						currentState = StoryState.friends; break;
					case "girl":
						currentState = StoryState.friends; break;
					case "heart":
						currentState = StoryState.passion; break;
					case "rainbow":
						currentState = StoryState.rainbowhoney; break;
				}
			} else if (currentState == StoryState.baddate) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "cat":
						currentState = StoryState.comfort; break;
				}
			} else if (currentState == StoryState.honey) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbowhoney; break;
				}			
			} else if (currentState == StoryState.world) {
				switch (token) {
					case "boy":
						currentState = StoryState.boysenv; break;
					case "girl":
						currentState = StoryState.girlsenv; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "rainbow":
						currentState = StoryState.rainbowwarrior; break;
				}
			} else if (currentState == StoryState.love) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyloves; break;
					case "girl":
						currentState = StoryState.girlloves; break;
					case "brokenheart":
						currentState = StoryState.hate; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
					case "cat":
						currentState = StoryState.meow; break;
				}
			} else if (currentState == StoryState.hate) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyhates; break;
					case "girl":
						currentState = StoryState.girlhates; break;
					case "heart":
						currentState = StoryState.love; break;
					case "nuke":
						currentState = StoryState.life; break;
					case "cat":
						currentState = StoryState.mreow; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.scottpilgrim) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbowdashpilgrimforce; break;
					case "fire":
						currentState = StoryState.megabadascott; break;
					case "bulb":
						currentState = StoryState.videogameviolence; break;
					case "nuke":
						currentState = StoryState.videogameviolence; break;
				}
			} else if (currentState == StoryState.jane) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbowdashofthejungle; break;
					case "fire":
						currentState = StoryState.janesurvival; break;
					case "bulb":
						currentState = StoryState.primitive; break;
				}
			} else if (currentState == StoryState.friends) {
				switch (token) {
					case "brokenheart":
						currentState = StoryState.hate; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "fire":
						currentState = StoryState.passion; break;
				}
			} else if (currentState == StoryState.passion) {
				switch (token) {
					case "nuke":
						currentState = StoryState.unfortunate; break;
					case "cat":
						currentState = StoryState.unfortunate; break;
					case "rainbow":
						currentState = StoryState.rainbowhoney; break;
					case "brokenheart":
						currentState = StoryState.hate; break;
				}
			} else if (currentState == StoryState.life) {
				switch (token) {
					case "cat":
						currentState = StoryState.meow; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
					case "fire":
						currentState = StoryState.world; break;
				}
			} else if (currentState == StoryState.emo) {
				switch (token) {
					case "heart":
						currentState = StoryState.life; break;
					case "nuke":
						currentState = StoryState.nuke; break;
					case "rainbow":
						currentState = StoryState.rainbowpower; break;
					
				}				
			} else if (currentState == StoryState.bromance) {
				switch (token) {
					case "brokenheart":
						currentState = StoryState.boysbreak; break;
					case "girl":
						currentState = StoryState.friends; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "rainbow":
						currentState = StoryState.brony; break;
				}
			} else if (currentState == StoryState.bffs) {
				switch (token) {
					case "boy":
						currentState = StoryState.friends; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "rainbow":
						currentState = StoryState.rainbowgirl; break;
				}			
			} else if (currentState == StoryState.nuke) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyevil; break;
					case "girl":
						currentState = StoryState.girlevil; break;
					case "heart":
						currentState = StoryState.hate; break;
					case "world":
						currentState = StoryState.panic; break;
					case "cat":
						currentState = StoryState.comfort; break;
					case "rainbow":
						currentState = StoryState.rainbowsavetwo; break;
				}
			} else if (currentState == StoryState.panic) {
				switch (token) {
					case "nuke":
						currentState = StoryState.annihilation; break;
					case "cat":
						currentState = StoryState.comfort; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
				}
			} else if (currentState == StoryState.annihilation) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbowsavior; break;
				}
			} else if (currentState == StoryState.cat) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyhappy; break;
					case "girl":
						currentState = StoryState.girlhappy; break;
					case "nuke":
						currentState = StoryState.comfort; break;
					case "heart":
						currentState = StoryState.meow; break;
					case "brokenheart":
						currentState = StoryState.mreow; break;
					case "world":
						currentState = StoryState.world; break;
					case "rainbow":
						currentState = StoryState.rainbowcat; break;
					case "bulb":
						currentState = StoryState.litcat; break;
				}
			} else if (currentState == StoryState.meow) {
				switch (token) {
					case "boy":
						currentState = StoryState.love; break;
					case "girl":
						currentState = StoryState.love; break;
					case "rainbow":
						currentState = StoryState.rainbowcat; break;
				}
			} else if (currentState == StoryState.mreow) {
				switch (token) {
					case "boy":
						currentState = StoryState.catscratch; break;
					case "girl":
						currentState = StoryState.catscratch; break;
					case "rainbow":
						currentState = StoryState.rainbowcat; break;
				}
			} else if (currentState == StoryState.catscratch) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbow; break;
				}
			} else if (currentState == StoryState.litcat) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyexcited; break;
					case "girl":
						currentState = StoryState.girlexcited; break;
					case "rainbow":
						currentState = StoryState.rainbowcat; break;
					case "fire":
						currentState = StoryState.catwarm; break;
					case "nuke":
						currentState = StoryState.mreow; break;
					case "brokenheart":
						currentState = StoryState.mreow; break;
				}
			} else if (currentState == StoryState.comfort) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyhappy; break;
					case "girl":
						currentState = StoryState.girlhappy; break;
					case "rainbow":
						currentState = StoryState.rainbowcomfort; break;
				}
			} else if (currentState == StoryState.rainbowcomfort) {
				switch (token) {
					case "boy":
						currentState = StoryState.rainbowboy; break;
					case "girl":
						currentState = StoryState.rainbowgirl; break;
					case "rainbow":
						currentState = StoryState.doublerainbow; break;
				}
			} else if (currentState == StoryState.rainbow) {
				switch (token) {
					case "boy":
						currentState = StoryState.rainbowboy; break;
					case "girl":
						currentState = StoryState.rainbowgirl; break;
					case "world":
						currentState = StoryState.rainbowwarrior; break;
					case "brokenheart":
						currentState = StoryState.rainbowsad; break;
					case "heart":
						currentState = StoryState.rainbowblush; break;
					case "cat":
						currentState = StoryState.rainbowcat; break;
					case "nuke":
						currentState = StoryState.rainbowsavetwo; break;
					case "fire":
						currentState = StoryState.rainbowblush; break;
					case "bulb":
						currentState = StoryState.rainbowdash; break;
				}
			} else if (currentState == StoryState.rainbowdash) {
				switch (token) {
					case "boy":
						currentState = StoryState.rainbowboy; break;
					case "girl":
						currentState = StoryState.rainbowgirl; break;
					case "fire":
						currentState = StoryState.rainbowcomfort; break;
					case "heart":
						currentState = StoryState.rainbowwarrior; break;
					case "cat":
						currentState = StoryState.rainbowcat; break;
					case "rainbow":
						currentState = StoryState.doublerainbow; break;
				}
			} else if (currentState == StoryState.rainbowboy) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.doublerainbow; break;
				}
			} else if (currentState == StoryState.rainbowgirl) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.doublerainbow; break;
				}
			} else if (currentState == StoryState.rainbowcat) {
				switch (token) {
					case "nuke":
						currentState = StoryState.rainbowsavetwo; break;
					case "rainbow":
						currentState = StoryState.doublerainbow; break;
				}
			} else if (currentState == StoryState.rainbowblush) {
				switch (token) {
					case "boy":
						currentState = StoryState.rainbowboy; break;
					case "girl":
						currentState = StoryState.rainbowgirl; break;
					case "cat":
						currentState = StoryState.rainbowcat; break;
					case "brokenheart":
						currentState = StoryState.rainbowpower; break;
					case "world":
						currentState = StoryState.rainbowwarrior; break;
					case "rainbow":
						currentState = StoryState.doublerainbow; break;
				}
			} else if (currentState == StoryState.rainbowpower) {
				switch (token) {
					case "heart":
						currentState = StoryState.rainbow; break;
					case "boy":
						currentState = StoryState.rainbowpowertwo; break;
					case "girl":
						currentState = StoryState.rainbowpowertwo; break;
					case "brokenheart":
						currentState = StoryState.rainbowpowertwo; break;
					case "world":
						currentState = StoryState.rainbowpowertwo; break;
					case "nukes":
						currentState = StoryState.rainbowsavethree; break;
					case "cat":
						currentState = StoryState.rainbowpowertwo; break;
					case "rainbow":
						currentState = StoryState.rainbowpowertwo; break;
					case "fire":
						currentState = StoryState.rainbowpowertwo; break;
					case "bulb":
						currentState = StoryState.rainbowpowertwo; break;
				}
			} else if (currentState == StoryState.rainbowpowertwo) {
				switch (token) {
					case "heart":
						currentState = StoryState.rainbow; break;
				}
			} else if (currentState == StoryState.rainbowwarrior) {
				switch (token) {
					case "nukes":
						currentState = StoryState.rainbowsavior; break;
					case "rainbow":
						currentState = StoryState.doublerainbow; break;
				}
			} else if (currentState == StoryState.rainbowsad) {
				switch (token) {
					case "heart":
						currentState = StoryState.rainbow; break;
					case "nuke":
						currentState = StoryState.rainbowpower; break;
					case "fire":
						currentState = StoryState.rainbowpower; break;
					case "brokenheart":
						currentState = StoryState.rainbowpower; break;
				}
			} else if (currentState == StoryState.fire) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyloves; break;
					case "girl":
						currentState = StoryState.girlloves; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
					case "cat":
						currentState = StoryState.mreow; break;
				}
			} else if (currentState == StoryState.bulb) {
				switch (token) {
					case "fire":
						currentState = StoryState.greaterlight; break;
					case "boy":
						currentState = StoryState.boyloves; break;
					case "girl":
						currentState = StoryState.girlloves; break;
					case "world":
						currentState = StoryState.life; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "cat":
						currentState = StoryState.litcat; break;
				}
			} else if (currentState == StoryState.greaterlight) {
				switch (token) {
					case "boy":
						currentState = StoryState.sheldoncooper; break;
					case "girl":
						currentState = StoryState.amyfowler; break;
					case "world":
						currentState = StoryState.life; break;
					case "nuke":
						currentState = StoryState.annihilation; break;
					case "cat":
						currentState = StoryState.litcat; break;
				}
			} else if (currentState == StoryState.sheldoncooper) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.spock; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "world":
						currentState = StoryState.emo; break;
					case "girl":
						currentState = StoryState.boyshate; break;
					case "cat":
						currentState = StoryState.boyhappy; break;
				}
			} else if (currentState == StoryState.amyfowler) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.girlbully; break;
					case "world":
						currentState = StoryState.emo; break;
					case "boy":
						currentState = StoryState.baddate; break;
					case "cat":
						currentState = StoryState.girlevil; break;
					case "fire":
						currentState = StoryState.girlhappy; break;
				}
			}
			i = i + 1;
		}


		// we have gone through all the tokens
		switch (currentState) {
		case StoryState.boys:
			_story = "Boys, they're so ignorant, self-absorbed, careless...\n destructive...  violent....\n and there are so many of them!"; break;
		case StoryState.boyhappy:
			_story = "There is a boy who always appears to be happy,\n for he has a big heart. As a result,\n he gets picked on in school. :("; break;
		case StoryState.boysenv:
			_story = "There is a boy who expresses love for the planet.\n He embraces his nickname as the 'tree-hugger'"; break;
		case StoryState.boyexcited:
			_story = "There is a very enthusiastic boy, overwhelmed\n by all that is cute and cuddly in life,\n such as cats."; break;
		case StoryState.boysbreak:
			_story = "There is a boy with a broken spirit, who cries\n all the time to make people sympathize for him."; break;
		case StoryState.boysheal:
			_story = "There is a boy who overcame the odds of a bad\n situation, and turned his life around."; break;
		case StoryState.boyanger:
			_story = "There is a boy, a very heartless, angry boy who\n hates the other kids around him, and spends\n each Sunday asleep in anger management class."; break;
		case StoryState.boybully:
			_story = "There is a rude boy who has never felt love,\n except the love of making his fellow\n peers miserable."; break;
		case StoryState.boydestruction:
			_story = "There is a boy suffering the consequences\n of his actions. He beat up his peers, set fire to\n a cat, or did something along those lines."; break;
		case StoryState.boyevil:
			_story = "There is a cruel boy who will grow up to\n rule or destroy the world, whichever he decides."; break;
		case StoryState.rainbowboy:
			_story = "There is a boy who could never feel any happier,\n for Rainbow Dash has come to play with him\n and make his dreams come true. <3"; break;
		case StoryState.girls:
			_story = "Feminism, dear god what has this world come to... Miley Cirus"; break;
		case StoryState.girlhappy:
			_story = "There is a girl, and it was assumed\n that she was really happy"; break;
		case StoryState.girlsenv:
			_story = "There is a girl who adored the natural world,\n especially animals. So she went on to join P.E.T.A."; break;
		case StoryState.girlexcited:
			_story = "There is a joyful girl that is overwhelmed\n by the good things in life like cats"; break;
		case StoryState.girlsbreak:
			_story = "There is a girl who will sob about her tragic\n experiences in life. May she find a sympathizer."; break;
		case StoryState.girlsheal:
			_story = "There is a girl recovering from a tragic\n episode of her life. Probably a break-up\n or something first-world related."; break;
		case StoryState.girlanger:
			_story = "There is a dangerous thing known as an angry girl\n that the wise would take caution of."; break;
		case StoryState.girlbully:
			_story = "There is a girl who loves to hit people because\n of some emotional problems with fitting in,\n also because she can get away with it."; break;
		case StoryState.girldestruction:
			_story = "There is a girl who destroyed her reputation by\n seriously injuring another peer.\n Punishment: grounded."; break;
		case StoryState.girlevil:
			_story = "There is an evil girl who is destined to\n destroy the world, or just cause havoc, though\n the former sounds more awesome."; break;
		case StoryState.rainbowgirl:
			_story = "There is a girl who could never again feel as excited\n as right now, as Rainbow Dash has come to make\n her dreams come true. <3"; break;
		case StoryState.romance:
			_story = "One day, a boy and a girl will come together\n and share this scientifically unanswered theory\n called 'love'."; break;
		case StoryState.baddate:
			_story = "A tragic event will occur while a couple is on a date. The cause: nuclear war, or an ambush of cute cats?"; break;
		case StoryState.honey:
			_story = "A boy and girl form a relationship that in\n today's society probably will die within ten years.\n :("; break;
		case StoryState.scottpilgrim:
			_story = "The powers of the earth and music will\n coalesce around one boy to construct\n Scott Pilgrim!"; break;
		case StoryState.jane:
			_story = "A woman will wonder into the jungle\n and behold the presence of Tarzan."; break;
		case StoryState.passion:
			_story = "A boy and a girl fall in deep love,\n gross... they're kissing."; break;
		case StoryState.life:
			_story = "Life is full of pleasant wonders and mysteries."; break;
		case StoryState.emo:
			_story = "There is a kid who has a broken heart,\n wears black, and hates life, who also can dance well to\n Thriller by Michael Jackson"; break;
		case StoryState.bromance:
			_story = "Bromance: the next best thing to actual love."; break;
		case StoryState.bffs:
			_story = "Two girls will become bffs hang out, take selfies, sleep over, and whatever else two bffs like doing."; break;
		case StoryState.nuke:
			_story = "One day this world shall get nuked,\n will you be ready when that day comes?"; break;
		case StoryState.panic:
			_story = "When danger arises, will you still joke about it?"; break;
		case StoryState.annihilation:
			_story = "One day, somebody nuked somebody else,\n where is the world now?"; break;
		case StoryState.unfortunate:
			_story = "While on a date, a couple will\n unfortunately call it short when a nuke goes off...\n or when the cat needs attention."; break;
		case StoryState.cat:
			_story = "Nyan Nyan Nyan Nyan Nyan Nyan Nyan Nyan"; break;
		case StoryState.litcat:
			_story = "Someone will play with a cat and somehow\n light this cat on fire (or plug its tail into\n an outlet), and the result will look amazing."; break;
		case StoryState.meow:
			_story = "A few kids are playing with their cats,\n one begins to sing, and the others follow:\n 'Soft kitty, warm kitty, little ball of fur.'"; break;
		case StoryState.mreow:
			_story = "A few kids fool around with their cats,\n when the cats get angry, they start to sing:\n 'Angry kitty, meany kitty, grr grr grr'"; break;
		case StoryState.biggles:
			_story = "There once was an evil person who owned\n a cat, a big and evil cat. It was named...\n Mr. Bigglesworth."; break;
		case StoryState.comfort:
			_story = "There are many bad things happening in\n the world, but no matter what, a cat can\n comfort just about anyone."; break;
		case StoryState.rainbow:
			_story = "Amongst our world, there is a loyal, polychromatic pegasus\n who will come to spread joy and cheer\n to the denizens of earth"; break;
		case StoryState.rainbowdash:
			_story = "There will come a time, when Rainbow Dash will\n become reality, whether through science\n or pure belief in her."; break;
		case StoryState.rainbowblush:
			_story = "Rainbow Dash feels the love from her many\n admirers and blushes at the attention."; break;
		case StoryState.rainbowpower:
			_story = "Rainbow Dash feels the need to punish\n those who disrespect her or try to break her\n self-confidence. "; break;
		case StoryState.rainbowpowertwo:
			_story = "Rainbow Dash, feeling highly riduculed,\n will pummel you for trying to break her heart."; break;
		case StoryState.rainbowwarrior:
			_story = "In addition to all her other characteristics,\n Rainbow Dash is a huge environmentalist who\n cares a lot about the world we live in."; break;
		case StoryState.rainbowsaveone:
			_story = "An evil person will attempts to raise havoc\n only to be stopped by Rainbow Dash who brings\n the evildoer to justice."; break;
		case StoryState.rainbowsavetwo:
			_story = "A nuke is designated to blow up and kill many\n people and cats, but Rainbow Dash arrives to redirect the\n nuke and save the day."; break;
		case StoryState.rainbowsavethree:
			_story = "A nuke is designated to blow up and kill many\n people and cats, but Rainbow Dash arrives to redirect the\n nuke and save the day."; break;
		case StoryState.rainbowsavior:
			_story = "Total annihilation will face the world one day,\n only to be stopped when comfronted by Rainbow Dash!"; break;
		case StoryState.rainbowsad:
			_story = "Rainbow Dash feels sad that you don't like her,\n and flies away with sparkling tears gliding down\n her face."; break;
		case StoryState.rainbowhoney:
			_story = "A boy and a girl fell will fall in love\n and ride through the sky on the back of the\n majestic Rainbow Dash."; break;
		case StoryState.rainbowdashpilgrimforce:
			_story = "The powers of the Earth and music combined\n to create Scott Pilgrim, together with Rainbow Dash\n they are the awesome RainbowPilgrimForce!"; break;
		case StoryState.megabadascott:
			_story = "One day Scott Pilgrim, combined from the powers of the Earth\n and music, will master the magic of fire! And then\n probably cook himself lunch with it."; break;
		case StoryState.videogameviolence:
			_story = "Legend tells that Scott Pilgrim, combined from\n the powers of the Earth and music, will defeat his foes using 8-bit videogame fighting skills."; break;
		case StoryState.rainbowdashofthejungle:
			_story = "A girl has lost herself in the jungle only to be found\n by a multi-colored pony with wings. The pony inspects\n her and says, 'Me Rainbow Dash, you Jane.'"; break;
		case StoryState.janesurvival:
			_story = "A girl named Jane will lose herself in a creepy jungle, so\n she'll start a fire and burn it down... Only you can\n prevent forest fires, don't get lost in the jungle."; break;
		case StoryState.primitive:
			_story = "A girl named Jane will get lost in the jungle,\n meet a primitive man and fall in love with him.\n Their gorilla children will be gorgeous."; break;
		case StoryState.rainbowcat:
			_story = "Rainbow Dash and a cat will befriend each other\n and play amongst the clouds."; break;
		case StoryState.rainbowcomfort:
			_story = "When times are extremely tough for people, Rainbow Dash\n will be there to comfort them through break-ups\n to possible nuclear wars."; break;
		case StoryState.doublerainbow:
			_story = "A double Rainbow Dash is a phenomenon of magic that displays\n a spectrum of love due to the sun shining on Rainbow\n Dash's cutie mark. Does that explain it?"; break;
		case StoryState.brony:
			_story = "There is a boy who loves watching My Little Pony.\n As he got older, people refered to him as\n a brony, but he didn't care much."; break;
		case StoryState.fire:
			_story = "...but then everything changed\n when the fire nation attacked!"; break;
		case StoryState.bulb:
			_story = "Let there be light!"; break;
		case StoryState.sheldoncooper:
			_story = "There is a strange boy who grew up to be\n a genius. Though as intelligent as he was, he was socially\n awkward... poor Sheldon."; break;
		case StoryState.amyfowler:
			_story = "There is a strange girl who grew up to be\n somewhat of a genius, but she was unable to socialize properly.\n Poor Amy Fowler."; break;
		case StoryState.greaterlight:
			_story = "And then Edison said, 'let there be ultraviolet light'!"; break;
		case StoryState.spock:
			_story = "There is an intelligent boy who grew up\n to be a theoretical physicist and worship the\n god amongst nerds: Spock."; break;
			default:
			_story = "Thanks for playing, but the fate of our world\n is in another set of cards!"; break;
		}
		if 	(_story.Substring(0,5)=="stuff") {
			_story = "Thanks for playing, but the fate of our world\n is in another set of cards!";
		}
	}


private void generate ()
{
		if (madLibStyle) {

				extractPOSs ();
				_story = pullStoryFromFile ();
				replaceKeywords ();
				return;
		}
		//At this point the story has been made and can be got from anywhere else
		generateThroughFSM ();
}

/*TODO: get the number of each type of 'part of speech' that will be used
* so that you can create the story with them in the right places
*/
public void extractPOSs ()
{
}

private string pullStoryFromFile ()
{
		string _story = "";

		//TODO: pull a story that can be filled with the POSs that we have

		return _story;
}

//TODO: replace the keywords in the story for the ones we have in the list
private void replaceKeywords ()
{

}

public string story {
		get {
				return _story;
		}
}
}