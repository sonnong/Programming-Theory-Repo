using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float speed = 3f, bottomBound = -9f;
    public GameObject Explosion, Powerup;

    // Update is called once per frame
    public virtual void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.down, Space.World);
        if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Explodes();
            other.gameObject.SetActive(false);
            MainManager.Instance.score += 1;

            // Randomly spawn a powerup
            if (Random.Range(0, 5) == 1)
            {
                SpawnPowerup();
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Explodes();
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.CompareTag("Player"))
        {
            Explodes();
            other.gameObject.SetActive(false);
            MainManager.Instance.GameOver();
        }
    }

    public void Explodes()
    {
        Instantiate(Explosion, transform.position, Explosion.transform.rotation);
        Destroy(gameObject);
        MainManager.Instance.SoundEffect.PlayOneShot(MainManager.Instance.ExplosionSound, 0.4f);
    }

    void SpawnPowerup()
    {
        Instantiate(Powerup, transform.position, Random.rotation);
    }
}
