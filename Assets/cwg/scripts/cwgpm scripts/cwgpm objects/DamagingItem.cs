/* 
 * this code doesnt give errors anymore, but combining an interactable item with the RPGnamespace
 * was too ambitious. they just dont play nice. knockback for damage, inherit from interactable for interactable things.
 * 
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPGM.Gameplay
{

    public class DamagingItem : Interactable
    {
        //private Animator anim;
        public float damage;
        public float knockTime;

        private void Start()
        {
            // add this for animation, then make a bool in the animator
            //for instance the bool "smash" from below
            // anim = GetComponent<Animator>();
        }

        //override interact, to say what happens during an interaction for this object
        protected override void Interact()
        {
            Debug.Log("hurting");
            // if you wanted it to start a specific animation you would use this
            //   anim.SetBool("smash", true);
            StartCoroutine(HurtCo());
        }

        //this coroutine is an add the action that interact 'triggers'
        private IEnumerator HurtCo()
        {
            {
                gameObject.GetComponent<CharacterController2D>().Knock(knockTime, damage);
            }
            //if the object needs to self destruct
            this.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }
}
*/