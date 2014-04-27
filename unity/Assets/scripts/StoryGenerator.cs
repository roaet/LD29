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
						currentState = StoryState.boyhappy; break;
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
						currentState = StoryState.girlhappy; break;
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
						currentState = StoryState.meow; break;
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
					case "nuke":
						currentState = StoryState.nuke; break;
					case "rainbow":
						currentState = StoryState.rainbowblush; break;
				}
			} else if (currentState == StoryState.hate) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyhates; break;
					case "girl":
						currentState = StoryState.girlhates; break;
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
						currentState = StoryState.rainbow; break;
				}			
			} else if (currentState == StoryState.nuke) {
				switch (token) {
					case "boy":
						currentState = StoryState.boyevil; break;
					case "girl":
						currentState = StoryState.girlevil; break;
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
						currentState = StoryState.annihilation; break;
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
		case StoryState.boy:
			_story = "Delicious, mouthwatering, meaty sausages, comes browned or white here at the sausage festival!"; break;
		case StoryState.boyhappy:
			_story = "stuff01"; break;
		case StoryState.boysenv:
			_story = "stuff02"; break;
		case StoryState.boysbreak:
			_story = "stuff03"; break;
		case StoryState.boysheal:
			_story = "stuff04"; break;
		case StoryState.boyanger:
			_story = "stuffo5"; break;
		case StoryState.boybully:
			_story = "stuff06"; break;
		case StoryState.boydestruction:
			_story = "stuff07"; break;
		case StoryState.boyevil:
			_story = "stuffo8"; break;
		case StoryState.rainbowboy:
			_story = "stuff09"; break;
		case StoryState.girl:
			_story = "stuff10"; break;
		case StoryState.girlhappy:
			_story = "stuff11"; break;
		case StoryState.girlsenv:
			_story = "stuff12"; break;
		case StoryState.girlsbreak:
			_story = "stuff13"; break;
		case StoryState.girlsheal:
			_story = "stuff14"; break;
		case StoryState.girlanger:
			_story = "stuff15"; break;
		case StoryState.girlbully:
			_story = "stuff16"; break;
		case StoryState.girldestruction:
			_story = "stuff17"; break;
		case StoryState.girlevil:
			_story = "stuff18"; break;
		case StoryState.rainbowgirl:
			_story = "stuff19"; break;
		case StoryState.romance:
			_story = "stuff20"; break;
		case StoryState.baddate:
			_story = "stuff21"; break;
		case StoryState.honey:
			_story = "stuff22"; break;
		case StoryState.scottpilgrim:
			_story = "stuff23"; break;
		case StoryState.jane:
			_story = "stuff24"; break;
		case StoryState.passion:
			_story = "stuff25"; break;
		case StoryState.life:
			_story = "stuff26"; break;
		case StoryState.emo:
			_story = "stuff27"; break;
		case StoryState.bromance:
			_story = "stuff28"; break;
		case StoryState.bffs:
			_story = "stuff29"; break;
		case StoryState.nuke:
			_story = "stuff30"; break;
		case StoryState.panic:
			_story = "stuff31"; break;
		case StoryState.annihilation:
			_story = "stuff32"; break;
		case StoryState.unfortunate:
			_story = "stuff33"; break;
		case StoryState.cat:
			_story = "stuff34"; break;
		case StoryState.meow:
			_story = "stuff35"; break;
		case StoryState.mreow:
			_story = "stuff36"; break;
		case StoryState.biggles:
			_story = "stuff37"; break;
		case StoryState.comfort:
			_story = "stuff38"; break;
		case StoryState.rainbow:
			_story = "stuff39"; break;
		case StoryState.rainbowdash:
			_story = "stuff40"; break;
		case StoryState.rainbowblush:
			_story = "stuff41"; break;
		case StoryState.rainbowpower:
			_story = "stuff42"; break;
		case StoryState.rainbowpowertwo:
			_story = "stuff43"; break;
		case StoryState.rainbowwarrior:
			_story = "stuff44"; break;
		case StoryState.rainbowsaveone:
			_story = "stuff45"; break;
		case StoryState.rainbowsavetwo:
			_story = "stuff46"; break;
		case StoryState.rainbowsavethree:
			_story = "stuff47"; break;
		case StoryState.rainbowsavior:
			_story = "stuff48"; break;
		case StoryState.rainbowhoney:
			_story = "stuff49"; break;
		case StoryState.rainbowdashpilgrimforce:
			_story = "stuff50"; break;
		case StoryState.megabadascott:
			_story = "stuff51"; break;
		case StoryState.videogameviolence:
			_story = "stuff52"; break;
		case StoryState.rainbowdashofthejungle:
			_story = "stuff53"; break;
		case StoryState.janesurvival:
			_story = "stuff54"; break;
		case StoryState.primitive:
			_story = "stuff55"; break;
		case StoryState.rainbowcat:
			_story = "stuff56"; break;
		case StoryState.rainbowcomfort:
			_story = "stuff57"; break;
		case StoryState.doublerainbow:
			_story = "stuff58"; break;
		case StoryState.brony:
			_story = "stuff59"; break;
		case StoryState.fire:
			_story = "stuff60"; break;
		case StoryState.bulb:
			_story = "stuff61"; break;
		case StoryState.sheldoncooper:
			_story = "stuff62"; break;
		case StoryState.amyfowler:
			_story = "stuff63"; break;
		case StoryState.greaterlight:
			_story = "stuff64"; break;
		case StoryState.spock:
			_story = "stuff65"; break;
			default:
			_story = "Thanks for playing, but the fate of our world\n is in another set of cards!"; break;
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