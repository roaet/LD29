using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// this class is used to test the level loader
public class TestStoryGenerator : MonoBehaviour {
	public GameObject levelCanvas;
	public GameObject tilePrefab;
	public GameObject tileStartPoint;
	public Sprite[] sprites;

	public int tilesUpfacing;
	public static List<Tile> upTiles;
	public static int combinedTiles;
	public static List<Tile> storedTiles;
	public LoadWordMap loader;
	public MusicController audioController;

	float nextUsage;
	float delay = 1f;
	bool killed = false;
	private MyFunction f;
	private AudioSource _audio;
	private string json;
	// Use this for initialization
	void Start () {
		tilesUpfacing = 0;
		combinedTiles = 0;
		storedTiles = new List<Tile> ();
		upTiles = new List<Tile> ();
		loader = null;
		_audio = GetComponent<AudioSource>();
	}

	public void load(){
		Tile.killAll (storedTiles);
		json = (new CreateJSONFile ()).randomizeJSON();
		tilesUpfacing = 0;
		combinedTiles = 0;
		storedTiles = new List<Tile> ();
		upTiles = new List<Tile> ();

		loader = new LoadWordMap ("levels", 0, tilePrefab, levelCanvas, tileStartPoint,
		                          sprites, json, audioController);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.F5)) {
			/*
			if(loader != null)
				loader.killTileGameObjects();

			load ();
			*/
		}
		if(!killed)
			nextUsage = Time.time + delay;
		if(upTiles != null)
			if (upTiles.Count == 2)
				checkSameTileFaces();
	}

	public void checkSameTileFaces(){
		if (!killed) {
			killed = true;
			loader.setClickable(false);
		}

		if (Time.time > nextUsage && killed) {
			killed = false;
			if (upTiles [0].tileName == upTiles [1].tileName) {
				
				if(_audio) _audio.Play();
				upTiles [1].move ();
				storedTiles.Add(upTiles[1]);
				upTiles [0].kill ();
				upTiles.RemoveRange (0, 2);
				combinedTiles++;
			} else {
				upTiles [0].switchBack ();
				upTiles [1].switchBack ();
				upTiles.RemoveRange (0, 2);
			}

			loader.setClickable(true);
		}

		if (storedTiles.Count == 6)
			f (storedTiles);
	}

	public MyFunction finishCallback{
		set{
			f = value;
		}
	}
}

public delegate void MyFunction (List<Tile> s);