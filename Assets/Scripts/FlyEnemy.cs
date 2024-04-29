using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public float walkSpeed = 3f;
    Rigidbody2D rb;
    Animator animator;

    TouchingDirections touchingDirections;

    [SerializeField]
    private bool _isStunned = false;
    public bool IsStunned {
        get {
            return _isStunned;
        }
        private set {
            _isStunned = value; 
            animator.SetBool(AnimationStrings.isStunned, value);
        }
    }

    public enum WalkableDirection {Right, Left};

    [SerializeField]
    private WalkableDirection _walkDirection;
    [SerializeField]
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection {
        get {return _walkDirection;}
        set {
            
            if(_walkDirection != value) {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkableDirection.Right) {
                    walkDirectionVector = Vector2.right;
                } else if (value == WalkableDirection.Left) {
                    walkDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        // if(!IsStunned) {
        //     if(touchingDirections.IsOnWall) {
        //         FlipDirection();
        //     }
        //     rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
        // }
        if(touchingDirections.IsOnWall) {
            FlipDirection();
        }
        rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
    }
    private void FlipDirection() {
        if(WalkDirection == WalkableDirection.Right) {
            WalkDirection = WalkableDirection.Left;
        } else if (WalkDirection == WalkableDirection.Left) {
            WalkDirection = WalkableDirection.Right;
        } else {
            Debug.LogError("aaa");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
