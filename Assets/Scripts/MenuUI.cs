using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance;
    public string Fighter;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCorsair()
    {
        MenuUI.Instance.Fighter = "corsair";
        SceneManager.LoadScene(1);
    }

    public void PlayReaper()
    {
        MenuUI.Instance.Fighter = "reaper";
        SceneManager.LoadScene(1);
    }
 
    public void PlayThug()
    {
        MenuUI.Instance.Fighter = "thug";
        SceneManager.LoadScene(1);
    }
}
