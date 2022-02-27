using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private SOIntData _carma;
    [SerializeField] private int _carmaLimitGood;
    [SerializeField] private string _goodFinal;
    [SerializeField] private string _badFinal;
    private bool isLoad;

    public void OnLoadLevel()
    {
        if (isLoad) return;
        if (_carma.Value < _carmaLimitGood)
        {
            StartCoroutine(LoadYourAsyncScene(_badFinal));
        }
        else
        {
            StartCoroutine(LoadYourAsyncScene(_goodFinal));
        }

        isLoad = true;
    }

    IEnumerator LoadYourAsyncScene(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}