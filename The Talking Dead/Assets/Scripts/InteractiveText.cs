using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveText : MonoBehaviour {

    TouchController controller;
    Color origColor;
    [SerializeField]
    private Color highlightColor = Color.red;
    [SerializeField]
    private Color clickedColor = Color.gray;
    [SerializeField]
    private List<UnityEvent> _events;

    // Use this for initialization
    void Start () {
        origColor = GetComponent<TextMesh>().color;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        controller = other.GetComponent<TouchController>();

        if (controller) //detect if trigger is controller
        {
            TouchHighlight(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (controller) //detect if trigger is controller
        {
            if (OVRInput.Get(OVRInput.Button.One)) //"A" button down
            {
                //add button down events here
                ClickHighlight(true);
            }
            else
            {
                ClickHighlight(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        controller = other.GetComponent<TouchController>();

        if (controller)
        {
            TouchHighlight(false);

        }
    }

    /// <summary>
    /// highlight text when touched by controller
    /// </summary>
    /// <param name="touched"></param>
    private void TouchHighlight(bool touched)
    {    
        if (touched)
        {
            GetComponent<TextMesh>().color = highlightColor;
        }
        else
        {
            GetComponent<TextMesh>().color = origColor;
        }
    }

    /// <summary>
    /// highlight text when controller button down
    /// </summary>
    /// <param name="clicked"></param>
    private void ClickHighlight(bool clicked)
    {
        if (clicked)
        {
            GetComponent<TextMesh>().color = clickedColor;
        }
        else
        {
            GetComponent<TextMesh>().color = highlightColor;
        }
    }
}
