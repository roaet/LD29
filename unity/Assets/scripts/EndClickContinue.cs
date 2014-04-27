using UnityEngine;
using System.Collections;

public delegate void ContinueClicked();

public class EndClickContinue : MonoBehaviour {

	private SpriteRenderer _sprite;
	private ContinueClicked cb;

	// Use this for initialization
	void Start () {
		_sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public SpriteRenderer sprite {
		get {
			return _sprite;
		}
	}

	public ContinueClicked continueClicked {
		set {
			cb = value;
		}
	}

	void OnMouseUp(){
		cb();
	}
}
