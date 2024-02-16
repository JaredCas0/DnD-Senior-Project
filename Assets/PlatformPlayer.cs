using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformPlayer : MonoBehaviour
{
    // public references to sprite frames
    public Sprite STANDING;
    public Sprite JUMPING;

    // movement constants (can make public to tune, just make sure to put the values back in the script)
    private float MAX_SPEED = 6.0f;

    private Vector2 SCREEN_MAX;
    private Vector2 SCREEN_MIN;
    private Vector2 SELF_EXTENTS;

    // velocity persists frame-to-frame, so store as a class variable
    private Vector2 _velocity = Vector2.zero;

    void Start()
    {
        // screen coordinates 0,0 -> 1,1 converted into world coordinates
        SCREEN_MAX = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        SCREEN_MIN = Camera.main.ViewportToWorldPoint(Vector2.zero);

        // extents is the half width/height of the sprite in world units
        // (note taking the bounds of the collider rather than the sprite, to avoid inconsistencies with the collision triggers)
        SELF_EXTENTS = GetComponent<BoxCollider2D>().bounds.extents;
    }

    // FixedUpdate is called on a fixed time interval, which is better for physics simulation than the variable frame rate
    void FixedUpdate()
    {
        // perform ground check w/ raycast
        int plaformLayerMask = 1 << 6;
        bool grounded = Physics2D.Raycast(transform.position, Vector2.down, SELF_EXTENTS.y + 0.1f, plaformLayerMask);

        // user input
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

        //movement behavior when on the ground
        if(grounded)
        {

            //use the standing sprite
            transform.GetComponent<SpriteRenderer>().sprite = STANDING;

            // set facing based on movement direction (flip x-axis scale positive or negative)
            if (dir.x > 0) transform.localScale = (Vector3)new Vector2(1.0f, 1.0f);
            else if (dir.x < 0) transform.localScale = (Vector3)new Vector2(-1.0f, 1.0f);

            // in case we landed on this frame, zero out vertical velocity
            _velocity.y = 0;

            // set acceleration to alter velocity based on user input
                // if we have user input left or right, set constant acceleration in that direction
            Vector2 acceleration = dir * 20.0f;

            // otherwise (no user input)
                // if velocity is really small already, just set to zero to avoid jitter
            if(dir.magnitude < 0.1f || Mathf.Sign(dir.x) != Mathf.Sign(_velocity.x))
            {
                _velocity.x = 0; 
            }


            // integrate acceleration to update velocity
            _velocity += acceleration * Time.deltaTime;

            // make sure it doesn't go over MAX_SPEED (can use Vector2.ClampMagnitude)
            _velocity.x = Mathf.Clamp(_velocity.x, -MAX_SPEED, MAX_SPEED);

            //jump using impulse (add instantaneous velocity up)
            if(Input.GetKey(KeyCode.Space))
            {
                // add a vertical component to current velocity (Vector2.up * a JUMP_SPEED constant)
                _velocity += Vector2.up * 8.0f;
            }

        }
        // movement behavior when airborn
        else
        {
            // use the jumping sprite
            transform.GetComponent<SpriteRenderer>().sprite = JUMPING;

            // acceleration due to gravity only
            _velocity += Physics2D.gravity * Time.deltaTime;

            // integrate acceleration to update velocity
            _velocity += dir * MAX_SPEED * Time.deltaTime;
        }

        // and integrate velocity to update position
        transform.position = (Vector2)transform.position + (_velocity * Time.deltaTime);
     }

     private void OnTriggerStay2D(Collider2D platform)
     {
        //uses trigger stay as opposed to trigger enter/exit

        // get the bounds of the platform
        Vector2 extents = platform.GetComponent<BoxCollider2D>().bounds.extents;

        // store the difference in position, we'll need the signs later
        Vector2 dist = platform.transform.position - transform.position;

        // get the absolute overlap distances (overlaps indicated by negative values)
        Vector2 overlap = new Vector2(Mathf.Abs(dist.x), Mathf.Abs(dist.y)) - (extents + SELF_EXTENTS);

        // only need to act if both x and y overlap (separating axis theorem)
        if (overlap.x < 0 && overlap.y < 0) {
            // as an approximation, push out along the axis with the smaller overlap distance (bigger negative)
            if (overlap.y > overlap.x) {
                // less overlap in y, push vertical (use saved sign to know which direction to push)
                transform.position = transform.position + new Vector3(0f, (overlap.y) * Mathf.Sign(dist.y), 0f);
                // kill vertical velocity
                _velocity = new Vector2(_velocity.x, 0f);
            } else {
                // less overlap in x, push horizontal
                transform.position = transform.position + new Vector3((overlap.x) * Mathf.Sign(dist.x), 0f, 0f);
                // kill horizontal velocity
                _velocity = new Vector2(0f, _velocity.y);
            }
        }
     }
}
