using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// this class is used to test the level loader
public class TestStoryGenerator : MonoBehaviour {
	public GameObject levelCanvas;
	public GameObject tilePrefab;
	public GameObject tileStartPoint;
	
	private List<List<GameObject>> tileData;
	
	// Use this for initialization
	void Start () {
		LoadWordMap loader = new LoadWordMap ("levels", 0, tilePrefab, levelCanvas, tileStartPoint);//LOADS LVL 1
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}