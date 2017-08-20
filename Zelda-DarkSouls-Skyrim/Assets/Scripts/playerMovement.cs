using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float speed = 2.5f;
    private Vector2 direction = Vector2.zero;
    private Animator animator;
    AnimatorStateInfo currentAnim;
    public bool canMove = true;

    private static int walkLeft = Animator.StringToHash("Base Layer.PlayerMovementLeft");
    private static int walkRight = Animator.StringToHash("Base Layer.PlayerMovementRight");
    private static int walkUp = Animator.StringToHash("Base Layer.PlayerMovementUp");
    private static int walkDown = Animator.StringToHash("Base Layer.PlayerMovementDown");
    private static int idleLeft = Animator.StringToHash("Base Layer.PlayerMovementIdleLeft");
    private static int idleRight = Animator.StringToHash("Base Layer.PlayerMovementIdleRight");
    private static int idleUp = Animator.StringToHash("Base Layer.PlayerMovementIdleUp");
    private static int idleDown = Animator.StringToHash("Base Layer.PlayerMovementIdle");
    private static int idle = Animator.StringToHash("Base Layer.PlayerMovementIdle");


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (canMove)
        {
            currentAnim = animator.GetCurrentAnimatorStateInfo(0);
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
            direction.Normalize();

            if (direction.y == 1)
            {
                animator.Play(walkUp);
            }
            else if (direction.y == -1)
            {
                animator.Play(walkDown);
            }
            else if (direction.x == 1)
            {
                animator.Play(walkRight);
            }
            else if (direction.x == -1)
            {
                animator.Play(walkLeft);
            }
            else if (direction.x == 0 && direction.y == 0)
            {
                if (currentAnim.fullPathHash == walkLeft)
                {
                    animator.Play(idleLeft);
                }
                else if (currentAnim.fullPathHash == walkRight)
                {
                    animator.Play(idleRight);
                }
                else if (currentAnim.fullPathHash == walkDown)
                {
                    animator.Play(idleDown);
                }
                else if (currentAnim.fullPathHash == walkUp)
                {
                    animator.Play(idleUp);
                }
            }

            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}
