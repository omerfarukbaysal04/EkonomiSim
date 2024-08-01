using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{ 
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
}

