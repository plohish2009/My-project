using UnityEngine;

public class Books : MonoBehaviour
{
    public GameObject[] GObject;
    public static int counter = 0;
    [SerializeField] private AudioSource bookSound;

    private void OnTriggerEnter2D(Collider2D collision)
   {
        GObject = GameObject.FindGameObjectsWithTag("door");

        if (collision.gameObject.CompareTag("Player"))
        {
            bookSound.Play();
            gameObject.SetActive(false);
            counter++;
            Debug.Log(counter);
            if (counter == 1)
            {
                Destroy(GObject[0]);
            }
        }
   }
}