using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudienceUI : MonoBehaviour {

    public Text Words;
    public Text Usernames;

    public void UpdateText(List<WordZombie> currentZombies)
    {
        Words.text = "";
        Usernames.text = "";

        for (int i = 0; i < currentZombies.Count; i++)
        {
            ZombieInfo info = currentZombies[i].GetInfo();
            Words.text += info.word;
            Usernames.text += info.user;

            if(i < currentZombies.Count - 1)
            {
                Words.text += "\n";
                Usernames.text += "\n";
            }
        }
    }
}
