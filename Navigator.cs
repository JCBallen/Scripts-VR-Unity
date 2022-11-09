using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    public void NavigateTo(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
