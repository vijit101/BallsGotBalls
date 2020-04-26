using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rgbd;
    GameObject player;
    public float chasingSpeed = 1;
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        player = PlayerController.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rgbd.AddForce(lookDirection*chasingSpeed);
        if (transform.position.y < -10)
        {
            SpawnManager.enemyList.Remove(this);
            Destroy(gameObject);
        }
        // normalized keeps the distance of vector but clamp the value to 1 so now enemy will always come at player with same speed as 
        // now if distance btw player and enemy is 10 units or 2 units force added is 1 as it is normalized basically a unity vector direction 
    }
}
