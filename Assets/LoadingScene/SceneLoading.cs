using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour {

    // [Header("Loading scene")]
    // public int sceneID;
    // [Header("Other Object")]
    // public Image loadingImg;
    // public Text progressText;
    //
    //
    // void Start () {
    //     StartCoroutine(AsyncLoad());
    //}
    //
    // IEnumerator AsyncLoad()
    // {
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
    //     while (!operation.isDone)
    //     {
    //         float progress = operation.progress / 0.9f;
    //         loadingImg.fillAmount = progress;
    //         progressText.text = string.Format("{0:0}%", progress * 100);
    //         yield return null;
    //     }
    //  }

    public GameObject ButtonLoad;
     public GameObject SliderLoad;
     public Slider Slider;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        ButtonLoad.SetActive(false);
        SliderLoad.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Slider.value = progress;
            yield return null;
        }

    }

}
