using UnityEngine;
using UnityEngine.UI;

public class snowPile : Interactable
{
    [Header("Contents")]
    [SerializeField] private Schwer.ItemSystem.Item item = default;
    //old item
    // public Item contents;
    public bool isDug;
    //this is how the status of the pile gets remembered
    public BoolValue storedDug;
    //old inventory
    //public Inventory playerInventory;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isDug = storedDug.RuntimeValue;
        if (isDug)
        {
            animator.SetBool("isDug", true);
        }
    }

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isDug)
            {
                DigSnow();
            }
            else
            {
                SnowDug();
            }
        }
    }

    private void DigSnow()
    {
        //dialog on
        dialogBox.SetActive(true);
        // dialog text = contents text;
        dialogText.text = item.description;

        //add contents to the inventory
        player.inventory[item]++;

        //old inventory system
        //playerInventory.AddItem(contents);
        //playerInventory.currentItem = contents;
        //add schwer inventory item

        player.RaiseItem(item);
        //set the snow to dug
        isDug = true;
        animator.SetBool("isDug", true);
        storedDug.RuntimeValue = isDug;
    }

    private void SnowDug()
    {
        //turn dialog off
        dialogBox.SetActive(false);
        player.RaiseItem(null);
    }
}
