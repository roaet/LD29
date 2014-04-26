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
* j = worlde,
*							a	b	c	d	e	f	g	h	i	j	
* ----------------
* */
public enum StoryState
{ //LR Parsing
start/*done*/,
boy/*done*/,
boys/*done*/,
boyloves/*done*/,
boyslove,
boyhates,
boyshate,
boysenv,
girl/*done*/,
girls/*done*/,
girlloves/*done*/,
romance/*done*/,
girlslove,
girlshate,
girlsenv,
kids,
baddate,
honey,
world,
love,
hate,
scottpilgrim,


}

public class StoryGenerator
{
/*wordList[#].getPOS will return a string of
verb, adjective, person, place, thing
wordList[#].getWord will return the actual word in string form
*/
private string _story;
private List<Word> wordList;
public int verbs, adjectives, persons, places, things;
private bool madLibStyle;

public StoryGenerator (List<Word> wordList)
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
				Word currentWord = wordList [i];
				string token = currentWord.word;
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
						}
				} else if (currentState == StoryState.girl) {
						switch (token) {
						case "boy":
							currentState = StoryState.kids; break;
						case "girl":
							currentState = StoryState.girls; break;
						case "heart":
							currentState = StoryState.girlloves; break;
						}
				} else if (currentState == StoryState.girls) {
						switch (token) {
						case "boy":
							currentState = StoryState.kids; break;
						case "heart":
							currentState = StoryState.girlslove; break;
						case "brokenheart":
							currentState = StoryState.girlshate; break;
						}
				} else if (currentState == StoryState.boyloves) {
						switch (token) {
						case "boy":
							currentState = StoryState.kids; break;
						case "girl":
							currentState = StoryState.girls; break;
						case "heart":
							currentState = StoryState.girlloves; break;
						}
				} else if (currentState == StoryState.girlloves) {
						switch (token) {
						case "boy":
							currentState = StoryState.kids; break;
						case "heart":
							currentState = StoryState.girlslove; break;
						case "brokenheart":
							currentState = StoryState.girlshate; break;
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

						}
						i = i + 1;
				}
				// we have gone through all the tokens
				switch (currentState) {
				case StoryState.boy:
						_story = "So you made a cross dresser?!?"; break;
				}
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