using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    [SerializeField] private Vector3 offsetPosition;

    private bool shouldFollowPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        shouldFollowPlayer = true;
    }

    private void Update()
    {
        // Update is called once per frame
    }

    // called every frame but after update
    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FixedUpdate()
    {
        // fixed nr of frame intervals (edit > projectSettings > Time
    }

    void FollowPlayer()
    {
        transform.position = target.TransformPoint(offsetPosition);

        transform.rotation = target.rotation;

        if (shouldFollowPlayer)
        {
            transform.position = target.TransformPoint(offsetPosition);

            transform.rotation = target.rotation;
        }
    }

    public void setFollow(bool ans)
    {
        shouldFollowPlayer = ans;
    }
} // class
