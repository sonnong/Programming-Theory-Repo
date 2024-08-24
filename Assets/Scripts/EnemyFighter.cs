using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// INHERITANCE
public class EnemyFighter : Enemies
{
    public GameObject rocket;
    private float rocketCooldown = 1.5f;
    
    void Start()
    {
        StartCoroutine(LaunchRocket());
    }

    // POLYMORPHISM
    IEnumerator LaunchRocket()
    {
        while (MainManager.Instance.isGameActive)
        {
            yield return new WaitForSeconds(rocketCooldown);
            Instantiate(rocket, transform.position, rocket.transform.rotation);
            MainManager.Instance.SoundEffect.PlayOneShot(MainManager.Instance.MissileSound, 0.75f);
            yield return null;
        }
    }
}
