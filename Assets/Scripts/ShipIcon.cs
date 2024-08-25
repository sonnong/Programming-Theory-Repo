using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIcon : MonoBehaviour
{
    private float rotationSpeed = 50f;
    // Start is called before the first frame update

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
    }
}
