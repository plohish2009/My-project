using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulemet : MonoBehaviour
{
    [SerializeField]
    private float rate;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    private void Awake()
    {
        if (firePoint == null)
        {
            firePoint = transform;
        }

        InvokeRepeating("shoot", rate, rate);
    }

    private void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
