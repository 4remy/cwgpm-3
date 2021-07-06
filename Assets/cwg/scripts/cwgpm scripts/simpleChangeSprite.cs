using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This has been changed to set emotion once character interacts with spacebar press. 
 */
//remember: your NPC/character needs a collision2D on it
//set the collider to trigger
public class simpleChangeSprite : Interactable
{

    // this is not STORED IN A BoolValue
    //this means it resets when you visit a new room
    //if you want it to stay stored , you need to set a BoolValue like in the snowpile script

    public bool isShut;

    [Header("Animation")]
    private Animator animator;


    // go back to the mr taft treasure chest tutorial if you still cant get this to work.

    void Start()
    {
        animator = GetComponent<Animator>();
        if (isShut)
        {
            animator.SetBool("isShut", true);
        }

    }

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isShut)
            {
                interactedState();
            }
            else
            {
                noInteractedState();
            }
        }
    }

    private void interactedState()
    {
        animator.SetBool("isShut", false);
        Debug.Log("sprite set to  interacted ");
    }

    private void noInteractedState()
    {
        animator.SetBool("isShut", true);

    }
}

//this works in tandem with an animaton controller and extends its potential applications
// bc it can say 'set the animator' and have a condition for like, if you have X inventory item, and THEN change emotion if you fulfill that.
//seems like you might want to use this on the character bust if you end up building an empty game object, with a sprite displayer on it, and put that in the dialogue box prefab on the UI canvas.
//then you could work out how to 'set' the emotion in the dialogue.



//this is a manager for the animation controller
//the animation controller is a type of state machine
