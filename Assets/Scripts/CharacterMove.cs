using System.Linq;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float jumpSpeed;

    private bool _grounded;
    private bool _queueJump;

    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Check if we can queue a jump here. Input.[Anything]Down will only be correct in the Update() method, that is
        // why we are requied to do this check here and use the queueJump variable in FixedUpdate.
        if (_grounded && Input.GetButtonDown("Jump"))
        {
            _queueJump = true;
        }
       
    }

    // FixedUpdate is called once per frame for Physics updates
    void FixedUpdate()
    {
        // check ground
        _grounded = Physics.RaycastAll(transform.position, -transform.up, transform.localScale.y + 0.1f).Where(x => !x.transform.GetComponent<Collider>().isTrigger).Any();

        // input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!Input.GetButton("Fire1"))
        {
            // movement
            transform.Rotate(Vector3.up * horizontal * rotateSpeed * Time.fixedDeltaTime);

            MoveCharacter(transform.TransformDirection(0, 0, vertical) * moveSpeed);
        }
        else if (_grounded)
        {
            MoveCharacter(Vector3.zero);

            // TODO drill
            
        }

        // jump
        if (_grounded && _queueJump)
        {
            _queueJump = false;
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        // TODO duck
        
    }

    // Move moves the character depending on a change in the input vector compared to the velocity last physics frame
    private void MoveCharacter(Vector3 change)
    {
        change -= _rigidbody.velocity;
        change.y = 0;
        _rigidbody.AddForce(change, ForceMode.VelocityChange);
    }
}
