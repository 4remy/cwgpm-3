using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//added
using System.Linq;

//end of added

//this is too complicated to add to the interactable class, sorry.
//if a storyitem, dialog, or message is running while this is running, it throws off the timing

public class ImageTime : MonoBehaviour
    //ISerializationCallbackReceiver
{
    private float waitTime = 2.0f;
    private float timer = 0.0f;
    public GameObject CustomImage;

    public bool playerInRange;
    public bool disableWhenDiscovered = false;
  //  public HashSet<StoryItem> requiredStoryItems;
   // public HashSet<InventoryItem> requiredInventoryItems;

   // [SerializeField] StoryItem[] _requiredStoryItems;
   // [SerializeField] InventoryItem[] _requiredInventoryItems;
   // [SerializeField] private Image image = default;

  //  GameModel model = Schedule.GetModel<GameModel>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && (timer > waitTime))
        {
          /*  foreach (var requiredInventoryItem in requiredInventoryItems)
                if (requiredInventoryItem != null)
                    if (!model.HasInventoryItem(requiredInventoryItem.name))
                        return;
            foreach (var requiredStoryItem in requiredStoryItems)
                if (requiredStoryItem != null)
                    if (!model.HasSeenStoryItem(requiredStoryItem.ID))
                        return;
          */
            if (CustomImage.activeInHierarchy)
            {
                CustomImage.SetActive(false);
                if (disableWhenDiscovered) gameObject.SetActive(false);
            }
            else
            {
                CustomImage.SetActive(true);
                timer = timer - waitTime;
            }

        }
    }

    /*
    private void ChangeImageSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
    */

    //note: the foreeach section needs to be in a different place, then it will work properly.

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left range");
            playerInRange = false;
            CustomImage.SetActive(false);
            // if (disableWhenDiscovered) gameObject.SetActive(false);
        }
    }

    /*
    public void OnBeforeSerialize()
    {
        if (requiredInventoryItems != null)
            _requiredInventoryItems = requiredInventoryItems.ToArray();

        if (requiredStoryItems != null)
            _requiredStoryItems = requiredStoryItems.ToArray();
    }

    public void OnAfterDeserialize()
    {
        requiredStoryItems = new HashSet<StoryItem>();
        if (_requiredStoryItems != null)
            foreach (var i in _requiredStoryItems) requiredStoryItems.Add(i);


        requiredInventoryItems = new HashSet<InventoryItem>();
        if (_requiredInventoryItems != null)
            foreach (var i in _requiredInventoryItems) requiredInventoryItems.Add(i);
    */
    }
