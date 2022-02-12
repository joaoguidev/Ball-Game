using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    private GameObject gameManager;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D ballRB;
    [SerializeField] private float detachDelay;
    [SerializeField] private float respawnDelay;
    private SpringJoint2D ballSpringJoint;
    private Camera mainCamera;
    private bool isDragging;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        detachDelay = 0.15f;
        mainCamera = Camera.main;
        ballSpringJoint = ballRB.GetComponent<SpringJoint2D>();
        SpawnBall();

    }

    // Update is called once per frame
    void Update()
    {
        if (ballRB == null) { return; }

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isDragging)
            {
                LaunchBall();
            }

            isDragging = false;
            return;
        } else
        {
            ballRB.isKinematic = true;
            isDragging = true;
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPos);

            ballRB.position = worldPos;
        }
    }

    private void LaunchBall()
    {
        // Destroy(ballRB.GetComponent<SpringJoint2D>());
        ballRB.isKinematic = false;
        Invoke(nameof(DetachBall), detachDelay);

    }

    private void DetachBall()
    {
        //ballRB = null;
        ballSpringJoint.enabled = false;
        Invoke(nameof(SpawnBall), respawnDelay);
    }

    public void SpawnBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
        ballRB = ballInstance.GetComponent<Rigidbody2D>();
        ballSpringJoint = ballInstance.GetComponent<SpringJoint2D>();
        ballSpringJoint.connectedBody = pivot;

    }



}
