using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixNode : MonoBehaviour {

    public int posX;
    public int posY;

    public bool isOn;

	void Start ()
    {
        isOn = false;
	}

    private void Update()
    {
        isOn = GetComponent<ObjectClass>().b_isSelected;
    }
}
