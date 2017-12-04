using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWordQueueFiller : MonoBehaviour {

	public WordQueue WordQueue;

	private string[] testWords = {
		"cockroach",
		"hobo",
		"Mario",
		"cake",
		"rover",
		"vulture",
		"skip",
		"lake",
		"parachute",
		"McDonalds",
		"dance",
		"plate",
		"drive",
		"sleek",
		"kitten",
		"snowflake",
		"haunt",
		"rap",
		"thunder",
		"fiddle",
		"Jupiter",
		"Zelda",
		"soar",
		"patriarchy",
		"vicissitudes",
		"alien",
		"airplane",
		"fly",
		"gravity",
		"empty",
		"laugh",
		"red",
		"pungent",
		"gourmet",
		"quixotic",
		"handkerchief",
		"rhythm",
		"pharoah",
		"Ares",
		"wormhole",
		"kingdom",
		"agriculture",
		"clouds",
		"hair",
		"dragon",
		"wealthy",
		"canyon",
		"tumbling",
		"Einstein",
		"moustache",
		"exciting", "gland", "paralysed", "gargoyle", "atrocity", "enter", "carcinogenic", "compartment", "hairless", "pull", "comrade", "best", "collectable", "patient", "gimmick", "fluctuation", "formal", "grave", "favor", "prophet", "sexiest", "daydreamer", "cynical", "predict", "fraction", "boundary", "drink", "someone", "mistaken", "cartel", "flower"
		};


	// Use this for initialization
	void Start () {

        reshuffle(testWords);

		for (int i = 0; i < testWords.Length; i++) {
            ZombieInfo info = new ZombieInfo(testWords[i], "");
            WordQueue.AddInfoToPremadeQueue(info);
		}
	}

    void reshuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

}
