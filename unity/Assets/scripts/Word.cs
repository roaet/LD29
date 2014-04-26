using UnityEngine;
using System.Collections;

public class Word : MonoBehaviour {
	private string _word;
	private string _pos;//part of speech
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string word {
		get {
			return _word;
		}
	}

	public string pos{
		get {
			return _pos;
		}
	}
}
