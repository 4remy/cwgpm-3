using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : Interactable
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public int currentSprite;

    protected override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            Debug.Log("interacted");
            ChangeSprite();
        }
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[currentSprite];
        currentSprite++;

        if (currentSprite >= spriteArray.Length)
        {
            currentSprite = 0;
        }
    }
}
