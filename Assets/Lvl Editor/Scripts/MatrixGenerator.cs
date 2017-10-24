using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGenerator : MonoBehaviour {

    public List<GameObject> Matrix;
    public GameObject GO_NodePrefab;
    public int width;
    public int height;

    GameObject Cam_mainCamera;

	void Start ()
    {
        Cam_mainCamera = Camera.main.gameObject;
        StartCoroutine(CreateMatrix());
	}
	
    IEnumerator CreateMatrix()
    {
        yield return new WaitForEndOfFrame();

        GameObject center = null;
        GameObject temp   = null;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == width/2 && j == height/2)
                {
                    center = Instantiate(GO_NodePrefab, new Vector3(i * 2, j * 2, 0), Quaternion.identity, gameObject.transform);
                    temp = center;                   
                }
                else
                {
                    temp = Instantiate(GO_NodePrefab, new Vector3(i * 2, j * 2, 0), Quaternion.identity, gameObject.transform);
                }

                temp.GetComponent<MatrixNode>().posX = i;
                temp.GetComponent<MatrixNode>().posY = j;
                Matrix.Add(temp);
            }
        }

        Cam_mainCamera.transform.position = new Vector3(center.transform.position.x, center.transform.position.y, Cam_mainCamera.transform.position.z);
        Cam_mainCamera.transform.LookAt(center.transform);
    }
}
