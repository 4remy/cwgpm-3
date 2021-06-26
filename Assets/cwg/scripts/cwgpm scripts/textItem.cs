using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textItem : Interactable
{
    //use that bool if you only want it to be shown once
    //public bool isShown;
    public bool isShowing;
    public GameObject dialogBox;
    public Text dialogText;
    [Multiline]
    public string dialog;

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            //change bool to this to have it only show once
            //if (!isShown)
            if (!dialogBox.activeInHierarchy)
            {
                ShowText();
            }
            else
            {
                Unshow();
            }
        }

    }

    public void ShowText()
    {
        //dialog on
        dialogBox.SetActive(true);
        dialogText.text = dialog;

        //this is for if you only want it once
        //  isShown = true;
        //go into snowpile if you want a different animation to show after interacting

    }
    public void Unshow()
    {
        //turn dialog off
        dialogBox.SetActive(false);
        //turn invisible if you want this to only display once

    }
}
