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
* j = world,
*							
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
rainbowdashofthejungle,
rainbowcat/*done*/,
rainbowcomfort,
doublerainbow/*done*/,
brony,
fire,
bulb,
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
						currentState = StoryState.fire; break;
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
				}
			} else if (currentState == StoryState.jane) {
				switch (token) {
					case "rainbow":
						currentState = StoryState.rainbowdashofthejungle; break;
				}
			} else if (currentState == StoryState.friends) {
				switch (token) {
					case "brokenheart":
						currentState = StoryState.hate; break;
					case "nuke":
						currentState = StoryState.panic; break;
					case "rainbow":
						currentState = StoryState.rainbow; break;
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
				
				}
			} else if (currentState == StoryState.bulb) {
				switch (token) {
				
				}
			}
			i = i + 1;
		}


		// we have gone through all the tokens
		switch (currentState) {
		case StoryState.boy:
				_story = "Delicious, mouthwatering, meaty sausages, comes browned or white here at the sausage festival!"; break;
				default:
				_story = "BUZZ"; break;
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