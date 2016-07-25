using UnityEngine;
using System.Collections;

public class Scenario : MonoBehaviour {

	[SerializeField]private bool randomGame = true;

	[SerializeField]private GameManager.Player [] players;

	// Use this for initialization
	void Awake () {
		if (randomGame == true) {
			RandomizeScenario ();
		}
	}

	void RandomizeScenario()
	{
		int nPlayers = Random.Range (3, 8);

		players = new GameManager.Player[nPlayers];

		for (int i = 0; i < nPlayers; i++) {
			players [i] = new GameManager.Player ();
		}
	}

	public GameManager.Player [] Players{
		get{
			return players;
		}
	}
}
