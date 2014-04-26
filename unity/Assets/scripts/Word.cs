using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Word{
	private string _word;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Word(JSONNode wordJSON, int x, int y){
		_word = wordJSON ["words"][x][y];//prob ["words"][num] for array
		Debug.Log (_word);
	}

	public string word {
		get {
			return _word;
		}
	}
}
