///Script by Luis Bazan
///Git User: luisquid11

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_GoToMenu : MonoBehaviour {

	public void OnQuitClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void OnPlayerDead()
    {
        StartCoroutine(GoBack());
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(3f);
        OnQuitClicked();
    }
}
