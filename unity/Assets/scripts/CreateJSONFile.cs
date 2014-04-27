using System;
using System.Collections;
using System.Collections.Generic;

public class CreateJSONFile
{
	String[] tiles = {"tile_boy", "tile_broken", "tile_bulb", "tile_cat", "tile_fire", 
					"tile_girl", "tile_heart", "tile_nuke", "tile_rainbow", "tile_world"};
	public int numLevels = 1;
	public int numPairs = 6;
	String json;

	public CreateJSONFile ()
	{
		json = "{ \"levelCount\": " + numLevels + ", \"levels\" : [";
	}
	private Random r = new Random();
	public String randomizeJSON(){
		List<string> singularSet;

		for (int i = 0; i < numLevels; i++) {
			singularSet = new List<string> ();
			for(int j = 0; j < numPairs; j++){
				string temp = tiles[r.Next(0, 10)];
				singularSet.Add(temp);
				singularSet.Add(temp);
			}

			shuffle(singularSet);
			addLevelToJSON(singularSet);
		}
		json += " }";

		return json;
	}

	public void addLevelToJSON(List<string> list){
		json += "{\"width\" : 4, \"height\" : 3, \"words\" : [";

		for (int i = 0; i < 3; i++){
			json += "[";

			for (int j = 0; j < 4; j++){
				if(j != 3)
					json += "\"" + list[i*4+j] + "\", ";
				else
					json += "\"" + list[i*4+j] + "\"";
			}
			json += "]";
		}
		json += "] }";
	}

	public void shuffle(List<string> list){
		int n = list.Count;

		while (n > 1) {
			n--;
			int k = r.Next (n+1);

			string value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
}

