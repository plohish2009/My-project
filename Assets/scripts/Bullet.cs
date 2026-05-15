using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f; // Скорость полета пули

    [SerializeField]
    private float lifetime = 4f; // Время жизни пули в секундах до исчезновения

    // Start is called before the first frame update
    void Start()
    {
        // Уничтожить этот объект автоматически спустя lifetime секунд
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        // Непрерывное движение пули вперед по ее локальной оси X
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Если пуля должна исчезать при попадании в препятствия (стены, землю)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, что пуля не задела сам пулемет или другие пули
        if (collision.CompareTag("Ground")) 
        {
            Destroy(gameObject);
        }
    }
}

