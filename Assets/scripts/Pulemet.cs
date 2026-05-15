using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulemet : MonoBehaviour
{
    [SerializeField]
    private float rate;

    // Ссылка на префаб пули, которую мы будем создавать
    [SerializeField]
    private GameObject bulletPrefab;

    // Точка, из которой вылетают пули (можно указать сам пулемет или пустой дочерний объект)
    [SerializeField]
    private Transform firePoint;

    private void Awake()
    {
        // Если firePoint не назначен в инспекторе, пули будут лететь из центра пулемета
        if (firePoint == null)
        {
            firePoint = transform;
        }

        InvokeRepeating("shoot", rate, rate);
    }

    private void shoot()
    {
        // Создаем пулю в позиции firePoint с его текущим поворотом
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
