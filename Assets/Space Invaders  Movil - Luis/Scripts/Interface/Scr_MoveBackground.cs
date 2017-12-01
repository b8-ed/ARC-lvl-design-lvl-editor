///Script by Luis Bazan
///Git User: luisquid11

using UnityEngine;

public class Scr_MoveBackground : MonoBehaviour {

    public int materialIndex = 0;
    public Vector2 uvAnimationRotate = new Vector2(0.0f, 1.0f);
    public string textureName = "_MainTex";
    public float velocity;

    private float initVelocity;
    Vector2 uvOffset = Vector2.zero;

    private void Start()
    {
        initVelocity = velocity;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.P))
            velocity = velocity + Time.deltaTime;
        else
        {
            if (velocity <= initVelocity)
                velocity = initVelocity;
            else
                velocity = velocity -Time.deltaTime;
        }
    }
    void LateUpdate()
    {
        uvOffset += (uvAnimationRotate * Time.deltaTime * velocity);
        if (GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
