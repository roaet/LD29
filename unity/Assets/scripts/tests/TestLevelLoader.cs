using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// this class is used to test the level loader
public class TestLevelLoader : MonoBehaviour {

	public GameObject levelCanvas;
	public GameObject tilePrefab;
	public GameObject tileStartPoint;

	private List<List<GameObject>> tileData;

	// Use this for initialization
	void Start () {
		int width = 18;
		int height = 11;
		tileData = new List<List<GameObject>>();
		for(int y = 0; y < height; y++) {
			tileData.Add(new List<GameObject>());
		}

		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				GameObject tile = CreateTile();
				Vector3 pos = tileStartPoint.transform.position;
				BoxCollider2D box = tilePrefab.GetComponent<BoxCollider2D>();
				pos.x += x * box.size.x;
				pos.y += y * -box.size.y;
				pos.z = tileStartPoint.transform.position.z;
				tile.transform.position = pos;
				tileData[y].Add(tile);
			}
		}
	}

	private GameObject CreateTile() {
		GameObject tile = GameObject.Instantiate(tilePrefab) as GameObject;
		tile.transform.parent = levelCanvas.transform;
		return tile;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
