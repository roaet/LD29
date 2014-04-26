using UnityEngine;
using System.Collections;

public class Word : MonoBehaviour {
	string word;
	string pos;//part of speech
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string getWord(){
		return word;
	}

	public string getPOS(){
		return pos;
	}
}
