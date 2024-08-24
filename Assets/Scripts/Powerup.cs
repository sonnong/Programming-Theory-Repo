using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 3f, bottomBound = -9f;
    private float rotationSpeed = 50f, powerRate = 1.1f;
    private Player playerShip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotatePowerup());
        playerShip = GameObject.Find("Player").GetComponent<Player>();
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

    IEnumerator RotatePowerup()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            MainManager.Instance.SoundEffect.PlayOneShot(MainManager.Instance.PowerupSound);
            playerShip.coolDown /= powerRate; // Reduce weapon cooldown
        }
    }
}
