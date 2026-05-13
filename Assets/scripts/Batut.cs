using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batut : MonoBehaviour
{
   [Header("Упругость батута")]
   [Space]
   [SerializeField] private float _force;

   [SerializeField] private AudioSource batytSound;

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if(collision.gameObject.CompareTag("Player"))
        {
            //collision.rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            batytSound.Play();
        }
   }
}
