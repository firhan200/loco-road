using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Transform player;

    CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer, isJumping, isSlideRight, isSlideLeft;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f * 4;
    private float jumpTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        //jump foward
        if (Input.GetKeyUp(KeyCode.UpArrow) && !isJumping)
        {
            StartCoroutine(JumpFoward());
        }
        //horizontal
        if (Input.GetKeyUp(KeyCode.RightArrow) && !isSlideLeft)
        {
            StartCoroutine(SlideRight());
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && !isSlideLeft)
        {
            StartCoroutine(SlideLeft());
        }
    }

    void Move()
    {
        /* check if grounded */
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //check if jump foward
        if (isJumping)
        {
            //look foward
            player.rotation = Quaternion.Euler(0f, 0f, 0f);

            characterController.Move(Vector3.forward * speed * Time.fixedDeltaTime);

            if (groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }

        //check if slide right
        if (isSlideRight)
        {
            //player look right
            player.rotation = Quaternion.Euler(0f, 90f, 0f);

            characterController.Move(Vector3.right * speed * Time.fixedDeltaTime);

            if (groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }
        else if(isSlideLeft)
        {
            //player look right
            player.rotation = Quaternion.Euler(0f, -90f, 0f);

            characterController.Move(Vector3.left * speed * Time.fixedDeltaTime);

            if (groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    IEnumerator JumpFoward()
    {
        isJumping = true;

        animator.SetBool("IsJump", true);

        yield return new WaitForSeconds(jumpTime);

        isJumping = false;
        animator.SetBool("IsJump", false);
    }

    IEnumerator SlideRight()
    {
        isSlideRight = true;

        animator.SetBool("IsJump", true);

        yield return new WaitForSeconds(jumpTime);

        isSlideRight = false;
        animator.SetBool("IsJump", false);
    }

    IEnumerator SlideLeft()
    {
        isSlideLeft = true;

        animator.SetBool("IsJump", true);

        yield return new WaitForSeconds(jumpTime);

        isSlideLeft = false;
        animator.SetBool("IsJump", false);
    }
}
