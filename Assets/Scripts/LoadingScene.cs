using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    [SerializeField]
    private Image loadingImage;
	
	void Start ()
    {
        StartCoroutine(LoadLevel());
	}
	
    private IEnumerator LoadLevel()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("main");

        ao.allowSceneActivation = false;

        while(ao.progress < .9f)
        {

            loadingImage.fillAmount = (float)ao.progress + .1f;


            yield return new WaitForEndOfFrame();
        }

        Debug.Log("scene loaded");

        SceneManager.LoadScene("main");
    }

}
