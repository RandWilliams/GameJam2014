using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckOfCards : MonoBehaviour
{
	public List<GameObject> deck = new List<GameObject>();
	
	private List<GameObject> cards = new List<GameObject>();
	private List<GameObject> hand = new List<GameObject>();
	private GameObject oldCard;
	private int cardsDealt = 0;
	private bool showReset = false;
	private Rect topCard = new Rect(5, 5, 200, 200), 
		secondCard = new Rect(210, 5, 100, 100), 
		thirdCard = new Rect(315, 5, 100, 100), 
		fourthCard = new Rect(420, 5, 100, 100);
	
	void ResetDeck()
	{
		//cardsDealt = 0;
		//for (int i = 0; i < hand.Count; i++) {
		//	Destroy(hand[i]);
		//}
		//hand.Clear();
		cards.Clear();
		cards.AddRange(deck);
		showReset = false;
	}
	
	GameObject DealCard()
	{
		if(cards.Count == 0)
		{
			showReset = true;
			return null;
			//Alternatively to auto reset the deck:
			//ResetDeck();
		}
		
		int card = Random.Range(0, cards.Count - 1);
		GameObject go = GameObject.Instantiate(cards[card]) as GameObject;
		cards.RemoveAt(card);
		
		if(cards.Count == 0) {
			showReset = true;
		}
		
		return go;
	}
	
	void Start()
	{
		ResetDeck();
		MoveDealtCard();
		MoveDealtCard();
		MoveDealtCard();
		MoveDealtCard();
	}
	
	void Update()
	{

	}
	
	void GameOver()
	{
		cardsDealt = 0;
		for (int v = 0; v < hand.Count; v++) {
			hand.RemoveAt (v);
		}
		hand.Clear();
		cards.Clear();
		cards.AddRange(deck);
	}
	
	void OnGUI()
	{
		/*if (!showReset) {
			// Deal button
			if (GUI.Button(new Rect(10, 10, 100, 20), "Play"))
			{
				//hand[0] = hand[1];
				//hand[1] = hand[2];
				//hand[2] = hand[3];
				GameObject newCard = DealCard();
				if (newCard == null) {
					Debug.Log("Empty deck, shuffling a fresh one");
					ResetDeck();
					newCard = DealCard();
				}
				hand.Add (newCard);
				if (cardsDealt > 0)
				{
					Destroy (hand[cardsDealt-1]);
				}
				//hand[cardsDealt].transform.position = new Vector3( 0, 0, -4);
				//hand[cardsDealt+1].transform.position = new Vector3( 1, 0, 0 / 4);
				//hand[cardsDealt+2].transform.position = new Vector3( 2, 0, 0 / 4);
				//hand[cardsDealt+3].transform.position = new Vector3( 3, 0, 0 / 4); // place card 1/4 up on all axis from last
				cardsDealt++;
			}
		}*/
		/*else {
			// Reset button
			if (GUI.Button(new Rect(10, 10, 100, 20), "Reset"))
			{
				ResetDeck();
			}
		}*/
		if (GUI.Button(topCard,hand[0].guiTexture.texture) 
		    //&& transform.Find("Main Camera").GetComponent<CameraControl>().focusNode != null
		    )
		{
			//do things
			switch(hand[0].tag)
			{
			case ("Infect"):
				Debug.Log ("Infection!");
//								transform.Find("Main Camera")
//									.GetComponent<CameraControl>().focusNode
//										.GetComponent<Infectable>().infected = true;
				break;
			case ("Sever"):
				Debug.Log ("Isolated!");
				break;
			case ("Condom"):
//				Debug.Log ("Condom distributed!");
//				transform.Find("Main Camera")
//					.GetComponent<CameraControl>().focusNode
//						.GetComponent<Infectable>().chanceToBeInfected *= 0.1f;
//				transform.Find("Main Camera")
//					.GetComponent<CameraControl>().focusNode
//						.GetComponent<Infectable>().chanceToInfect *= 0.4f;
				break;
			case ("PrEP"):
//				transform.Find("Main Camera")
//					.GetComponent<CameraControl>().focusNode
//						.GetComponent<Infectable>().chanceToBeInfected *= 0.1f;
				Debug.Log ("PrEP administered!");
				break;
			case ("ART"):
//				transform.Find("Main Camera")
//					.GetComponent<CameraControl>().focusNode
//						.GetComponent<Infectable>().chanceToInfect *= 0.4f;
				Debug.Log ("ART administered!");
				break;
			case ("Testing"):
//				transform.Find("Main Camera")
//					.GetComponent<CameraControl>().focusNode
//						.GetComponent<Infectable>().tested = true;
				Debug.Log ("Tested!");
				break;
			default:
				Debug.Log ("Nothing!");
				break;
			}
			//handle card motion
			GameObject newCard = DealCard();
			if (newCard == null) {
				Debug.Log("Empty deck, shuffling a fresh one");
				ResetDeck();
				newCard = DealCard();
			}
			hand.Add (newCard);
			//if (cardsDealt > 0)
			{
				hand.RemoveAt (0);
			}
			cardsDealt++;
		}
		GUI.Box(secondCard,hand[1].guiTexture.texture);
		GUI.Box(thirdCard,hand[2].guiTexture.texture);
		GUI.Box(fourthCard,hand[3].guiTexture.texture);
		/*// GameOver button
		if (GUI.Button(new Rect(Screen.width - 110, 10, 100, 20), "GameOver"))
		{
			GameOver();
		}*/
	}
	
	void MoveDealtCard()
	{
		GameObject newCard = DealCard();
		// check card is null or not
		if (newCard == null) {
			Debug.Log("Out of Cards");
			showReset = true;
			return;
		}
		/*if (oldCard != null)
		{
			Destroy(hand[0]);
			hand.Remove(oldCard);
		}*/
		oldCard = newCard;
		//newCard.transform.position = Vector3.zero;
		newCard.transform.position = new Vector3((float)cardsDealt,  (float)cardsDealt, (float)cardsDealt / 4); // place card 1/4 up on all axis from last
		hand.Add(newCard); // add card to hand
	}
}
