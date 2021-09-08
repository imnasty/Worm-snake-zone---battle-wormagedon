using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    [Header("Введите номер главной сцены")]
    [SerializeField] private int sceneID = 1;

    public void LoadMScene()
    {
        SceneManager.LoadSceneAsync(sceneID);
    }
}
