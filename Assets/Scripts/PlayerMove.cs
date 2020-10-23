using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations playerAnimations;

    [SerializeField] private float movement_speed = 3f;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float rotation_speed = 0.15f;
    [SerializeField] private float rotateDegPSec = 180f;

    //first function called
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // second function called
    private void OnEnable()
    {
        
    }

    // third function called
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    } // update

    void Move()
    {
        if(Input.GetAxis(Axis.VERTICAL_AXIS) > 0) // up or W keys; slowly goes from 0 to 1; use GetAxisRaw to jump straight to 1
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime; // time.deltaTime is time between last two frames
            charController.Move(moveDirection * movement_speed * Time.deltaTime);
        }
        else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime; // time.deltaTime is time between last two frames
            charController.Move(moveDirection * movement_speed * Time.deltaTime);
        }else
        {
            charController.Move(Vector3.zero);
        }
    } // move

    void Rotate()
    {
        Vector3 rotation_Dir = Vector3.zero;

        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotation_Dir = transform.TransformDirection(Vector3.left);
        }

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotation_Dir = transform.TransformDirection(Vector3.right);
        }

        if(rotation_Dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, // from
                Quaternion.LookRotation(rotation_Dir), // to
                rotateDegPSec * Time.deltaTime // speed
            );
        }
    } // rotate

    void AnimateWalk()
    {
        if (charController.velocity.sqrMagnitude != 0f) // if moving
        {
            playerAnimations.Walk(true);
            //Debug.Log("Walking");
        }
        else
        {
            playerAnimations.Walk(false);
        }
    } // animatewalk
} // class
