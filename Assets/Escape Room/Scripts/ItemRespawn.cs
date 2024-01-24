using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    [SerializeField] private Transform Cube;
    [SerializeField] private Transform RespawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Respawn");
            Cube.transform.position = RespawnPoint.transform.position;
            Rigidbody Cube_RB = Cube.GetComponent<Rigidbody>();
            if (Cube_RB != null)
            {
                Cube_RB.velocity = Vector3.zero;
                Cube_RB.angularVelocity = Vector3.zero;
            }
        }
    }
}