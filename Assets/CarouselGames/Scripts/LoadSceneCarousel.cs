using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCarousel : MonoBehaviour
{ 
    public void LoadCarousel()
    {
        SceneManager.LoadScene("CarouselScene");
    }
}
