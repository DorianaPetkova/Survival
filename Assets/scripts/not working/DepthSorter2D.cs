using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSorter2D : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;

    void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);

        // Check for collisions with the table
        Collider2D tableCollider = null; // Set this to the actual collider of your table
        bool isCollidingWithTable = Physics2D.IsTouchingLayers(GetComponent<Collider2D>(), 1 << LayerMask.NameToLayer("Table"));

        // Adjust sorting order based on the player's position relative to the table
        if (isCollidingWithTable)
        {
            GetComponent<SpriteRenderer>().sortingOrder = tableCollider.transform.position.y > transform.position.y ? 1 : -1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0; // Reset sorting order if not colliding
        }
    }
}
