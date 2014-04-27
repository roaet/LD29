using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	
	public EndClickContinue continueObject;
	public SpriteRenderer fader;

	private bool _isVisible;
	private SpriteRenderer sprite;
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

	
	
	public bool visible {
		get {
			return _isVisible;
		}
		set {
			_isVisible = value;
			sprite.renderer.enabled = _isVisible;
			continueObject.sprite.renderer.enabled = _isVisible;
			fader.renderer.enabled = _isVisible;
		}
	}
}
