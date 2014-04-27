using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// this class is used to test the level loader
public class TestStoryGenerator : MonoBehaviour {
	public GameObject levelCanvas;
	public GameObject tilePrefab;
	public GameObject tileStartPoint;
	public Sprite[] sprites;

	public int tilesUpfacing = 0;
	public static List<Tile> upTiles = new List<Tile> ();
	// Use this for initialization
	void Start () {
		LoadWordMap loader = new LoadWordMap ("levels", 0, tilePrefab, levelCanvas, tileStartPoint,
		                                      sprites);
	}

	float nextUsage;
	float delay = 1.33f;
	bool killed = false;
	// Update is called once per frame
	void Update () {
		if(!killed)
			nextUsage = Time.time + delay;
		if(upTiles != null)
			if (upTiles.Count == 2)
				checkSameTileFaces();
	}

	public void checkSameTileFaces(){
		if (!killed)
			killed = true;

		if (Time.time > nextUsage && killed) {
			killed = false;
			if (upTiles [0].tileName == upTiles [1].tileName) {
					Debug.Log (upTiles [0].name + " - " + upTiles [1].name);
					upTiles [1].move ();
					upTiles [0].kill ();
					upTiles.RemoveRange (0, 2);
			} else {
					upTiles [0].switchBack ();
					upTiles [1].switchBack ();
					upTiles.RemoveRange (0, 2);
			}
		}
	}
}