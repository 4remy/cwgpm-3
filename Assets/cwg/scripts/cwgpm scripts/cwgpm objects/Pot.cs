using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a pot breaks when you press the space key.

public class Pot : Interactable
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //override interact, to say what happens during an interaction for this object

    protected override void Interact()
    {
        Debug.Log("interacting");
        anim.SetBool("smash", true);
        StartCoroutine(BreakCo());
    }

    //this coroutine is an add the action that interact triggers

    private IEnumerator BreakCo()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}