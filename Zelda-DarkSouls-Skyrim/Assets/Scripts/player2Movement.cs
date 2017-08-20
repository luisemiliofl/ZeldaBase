using UnityEngine;
using System.Collections;

public class player2Movement : MonoBehaviour {

    public float speed = 2.5f;
    //private Vector2 direction = Vector2.zero;
    private Animator animator;
    //AnimatorStateInfo currentAnim;
    public bool canMove = true;

    //private static int walkLeft = Animator.StringToHash("Base Layer.Player2MovementLeft");
    //private static int walkRight = Animator.StringToHash("Base Layer.Player2MovementRight");
    //private static int walkUp = Animator.StringToHash("Base Layer.Player2MovementUp");
    //private static int walkDown = Animator.StringToHash("Base Layer.Player2MovementDown");
    //private static int idleLeft = Animator.StringToHash("Base Layer.Player2MovementIdleLeft");
    //private static int idleRight = Animator.StringToHash("Base Layer.Player2MovementIdleRight");
    //private static int idleUp = Animator.StringToHash("Base Layer.Player2MovementIdleUp");
    //private static int idleDown = Animator.StringToHash("Base Layer.Player2MovementIdle");
    //private static int idle = Animator.StringToHash("Base Layer.Player2MovementIdle");


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //TODO1: ATTACK
                animator.SetBool("Attacking", true);
            }
            else
            {
                Vector3 direction = new Vector3(
                    Input.GetAxisRaw("Horizontal"),
                    Input.GetAxisRaw("Vertical"),
                    0);
                direction.Normalize();

                if (direction != Vector3.zero)
                {
                    GetComponent<Rigidbody2D>().velocity = direction * speed;
                    animator.SetFloat("MovX", direction.x);
                    animator.SetFloat("MovY", direction.y);
                    animator.SetBool("Walking", true);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = direction * 0;
                    animator.SetBool("Walking", false);
                }
            }          
        }
    }
}
