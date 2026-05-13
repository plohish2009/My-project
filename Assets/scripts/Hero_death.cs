using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_death : MonoBehaviour
{

    [SerializeField] private AudioSource deathSound;
    public static int[] teleport_cords = {-3,2};
    public static int tracker = 0;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            Debug.Log("Игрок убит");
            //gameObject.transform.position = Teleport_Point;
            gameObject.transform.position = new Vector3(teleport_cords[tracker], teleport_cords[tracker + 1], 0);
            
            deathSound.Play();
        }
    }
}
