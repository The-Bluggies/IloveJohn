using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody2D rb;

    public float speed;

    private Vector2 movementDirection;

    private int shooting;

    public GameObject Bullet;


    // Start is called before the first frame update
    void Start()
    {
        speed = 12f;
        rb = GetComponent<Rigidbody2D>();
        shooting = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection();
        Shooting();
    }

    private void FixedUpdate()
    {
        // This determines player movement by considering direction and speed
        // KEEP THIS HERE BECAUSE Rigidbody2D will get scuffed in normal Update
        rb.velocity = movementDirection * speed;


    }

    void PlayerDirection()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (shooting)
            {
                //FOR ALL SHOOTING CASES, we use Vector3 instead of Vector2 to modify direction because the code just doesn't like it for some reason.
                case 1:
                    //Normal Shot
                        Instantiate(Bullet, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                    break;

            }

        }
    }


}
