using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    private float maxHeight;
    private float maxWidth;
    private Renderer rendr;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        rendr = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        var rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        var targetPosition = new Vector2(rawPosition.x, rawPosition.y);

        var upperCorner = new Vector2(Screen.width, Screen.height);
        var rawUC = cam.ScreenToWorldPoint(upperCorner);
        maxHeight = rawUC.y - rendr.bounds.extents.y;
        maxWidth = rawUC.x - rendr.bounds.extents.x;

        float targetHeight = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector2(targetWidth, targetHeight);

        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }
}
