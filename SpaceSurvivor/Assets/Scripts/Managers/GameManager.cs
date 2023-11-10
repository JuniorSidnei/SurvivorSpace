using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    private void Awake() {
        SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
    }
}
