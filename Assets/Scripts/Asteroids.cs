using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : Enemies
{
    public GameObject ChildAsteroids;
    private int numberOfChilds = 3;

    void OnTriggerEnter(Collider other)
    {
        Explodes();
       
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            MainManager.Instance.GameOver();
        }

        Scatter();
    }

    void Scatter()
    {
        for (int i = 0; i < numberOfChilds; i++)
        {
            Instantiate(ChildAsteroids, transform.position, Random.rotation);
        }
    }
}
