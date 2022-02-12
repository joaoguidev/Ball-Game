using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{

    private Camera mainCamera;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BounceOnScreenEdge();
    }

    void BounceOnScreenEdge()
    {
        Vector3 newPos = transform.position;
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        if( viewportPos.x <= 0)
        {
/*            newPos.x -= 0.1f;
            transform.position = newPos;*/
            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity, Vector3.right);
            //Destroy(this.gameObject);
        }
        if(viewportPos.x >= 1)
        {
/*            newPos.x += 0.1f;
            transform.position = newPos;*/
            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity, Vector3.left);
        }

        if (viewportPos.y > 1)
        {
            //Destroy(this.gameObject);
            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity, Vector3.down);
        }
        if (viewportPos.y < 0)
        {
            Destroy(this.gameObject);
            //rigidBody.velocity = Vector3.Reflect(rigidBody.velocity, Vector3.up);
        }

    }
}
