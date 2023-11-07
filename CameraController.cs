using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetZ = 8f;
    public float smooting = 2f;
    Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = new(playerPos.position.x, transform.position.y, playerPos.position.z - offsetZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smooting * Time.deltaTime);
    }
}
