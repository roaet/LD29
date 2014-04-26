using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState { splash, menu, options, loading, playing, end };
public enum GameSubState { selecting, moving };

public class Game : MonoBehaviour
{
	public Level levelLoader;
	public Level currentLevel;

	private GameState currentState;

	// Use this for initialization
	void Start ()
	{
		currentState = GameState.splash;
	}

	// Update is called once per frame
	// input is taken here
	void Update ()
	{

	}

}

