using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private int currentSceneNum;
    private int nextSceneNum;


    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        nextSceneNum = currentSceneNum + 1;

        _boxCollider2D = GetComponent<BoxCollider2D>();

        if (nextSceneNum == SceneManager.sceneCountInBuildSettings)
            nextSceneNum = 0;
    }

    private void Update()
    {
        if (_boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
            StartCoroutine(WaitAndExit());
    }

    private IEnumerator WaitAndExit()
    {
        yield return new WaitForSeconds (1);
        SceneManager.LoadScene(nextSceneNum);
    }
}
