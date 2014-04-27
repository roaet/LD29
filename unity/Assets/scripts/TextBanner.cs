using UnityEngine;
using System.Collections;

public class TextBanner : MonoBehaviour {

	public GUIText textObject;
	public EndClickContinue continueObject;
	public SpriteRenderer fader;

	private bool _isVisible;
	private SpriteRenderer sprite;
	private string _text;
	private ContinueClicked cb;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public ContinueClicked endCallback {
		set {
			continueObject.continueClicked = value;
		}
	}

	public string text {
		get {
			return _text;
		}
		set {
			_text = value;
			textObject.text = _text;
		}
	}

	public bool visible {
		get {
			return _isVisible;
		}
		set {
			_isVisible = value;
			sprite.renderer.enabled = _isVisible;
			textObject.enabled = _isVisible;
			continueObject.sprite.renderer.enabled = _isVisible;
			fader.renderer.enabled = _isVisible;
		}
	}
}
