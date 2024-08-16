using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 30, topBound = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);

        if (transform.position.y > topBound)
        {
            gameObject.SetActive(false);
        }
    }
}
