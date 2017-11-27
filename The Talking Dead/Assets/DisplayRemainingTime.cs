using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRemainingTime : MonoBehaviour {

    TextMesh tm;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tm.text != (120.00 - Time.time).ToString("F"))
        {
            tm.text = (120.00 - Time.time).ToString("F");
        }
    }
}
