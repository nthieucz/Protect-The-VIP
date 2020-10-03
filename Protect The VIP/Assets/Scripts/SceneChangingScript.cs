using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangingScript : MonoBehaviour
{

    public GameObject nextLevelPanel;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            restart();
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        nextLevelPanel.SetActive(false);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        nextLevelPanel.SetActive(false);
    }

    public void setLevel(int level)
    {
        SceneManager.LoadScene(level);
        if (level == 0)
        {
            Destroy(GameObject.Find("SceneManagingCanvas"));
        }
        nextLevelPanel.SetActive(false);
    }

    public void openPanel()
    {
        nextLevelPanel.SetActive(true);
    }
}
