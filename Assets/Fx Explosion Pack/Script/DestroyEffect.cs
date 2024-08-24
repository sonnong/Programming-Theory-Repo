using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour
{
	private float speed = 3f, bottomBound = -9f;
	void Update ()
	{
		transform.Translate(Time.deltaTime * speed * Vector3.down, Space.World);
		if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
	}
}
