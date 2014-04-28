using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public Sprite noteOn;
	public Sprite noteOff;

	public AudioSource[] soundsAndMusic;

	private bool _soundOn;
	private SpriteRenderer _sprite;

	// Use this for initialization
	void Start () {
		_sprite = GetComponent<SpriteRenderer>();
		_soundOn = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		soundOn = !soundOn;
	}

	public bool soundOn {
		get {
			return _soundOn;
		}
		set {
			_soundOn = value;
			if(_soundOn) {
				_sprite.sprite = noteOn;
				foreach(AudioSource au in soundsAndMusic) {
					au.volume = 1.0f;
				}
			} else {
				_sprite.sprite = noteOff;
				foreach(AudioSource au in soundsAndMusic) {
					au.volume = 0.0f;
				}
			}
		}
	}
}
