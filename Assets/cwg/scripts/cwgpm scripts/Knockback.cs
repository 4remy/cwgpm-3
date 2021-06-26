using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGM.Gameplay
{
    public class Knockback : MonoBehaviour
    {
        public float damage;
        public float knockTime;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                {
                    Debug.Log("within enemy range");
                    other.gameObject.GetComponent<CharacterController2D>().Knock(knockTime, damage);
                }
            }
        }
    }
}