using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

//get that info 

public class LoadWordMap
{
	private List<Word> wordList;
	// Use this for initialization
	
	private List<List<GameObject>> tileData;
	
	public LoadWordMap(string loadSource, int level, GameObject tilePrefab,
	                   GameObject levelCanvas, GameObject tileStartPoint) {

		TextAsset json = (TextAsset)Resources.Load (loadSource, typeof(TextAsset));
		if(!json){
			Debug.LogError("Couldn't find: " + loadSource);
		}

		wordList = new List<Word>();
		string content = json.text;
		JSONNode levels = JSON.Parse (content);
		int w = levels ["levels"] [level] ["width"].AsInt;
		int h = levels ["levels"] [level] ["height"].AsInt;

		for(int i = 0; i < w; i++){
			for(int j = 0; j < h; j++){
				Word word = new Word(levels["levels"][level], j, i);
			}
		}

		int width = 4;
		int height = 3;
		tileData = new List<List<GameObject>>();
		for(int y = 0; y < height; y++) {
			tileData.Add(new List<GameObject>());
		}
		
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				GameObject tile = CreateTile(tilePrefab, levelCanvas, tileStartPoint);
				Vector3 pos = tileStartPoint.transform.position;
				BoxCollider2D box = tilePrefab.GetComponent<BoxCollider2D>();
				pos.x += x * box.size.x * 1.5f;
				pos.y += y * -box.size.y * 1.5f;
				pos.z = tileStartPoint.transform.position.z;
				tile.transform.position = pos;
				tileData[y].Add(tile);
			}
		}
	}

	private GameObject CreateTile(GameObject tilePrefab,
	                              GameObject levelCanvas, GameObject tileStartPoint) {
		GameObject tile = GameObject.Instantiate(tilePrefab) as GameObject;
		tile.transform.parent = levelCanvas.transform;
		return tile;
	}
}