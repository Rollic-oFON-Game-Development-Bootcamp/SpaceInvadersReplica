using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform XleftLimitPosition;
    [SerializeField] Transform XRightLimitPosition;
    [SerializeField] float sideMovementSpeed;

    private float xLeftLimitValue;
    private float xRightLimitValue;
    public Joystick joystick;



    void Start()
    {
        xLeftLimitValue = XleftLimitPosition.position.x;
        xRightLimitValue = XRightLimitPosition.position.x;
    }
    void Update()
    {
        PlayerInputHander();
        PlayerMovementHandler();
        ClampPlayerPosition();
        PlayerWrapping();
    }

    void PlayerInputHander()
    {
        horizontal = joystick.Horizontal;
    }

    void PlayerMovementHandler()
    {
        rb.MovePosition(rb.position + new Vector2(horizontal * sideMovementSpeed * Time.deltaTime, 0f));
    }

    void ClampPlayerPosition()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, xLeftLimitValue, xRightLimitValue);
        transform.position = pos;
    }

    void PlayerWrapping()
    {
        if (transform.position.x > xRightLimitValue - 0.1f)
        {
            transform.position = new Vector2(xLeftLimitValue + 0.25f, transform.position.y);
        }

        if (transform.position.x < xLeftLimitValue + 0.1f)
        {
            transform.position = new Vector2(xRightLimitValue - 0.25f, transform.position.y);
        }
    }
}
