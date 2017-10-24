using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour {

    public static List<GameObject> disappearedEnemies;

    private void Start()
    {
        disappearedEnemies = new List<GameObject>();
    }

    public void Disappear(GameObject disappearingEnemies)
    {
        StartCoroutine(TurnGameObjectOff(disappearingEnemies));
    }

    public int DissappearAll()
    {
        for(int i = 0; i < disappearedEnemies.Count; i++)
        {
            Disappear(disappearedEnemies[i]);
        }

        return 0;
    }

    public int ReAppear(GameObject respawnedObject)
    {
        respawnedObject.SetActive(true);
        return 0;
    }


    IEnumerator TurnGameObjectOff(GameObject disappearGameObject)
    {
        yield return new WaitForSeconds(5f);
        disappearGameObject.SetActive(false);
    }
}
