using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatingPlatform : MonoBehaviour
{
    [Header("Basic Platform Needs")]
    public bool isActive;
    public PlayerBehaviour player;


    [Header("Floating Platform Needs")]
    public Vector3 currentPos;
    public Vector2 OriginalSize;
    public Vector2 CurrentSize;
    public float ShrinkRate;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        currentPos = transform.position;
        OriginalSize = transform.localScale;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSize = transform.localScale;

        // Check if player is currently on the platform, if so shrink
        if (isActive)
        {
            if(CurrentSize.x > 0)
            {
                transform.localScale -= transform.localScale * (Time.deltaTime * ShrinkRate);
            }
        }
        else // If not Return the platform gradually to its position
        {
            if(CurrentSize.x < 1.0)
            {
                transform.localScale += transform.localScale * (Time.deltaTime * ShrinkRate);
            }
        }


        _move();
    }

    // Continuously Float the Crystal at its current position Pingponging
    private void _move()
    {
        transform.position = new Vector3(transform.position.x,
            currentPos.y + Mathf.PingPong(Time.time, 1), 0.0f);
    
    }
}
