using UnityEngine;
using System.Collections;


public class Tile: MonoBehaviour {
	private string _name;

	// Use this for initialization
	void Start () {
		
	}

	public string tileName{
		get{
			return _name;
		}
		set{
			_name = value;
		}
	}

	void OnMouseUp(){
		Debug.Log(_name + " Clicked!");
	}
	
	// Update is called once per frame
	void Update () {
	}
}