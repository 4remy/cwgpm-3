using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected CharacterController2D player { get; private set; }
    protected bool playerInRange => player != null;

    protected abstract void Interact();
    protected virtual void Exit() {}

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CharacterController2D>();
        if (player != null)
        {
            this.player = player;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController2D>() != null)
        {
            player = null;
            Exit();
        }
    }
}
