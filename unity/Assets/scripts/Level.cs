using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
	private string levelName;
	private List<List<TileBase>> levelData;

	public Level(string name) {
		levelName = name;
		levelData = new List<List<TileBase>>();
	}

	// returns the reference of the tile so it can be manipulated
	public TileBase GetTileAt(int x, int y) {
		return null;
	}

	// returns true if level loaded ok; false otherwise
	public bool LoadLevel(TileLoader loader, string levelName) {

		// use the tile factory to get a certain tile and get an instance and put
		// into levelData
		return false;
	}

	// returns true if the ship could move there or not
	public bool CanMoveTo(ShipType shipType, int x, int y) {
		return false;
	}

	// returns the cost of the ship moving to location
	public float MoveCost(ShipType shipType, int x, int y) {
		return 0.0f;
	}
}

