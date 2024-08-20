using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIcon : MonoBehaviour
{
    private float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateShip());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotateShip()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
