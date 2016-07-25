using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CardShuffler{
	public static void Shuffle<T>(this IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0,n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
}

public class GameManager : MonoBehaviour {
	public class Card
	{
		public int baseGold;
		public int baseBuy;
		public int baseSell;

		public enum Cards
		{
			TaxReturns
		}

		public Card(Cards cardEnum)
		{
			switch(cardEnum){
			case Cards.TaxReturns:
				baseGold = 4;
				baseBuy = 1;
				baseSell = 1;
				break;
			}
		}
	}


	public class Player{
		int baseBuy;
		int baseDraw;
		int baseSell;
		int baseMana;
		int baseIncome;

		public List<Card> deck;
		public Stack<Card> drawPile;

		public List<Card> hand;

		//Rrandom player constructor
		public Player(){
			//TODO: character rolling system

			baseBuy = Random.Range(1,4);
			baseDraw = Random.Range(1,4);
			baseSell = Random.Range(1,4);
			baseMana = Random.Range(1,4);
			baseIncome = Random.Range(300, 800);


			//Initialize starting deck
			CreateStartingHand();

		}

		public void CreateStartingHand()
		{
			deck = new List<Card> ();
			//TODO: 
			for (int i = 0; i < 10; i++) {
				Card newCard = new Card (Card.Cards.TaxReturns);
				deck.Add (newCard);
			}

		}

		public void DrawHand()
		{
			drawPile = new Stack<Card> ();

			List<Card> shuffledDeck = deck;

			CardShuffler.Shuffle (shuffledDeck);

			foreach (Card c in deck) {
				drawPile.Push (c);
			}

			while (drawPile.Count > 0 && hand.Count < baseDraw) 
			{
				DrawCard ();
			}
		}

		public void DrawCard()
		{
			if (drawPile.Count == 0) {
				return;
			}

			int drawIndex = Random.Range (0, drawPile.Count);

			Card drawnCard = drawPile.Peek ();
			drawPile.Pop();

			hand.Add (drawnCard);
		}

	}

	public Scenario scenario;

	public Player[] players;

	// Use this for initialization
	void Start () {
		PlayScenario (scenario);
	}

	void PlayScenario(Scenario scenario)
	{
		//Initialize each player

		players = scenario.Players;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void PlayTurn(Player p)
	{
		// Draw Phase
		p.DrawHand();

		// News Phase



		//Action Phase

		//Sell Phase

		//Buy Phase
	}
}
