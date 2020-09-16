using UnityEngine;

public class Moving : MonoBehaviour
{
    private Touch touch;
    private float Speedmodifier = 0.01f;
    private float currentTilting = 0f;

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float amountTilting = Mathf.Clamp(currentTilting + touch.deltaPosition.x, 5f, -5f);

                currentTilting = Mathf.Lerp(currentTilting, amountTilting, 0.1f);

                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x + touch.deltaPosition.x * Speedmodifier, -2f, 2f),
                    transform.position.y,
                    transform.position.z);
            }
        }
        //currentTilting *= 0.98f * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, 0f, currentTilting);
    }
}