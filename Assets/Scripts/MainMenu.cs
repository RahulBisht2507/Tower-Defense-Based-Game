using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private Slider loadingSlider;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject exit;
    public void StartGame()
    {
        // Load the main game scene
        play.SetActive(false);
        exit.SetActive(false);
        loadingSlider.gameObject.SetActive(true);
        StartCoroutine(LoadMainGameScene());
    }

    IEnumerator LoadMainGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            // Update the loading progress
            loadingSlider.value = asyncLoad.progress;

            // Check if the loading is complete
            if (asyncLoad.progress >= 0.9f)
            {
                loadingSlider.value = 1f;
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void ExitGame()
    {
        // Quit the application (works in standalone builds)
        Application.Quit();
    }
}
