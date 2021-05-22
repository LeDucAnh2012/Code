using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    //public static MainMenuController instance;

    //void _MakeInstance()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //    }
    //}
    //void Awake()
    //{
    //    _MakeInstance();
    //}
    public void _PlayButton()
    {
        Application.LoadLevel("GamePlay");
        SceneManager.LoadScene("GamePlay");
    }
}
