using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoading : MonoBehaviour
{
    [SerializeField] private FlagmentData flagmentDate;

    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _loadingUI;
    // Start is called before the first frame update
    void Start()
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadNextSceneAsync());
    }

    // Update is called once per frame
    IEnumerator LoadNextSceneAsync()
    {
        // �O�̃��[�h�V�[�����A�����[�h
        SceneManager.UnloadSceneAsync("LoadingScene");

        // ���̃V�[����񓯊��œǂݍ���
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(flagmentDate.SceneName);

        while (!asyncLoad.isDone)
        {
            _slider.value = asyncLoad.progress;
            yield return null;
        }
    }
}
