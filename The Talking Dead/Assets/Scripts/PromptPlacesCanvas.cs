﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptPlacesCanvas : MonoBehaviour {

    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = RandomPrompt.inst.place;
    }
}
