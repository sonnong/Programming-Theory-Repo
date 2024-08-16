using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10, coolDown = 1;
    private float xBound = 3.75f, topBound = 6.72f, bottomBound = -6.42f;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance.isGameActive)
        {
            MovePlayer();
        }

    }

    void MovePlayer()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.right * Input.GetAxis("Horizontal"));
        transform.Translate(Time.deltaTime * speed * Vector3.up * Input.GetAxis("Vertical"));

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
 
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, bottomBound, transform.position.z);
        }

        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        }
    }

    IEnumerator ShootProjectile()
    {
        while (MainManager.Instance.isGameActive)
        {
            GameObject projectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (projectile != null)
            {
                projectile.SetActive(true);
                projectile.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
                yield return new WaitForSeconds(coolDown);
            }
            yield return null;
        }
        
    }
}
