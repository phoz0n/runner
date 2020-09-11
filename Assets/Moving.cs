using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Vector3 position;
    private float width;
    // Start is called before the first frame update
    void Awake()
    {
        width = (float)Screen.width / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                float positionLocked = Mathf.Clamp(pos.x, -2.0f, 2.0f);
                position = new Vector3(positionLocked, 0.0f, 0.0f);

                // Position the cube.
                transform.position = position;
            }
        }
    }
}
