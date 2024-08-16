using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatHeight;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatHeight = GetComponent<Collider2D>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance.isGameActive)
        {
            transform.Translate(Time.deltaTime * speed * Vector3.down);
            if (transform.position.y < startPos.y - repeatHeight)
            {
                transform.position = startPos;
            }
        }

    }
}
