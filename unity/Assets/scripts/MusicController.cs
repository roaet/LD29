using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public Sprite noteOn;
	public Sprite noteOff;

	public AudioSource musicSource;


	private SpriteRenderer _sprite;

	// Use this for initialization
	void Start () {
		_sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		if(musicSource.volume > 0f) {
			_sprite.sprite = noteOff;
			musicSource.volume = 0f;
		} else {
			_sprite.sprite = noteOn;
			musicSource.volume = 0.4f;
		}
	}
}
