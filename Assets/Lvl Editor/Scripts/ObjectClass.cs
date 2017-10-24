using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClass : MonoBehaviour {

    public bool b_isSelected;

	void Start () {
        b_isSelected = false;
	}
	
	void Update () {
		
	}

    public static void ToggleObject(ObjectClass _obj)
    {
        _obj.b_isSelected = !_obj.b_isSelected;
        if(_obj.b_isSelected)
            _obj.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        else
            _obj.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public static void DeselectObject(ObjectClass _obj)
    {
        _obj.b_isSelected = false;
        Debug.Log(_obj.gameObject.name + " deselected");
    }

    public static void SelectObject(ObjectClass _obj)
    {
        _obj.b_isSelected = true;
        _obj.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log(_obj.gameObject.name + " selected");
    }
}
