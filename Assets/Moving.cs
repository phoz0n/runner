using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Touch touch;
    private float Speedmodifier;
    // Start is called before the first frame update
    void Start()
    {
        Speedmodifier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x + touch.deltaPosition.x * Speedmodifier, -2, 2),
                    transform.position.y,
                    transform.position.z);
            }
        }
    }
}