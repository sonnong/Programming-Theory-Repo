using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float speed = 4f, bottomBound = -9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.down, Space.World);
        if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        if (other.gameObject.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
            MainManager.Instance.score += 1;
        }
        else
        {
            Destroy(other.gameObject);
            MainManager.Instance.GameOver();
        }

    }
}
