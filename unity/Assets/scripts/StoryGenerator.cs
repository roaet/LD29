using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StoryState {
	start, justaboy, justagirl,
	boyloves_something, girlloves_something,
	crossdresser
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



	private void generateThroughFSM() {
		StoryState currentState = StoryState.start; // current state is set to starting because there is no words loaded
		int i = 0;
		/*
		 * 
		 * ARRAY
		 * Collection of things of type T
		 * 
		 * Array[0][1][...][Count-1]
		 * 
		 */
		while(i < wordList.Count) {
			Word currentWord = wordList[i];
			string token = currentWord.word;
			// state stuff

			if(currentState == StoryState.start) {
				switch(token) {
				case "boy": currentState = StoryState.boy; break;
				case "girl": currentState = StoryState.girl; break;
				}
			} else if(currentState == StoryState.justaboy) {
				switch(token) {
				case "boy": currentState = StoryState.boy; break;
				case "girl": currentState = StoryState.crossdresser; break;
				case "heart": currentState = StoryState.boyloves_something; break;
				}
			}
			i = i + 1;
		}
		// we have gone through all the tokens
		switch(currentState) {
		case StoryState.crossdresser: _story = "So you made a cross dresser?!?";
		}
	}















	private void generate(){
		if(madLibStyle) {

			extractPOSs ();
			_story = pullStoryFromFile ();
			replaceKeywords ();
			return;
		}
		//At this point the story has been made and can be got from anywhere else
		generateThroughFSM();
	}

	/*TODO: get the number of each type of 'part of speech' that will be used
	 * so that you can create the story with them in the right places
	*/
	public void extractPOSs(){
	}

	private string pullStoryFromFile(){
		string _story = "";

		//TODO: pull a story that can be filled with the POSs that we have

		return _story;
	}

	//TODO: replace the keywords in the story for the ones we have in the list
	private void replaceKeywords(){

	}
	
	public string story {
		get {
			return _story;
		}
	}
}