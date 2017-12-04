using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPrompt : MonoBehaviour
{

	public static RandomPrompt inst;

	public string person;
	public string place;
	public string action;

	private string[] PersonArray = {
		"Princess",
		"Cowboy",
		"Benjamin Franklin",
		"Beyonce",
		"Elvis",
		"Lady Gaga",
		"Abraham Lincoln",
		"Mickey Mouse",
		"Dumbledore",
		"A dragon",
		"A unicorn",
		"Indiana Jones",
		"Darth Vader",
		"Batman",
		"Van Gogh",
		"Santa",
		"Superman",
		"Wonder Woman",
		"Cleopatra",
		"Mr. Monopoly",
		"James Bond",
		"Tilda Swinton",
		"Bigfoot",
		"The Little Mermaid",
		"Homer Simpson",
		"Poseidon",
		"Mario",
		"Marie Antoinette",
		"DaVinci",
		"Beethoven"
	};

	private string[] PlacesArray = {
		"Mars",
		"Wonderland",
		"Submarine",
		"North Pole",
		"Mt. Everest",
		"Paris",
		"The moon",
		"The Underworld",
		"Dungeon",
		"Swimming pool",
		"Desert island",
		"Castle",
		"Circus",
		"Casino",
		"Airport",
		"The Titanic",
		"Volcano",
		"Stonehenge",
		"The Pyramids",
		"Hollywood",
		"Subway",
		"The Grand Canyon",
		"Dark forest",
		"Game show",
		"The mall",
		"Stuck in traffic",
		"Beach",
		"Jungle",
		"The internet",
		"Graveyard"
	};

	private string[] ActionsArray = {
		"On a road trip",
		"Surprising someone",
		"Inventing",
		"Skydiving",
		"Baking a cake",
		"Digging",
		"Singing",
		"Shouting",
		"Sleeping",
		"Battling aliens",
		"Eating dinner",
		"Collecting antiques",
		"Researching",
		"Growing crops",
		"Hiding",
		"Haunting a house",
		"Making toast",
		"Working out",
		"Going on a date",
		"Missing the bus",
		"Crying",
		"Escaping",
		"Camping",
		"Flying",
		"Shopping",
		"Walking a dog",
		"Sightseeing",
		"Party crashing",
		"Sneezing",
		"Doing yoga"
	};

	// Use this for initialization
	void Awake ()
	{

		inst = this;
		DontDestroyOnLoad (this);

		//for each of the 3 arrays, find random word
		person = PersonArray [Random.Range (0, PersonArray.Length)];
		Debug.LogError (person);

		//for each of the 3 arrays, find random word
		place = PlacesArray [Random.Range (0, PlacesArray.Length)];
		Debug.LogError (place);

		//for each of the 3 arrays, find random word
		action = ActionsArray [Random.Range (0, ActionsArray.Length)];
		Debug.LogError (action);

	}
	

}
