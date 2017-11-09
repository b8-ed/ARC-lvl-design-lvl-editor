using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FPSPlayerController : MonoBehaviour {

    public float playerVelocity;

    private Rigidbody playerRB;

    private bool isCursorLocked = false;

    void Start ()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float m_MovX = Input.GetAxis("Horizontal");
        float m_MovY = Input.GetAxis("Vertical");

        Vector3 m_moveHorizontal = transform.right * m_MovX;
        Vector3 m_movVertical = transform.forward * m_MovY;

        Vector3 m_velocity = (m_moveHorizontal + m_movVertical).normalized * playerVelocity;

        if (m_velocity != Vector3.zero)
        {
            playerRB.MovePosition(playerRB.position + m_velocity * Time.fixedDeltaTime);
        }
        InternalLockUpdate();

    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isCursorLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isCursorLocked = true;
        }

        if (isCursorLocked)
        {
            UnlockCursor();
        }
        else if (!isCursorLocked)
        {
            LockCursor();
        }
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
