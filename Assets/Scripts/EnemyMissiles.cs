using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissiles : Enemies
{
    private Vector3 targetDirection;
    private GameObject player;
    private Rigidbody missileRb;
    private float thrustForce = 1f;
    // Update is called once per frame  
    void Start()
    {
        player = GameObject.Find("Player");
        missileRb = GetComponent<Rigidbody>();
    }
    public override void Update()
    {
        base.Update();
        if (MainManager.Instance.isGameActive)
        {
            targetDirection = (player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(targetDirection);
            missileRb.AddForce(thrustForce * Time.deltaTime * transform.forward, ForceMode.VelocityChange);
        }
    }
}
