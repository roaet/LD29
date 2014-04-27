using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Tile: MonoBehaviour {
	private string _name;
	public Sprite back;
	private Sprite _sprite;
	private bool isClickable;
	private bool moved;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		isClickable = true;
		moved = false;
		audio = GetComponent<AudioSource>();
	}

	public Sprite sprite{
		get{
			return _sprite;
		}
		set{
			_sprite = value;
		}
	}

	public string tileName{
		get{
			return _name;
		}
		set{
			_name = value;
		}
	}

	public bool clickable{
		get{
			return isClickable;
		}
		set{
			isClickable = value;
		}
	}

	public void switchBack(){
		SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
		sr.sprite = back;
		isClickable = true;
	}

	void OnMouseUp(){
		if (isClickable && !moved) {
			SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
			sr.sprite = _sprite;
			isClickable = false;
			TestStoryGenerator.upTiles.Add(this);
			if(audio) {
				audio.Play();
			}
		}
	}

	public void move(){
		transform.position = new Vector3 (TestStoryGenerator.combinedTiles*1.5f-3.719f, 4.180f, 0f);
		moved = true;
	}

	public void kill(){
		Destroy (gameObject);
	}

	public static void killAll(List<Tile> list){
		for (int i = 0; i < list.Count; i++)
			list [i].kill ();
	}

	// Update is called once per frame
	void Update () {
	}
}