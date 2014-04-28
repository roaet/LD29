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
	                   GameObject levelCanvas, GameObject tileStartPoint, Sprite[] sprites,
	                   string json) {

		/*TextAsset json = (TextAsset)Resources.Load (loadSource, typeof(TextAsset));
		if(!json){
			Debug.LogError("Couldn't find: " + loadSource);
		}*/
		wordList = new List<Word> ();
		string content = json/*.text*/;
		JSONNode levels = JSON.Parse (content);
		int w = levels ["levels"] [level] ["width"].AsInt;
		int h = levels ["levels"] [level] ["height"].AsInt;
		for(int i = 0; i < w; i++){
			for(int j = 0; j < h; j++){
				Word word = new Word(levels["levels"][level], j, i);
				wordList.Add (word);
			}
		}

		int width = w;
		int height = h;
		tileData = new List<List<GameObject>>();
		for(int y = 0; y < height; y++) {
			tileData.Add(new List<GameObject>());
		}
		
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				GameObject tileGameObject = CreateTile(tilePrefab, levelCanvas, tileStartPoint);
				Tile tile = tileGameObject.GetComponent<Tile>();
				tile.tileName = wordList[height*x + y].word;

				for(int i = 0; i < sprites.Length; i++){
					Sprite temp = sprites[i];

					if(temp.name == tile.tileName)
						tile.sprite = temp;
				}

				Vector3 pos = tileStartPoint.transform.position;
				BoxCollider2D box = tilePrefab.GetComponent<BoxCollider2D>();
				pos.x += x * box.size.x * 2f;

				if(x > 1)
					pos.x += box.size.x;

				pos.y += y * -box.size.y * 2f;
				pos.z = tileStartPoint.transform.position.z;
				tile.transform.position = pos;
				tileData[y].Add(tileGameObject);
			}
		}
	}

	public void setClickable(bool b){
		for (int i = 0; i < tileData.Count; i++){
			for (int j = 0; j < tileData[i].Count; j++){
				if(tileData[i][j] != null)
					tileData[i][j].GetComponent<Tile>().clickable = b;
			}
		}
	}

	public void killTileGameObjects(){
		for (int i = 0; i < tileData.Count; i++){
			for (int j = 0; j < tileData[i].Count; j++){
				if(tileData[i][j] != null)
					tileData[i][j].GetComponent<Tile>().kill();
			}
			tileData[i].Clear();
		}
	}

	private GameObject CreateTile(GameObject tilePrefab, GameObject levelCanvas, 
	                              GameObject tileStartPoint) {
		GameObject tile = GameObject.Instantiate(tilePrefab) as GameObject;
		tile.transform.parent = levelCanvas.transform;

		return tile;
	}
}