using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SchwerInventory = Schwer.ItemSystem.Inventory;

public enum DoorType
{
    keyDoor,
    keyBox,
    button
}

public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open;
    public BoolValue storedOpen;

    [Header("Inventory")]
    [SerializeField] private Schwer.ItemSystem.InventorySO _inventory = default;
    public SchwerInventory inventory => _inventory.value;
    // public Inventory playerInventory;
    //public SpriteRenderer doorSprite;

    [Header("Contents")]
    [SerializeField] private Schwer.ItemSystem.Item item = default;
    [Header("Key")]
    [SerializeField] private Schwer.ItemSystem.Item key = default;

    [Header("Signals and Dialog")]
    public BoxCollider2D physicsCollider;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator animator;

    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        open = storedOpen.RuntimeValue;
        if(open)
        {
            animator.SetBool("Open", true);
        }
 

    }

    protected override void Interact()
    {
        if (player.inventory[key] > 0)
        {
            Debug.Log("you had a key!");
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange && thisDoorType == DoorType.keyBox)
            {
                if (!open)
                {
                    OpenBox();
                }
                else
                {
                    Close();
                }

            }
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange && thisDoorType == DoorType.keyDoor)
            {
                OpenDoor();
                Debug.Log("open door called!");
            }
        }
        else
        {
            Close();
        }
        Debug.Log("you have no keys!");
    }

    public void OpenDoor()
    {
        //minus one key
        player.inventory[key]--;

        //change to different sprite
        animator.SetBool("Open", true);
        Debug.Log("door Opened");
        storedOpen.RuntimeValue = open;
        //the door needs an animator for open
        open = true;
        //the box collider block is diabled
        physicsCollider.enabled = false;
    }

    public void OpenBox()
    {
        //minus one key
        player.inventory[key]--;

        Debug.Log("box should open");
        dialogBox.SetActive(true);
        dialogText.text = item.description;

        //add contents to the inventory
        player.inventory[item]++;
        //raise the signal to the player
        player.RaiseItem(item);

        open = true;

        //change to different sprite
        animator.SetBool("Open", true);
        //set saved open value to true
        storedOpen.RuntimeValue = open;
        //turn off dialog if its annoying you
        dialogBox.SetActive(false);
    }

    public void Close()
    {
        Debug.Log("box closed apparently");
        //turn dialog off
        dialogBox.SetActive(false);
        //raise the signal to the player to stop animating
        player.RaiseItem(null);
    }


    
}
