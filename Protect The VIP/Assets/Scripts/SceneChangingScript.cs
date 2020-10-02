using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangingScript : MonoBehaviour
{
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
    }

    public void setLevel(int level)
    {
        SceneManager.LoadScene(level);
        if (level == 0)
        {
            Destroy(GameObject.Find("SceneManagingCanvas"));
        }
    }
}
