using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a cross is an item that BREAKS IMMEDIATELY when you touch it
//you don't press space, just walk into it.

public class Cross : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void smash()
    {
       anim.SetBool("smash", true);
       StartCoroutine(breakCo());
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}

