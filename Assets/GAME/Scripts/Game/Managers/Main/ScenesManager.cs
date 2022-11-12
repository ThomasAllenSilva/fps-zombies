using System;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(Instance.gameObject);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        if (sceneIndex <= SceneManager.sceneCount && sceneIndex >= 0) SceneManager.LoadScene(sceneIndex);

        else throw new Exception("Does Not Exist Scene In The Index: " + sceneIndex);
    }
}
