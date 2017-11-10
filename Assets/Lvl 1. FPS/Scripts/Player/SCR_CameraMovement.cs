using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraMovement : MonoBehaviour {

    //Weapon
    Transform weaponTransform;

    //Camera
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -90F;
    public float maximumY = 90F;

    float rotationY = 0F;

    void Start ()
    {
        weaponTransform = transform.parent.Find("Weapon");
	}

	void Update ()
    {
        CameraMovement();
	}

    public void CameraMovement()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.parent.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            //Camera Y rotation
            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
            //Weapon Y Rotation
            weaponTransform.localEulerAngles = new Vector3(-rotationY, 0, 0);
            //Body X rotation
            transform.parent.localEulerAngles = new Vector3(0, rotationX, 0);
        }

        else if (axes == RotationAxes.MouseX)
        {
            transform.parent.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }

        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}
