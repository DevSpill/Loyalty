THIS IS FOR PLAYER (ADD TO PLAYER) 

--------------------------------------------------------

public float normalSpeed = 5f;
public float waterSlowMultiplier = 0.77f; // 1 / 1.3
private bool isInWater = false;
private Rigidbody2D rb;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
}

void Update()
{
    float moveX = Input.GetAxis("Horizontal");
    float speed = isInWater ? normalSpeed * waterSlowMultiplier : normalSpeed;
    rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
}

public void EnterWater()
{
    isInWater = true;
    rb.gravityScale = 0.3f;  // simulate buoyancy
    rb.drag = 2f;            // more resistance
}

public void ExitWater()
{
    isInWater = false;
    rb.gravityScale = 3f;  // reset gravity
    rb.drag = 0f;
}

----------------------------------------------------

THIS IS FOR THE WATER (TRIGGER ZONE)

using UnityEngine;

public class WaterZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.EnterWater();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.ExitWater();
            }
        }
    }
}

-------------------------------------------------
BY MATCHA 
