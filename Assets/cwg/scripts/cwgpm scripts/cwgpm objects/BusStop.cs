using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : Interactable 
{
    public bool IsSitting;
    public Signal SittingSignal;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    // this solves the problem you had before
    // where it said you didnt implement the inheritance
    protected override void Interact()
    {
      if(!IsSitting)
      {
        SitDown();
       // Debug.Log("sit down has been triggered");
      }
      else
      {
        SitUp();
      }
       
    }

    public void SitDown()
    {
        SittingSignal.Raise();
      //  Debug.Log("signal raised i think");
        IsSitting = true;
    }

    public void SitUp()
    {
        SittingSignal.Raise();
        IsSitting = false;
    }
}
