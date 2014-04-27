/*
 {
	"levelCount": 1,
	
	"levels" : [
		{
			"width" : 4,
			"height" : 3,
			"words" : [["tile_boy", "tile_boy", "tile_rainbow", "tile_cat"]
					   ["tile_fire", "tile_heart", "tile_cat", "tile_fire"]
					   ["tile_cat", "tile_boy", "tile_rainbow", "tile_heart"]]
		}
} 
*/
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateJSONFile
{
	String[] tiles = {"boy", "broken", "bulb", "cat", "fire", 
					  "girl", "heart", "nuke", "rainbow", "world"};
	public int numLevels = 100;
	public int numPairs = 6;
	String json;

	public CreateJSONFile ()
	{
		json = "{ \"levelCount\": " + numLevels + ", \'levels\" : [";
	}

	public void randomizeJSON(){
		Random r = new Random ();
		List<string> singularSet = new List<string> ();

		for (int i = 0; i < numLevels; i++) {
			for(int j = 0; j < numPairs; j++){
				singularSet[j] = tiles[r.Next(0,10)];
				singularSet[j + numPairs] = tiles[r.Next(0,10)];
			}

			shuffle(singularSet);
			addLevelToJSON(singularSet);
		}
	}

	public void addLevelToJSON(List<string> list){
		json += "{\"width\" : 4, \"height\" : 3, \"words\" : [[\"";
	}

	public void shuffle(List<string> list){
		Random rng = new Random ();
		int n = list.Count;

		while (n > 1) {
			n--;
			int k = rng.Next (n + 1);
			string value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
}

