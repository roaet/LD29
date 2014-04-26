/* Base class for the ship */
using UnityEngine;
using System.Collections;

public class TileBase : MonoBehaviour {

	public string tilename;
	public float toughness;
	public bool isBreakable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool breakable {
		get {
			return isBreakable;
		}
	}
}
