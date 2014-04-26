using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//get that info 

public class LoadWordMap
{
	private List<Level> levelList;
	// Use this for initialization
	public GameObject levelCanvas;
	public GameObject tilePrefab;
	public GameObject tileStartPoint;
	
	private List<List<GameObject>> tileData;
	
	public LoadWordMap(string loadSource, int level) {
		TextAsset json = (TextAsset)Resources.Load (loadSource, typeof(TextAsset));
		if(!json){
			Debug.LogError("Couldn't find: " + loadSource);
		}

/*		levelList = new LevelList<Level>();
		string content = json.text;
		JSONNode levels = JSON.Parse (content);

		for(int i 
		Word word = new Word(levels["levels"][level]);*/
	}
}