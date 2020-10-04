using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float walkSpeed = 5.0f, runSpeed = 10.0f;
    [SerializeField] private float runBuildUpSpeed = 10.0f;
    [SerializeField] private KeyCode runKey = KeyCode.LeftShift;

    [SerializeField] private float slopeForce = 6.0f;
    [SerializeField] private float slopeForceRayLength = 1.5f;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier = 10.0f;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    private CharacterController charController;
    private float movementSpeed;
    bool isJumping;
    public bool ourPlayMode = false;

    public GameObject camera;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (ourPlayMode)
        {
            PlayerMovement();
            camera.transform.position = gameObject.transform.position - new Vector3(0.0f, -10.0f, 10.0f);
            camera.transform.LookAt(gameObject.transform);

        }
        else
        {
            camera.transform.position = new Vector3(0.0f, 3.49f, -10.0f);
            camera.transform.rotation = Quaternion.Euler(22.79f, 0.0f, 0.0f);
        }


    }

    private void PlayerMovement()
    {
        float horiInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horiInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed); //SimpleMove applies the time.deltaTime so we don't have to

        if ((vertInput != 0 || horiInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        SetMovementSpeed();
        JumpInput();
    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        else
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
    }

    private bool OnSlope()
    {
        if (isJumping)
            return false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
