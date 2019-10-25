using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.uiController.ChangeFade();

        SceneManager.LoadSceneAsync(1);
    }

}
