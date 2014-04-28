using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState { splash, menu, options, loading, playing, end };

public class Game : MonoBehaviour
{
	public TextBanner banner;
	public Title title;
	public TestStoryGenerator matchingGame;

	private GameState _currentState;
	private List<string> completedWords;

	// Use this for initialization
	void Start ()
	{
		currentState = GameState.menu;
		matchingGame.finishCallback = AllTilesMatched;
		banner.endCallback = EndContinueClicked;
		title.endCallback = TitleContinueClicked;
	}
	
	public void TitleContinueClicked() {
		currentState = GameState.playing;
		Debug.Log ("Switching to playing");
	}

	private string ConvertTileToString(Tile t) {
		Debug.Log ("Converting tile " + t.tileName + "!");
		switch(t.tileName) {
		case "tile_boy": return "boy";
		case "tile_broken": return "brokenheart";
		case "tile_bulb": return "bulb";
		case "tile_cat": return "cat";
		case "tile_fire": return "fire";
		case "tile_girl": return "girl";
		case "tile_heart": return "heart";
		case "tile_nuke": return "nuke";
		case "tile_rainbow": return "rainbow";
		case "tile_world": return "world";
		}
		return "boy";
	}
	
	public void EndContinueClicked() {
		currentState = GameState.playing;
		Debug.Log ("Switching to playing");
	}
	
	public void AllTilesMatched(List<Tile> s) {
		Debug.Log ("Finish callback called!");
		Debug.Log ("Tile list size: " + s.Count.ToString());
		List<string> stringies = new List<string>();
		foreach(Tile t in s) {
			stringies.Add (ConvertTileToString(t));
		}
		completedWords = stringies;
		foreach(string str in stringies) {
			Debug.Log ("Completed tile " + str);
		}
		currentState = GameState.end;
	}

	private void HideTitle() {
		Vector3 titlePosition = new Vector3(-25f, 2.5f, -1f);
		title.transform.position = titlePosition;
		title.visible = false;
	}
	
	private void HideBanner() {
		Vector3 bannerPosition = new Vector3(25f, 0f, -9.5f);
		banner.transform.position = bannerPosition;
		banner.visible = false;
		
	}
	
	private void ShowTitle() {
		Vector3 titlePosition = new Vector3(0f, 2.5f, -1f);
		title.transform.position = titlePosition;
		title.visible = true;
	}
	
	private void ShowBanner() {
		Vector3 bannerPosition = new Vector3(0f, 0f, -9.5f);
		banner.transform.position = bannerPosition;
		banner.visible = true;
	}

	private GameState currentState {
		get {
			return _currentState;
		}
		set {
			_currentState = value;
			switch(_currentState) {
			case GameState.splash:
				HideTitle();
				HideBanner();
				break;
				
			case GameState.menu:
				ShowTitle();
				HideBanner();
				break;
			case GameState.playing:
				matchingGame.load();
				HideTitle();
				HideBanner();
				break;
			case GameState.end:
				StoryGenerator gen = new StoryGenerator(completedWords);
				banner.text = gen.story;
				HideTitle();
				ShowBanner();
				break;
			}
		}
	}

	// Update is called once per frame
	// input is taken here
	void Update ()
	{
		switch(currentState) {
		case GameState.splash:
			break;
		case GameState.menu:
			break;
		case GameState.playing:
			break;
		case GameState.end:
			break;
		}
	}

}

