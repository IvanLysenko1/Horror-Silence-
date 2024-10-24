using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadSceneOnClick(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
