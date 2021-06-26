using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SchwerInventory = Schwer.ItemSystem.Inventory;

/* This has been changed to set emotion once character interacts with spacebar press. 
 */
//remember: your NPC/character needs a collision2D on it
//set the collider to trigger
public class EmotionManager : Interactable
{
    enum State
    {
        happy, sad, angry, sawItem
    }

    State state = State.happy;

    [Header("Animation")]
    private Animator animator;

    [Header("Inventory")]
    [SerializeField] private Schwer.ItemSystem.InventorySO _inventory = default;
    public SchwerInventory inventory => _inventory.value;

    [Header("Special Item")]
    [SerializeField] private Schwer.ItemSystem.Item specialItem = default;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            //automatically starts as happy
            switch (state)
            {
                case State.happy:
                    happyState();
                    break;
                case State.sad:
                    sadSate();
                    break;
                case State.angry:
                    angryState();
                    break;
                case State.sawItem:
                    sawItemState();
                    break;
            }
            //this is just an example that shows you an 'if' case where the state gets changed
            //you can put your own condition into the brackets below
            //some example, if the number of sadItem in the inventory are greater than zero

            if (Input.GetMouseButtonDown(0))
            {
                sadSate();
            }

            if (player.inventory[specialItem] > 0)
            {
                sawItemState();
                //it doesn't 'use up' the item,
                //save that for later

            }

        }
    }

    public void happyState()
    {
        animator.SetBool("happy", true);
        // no debug log to say 'happy', because its the default emotion, AND on a fixed update. it will spam you in updates that it's happy, for every time it does a check at a fixed update of time
    }

    public void sadSate()
    {
        animator.SetBool("sad", true);
        Debug.Log("emotion changed to sad");
    }

    public void angryState()
    {
        animator.SetBool("angry", true);
        Debug.Log("emotion changed to angry");
    }

    public void sawItemState()
    {
            animator.SetBool("sawItem", true);
            Debug.Log("emotion changed to sawitem");
    }
}

//this works in tandem with an animaton controller and extends its potential applications
// bc it can say 'set the animator' and have a condition for like, if you have X inventory item, and THEN change emotion if you fulfill that.
//seems like you might want to use this on the character bust if you end up building an empty game object, with a sprite displayer on it, and put that in the dialogue box prefab on the UI canvas.
//then you could work out how to 'set' the emotion in the dialogue.



//this is a manager for the animation controller
//the animation controller is a type of state machine
