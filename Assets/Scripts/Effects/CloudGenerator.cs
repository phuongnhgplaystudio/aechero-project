using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject cloudPrefab;
    private float countdown;
    private float time = 3f;

    void Update()
    {
        if(countdown < 0)
        {
            Instantiate(cloudPrefab, transform.position, Quaternion.identity);
            countdown = time;
        }
        countdown -= Time.deltaTime;
    }
}
