using UnityEngine;
using System.Collections;


public class Tile: MonoBehaviour {
	private string _name;
	public Sprite back;
	private Sprite _sprite;
	public bool isClickable;

	// Use this for initialization
	void Start () {
		isClickable = true;
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

	public void switchBack(){
		SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
		sr.sprite = back;
		isClickable = true;
	}

	void OnMouseUp(){
		if (isClickable) {
			SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
			sr.sprite = _sprite;
			isClickable = false;
			TestStoryGenerator.upTiles.Add(this);
		}
	}

	public void move(){
		transform.position = new Vector3 (TestStoryGenerator.combinedTiles*1.5f-3.719f, 4.180f, 0f);
	}

	public void kill(){
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	}
}