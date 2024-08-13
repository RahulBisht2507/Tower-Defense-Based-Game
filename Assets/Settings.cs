using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] public GameObject setting;
    [SerializeField] private GameObject backbutton;
   public void Setting()
    {
        Time.timeScale = 0;
        backbutton.SetActive(true);
        setting.SetActive(false);
    }

    public void back()
    {
        setting.SetActive(true);
        backbutton.SetActive(false);
        Time .timeScale = 1;
    }
}
