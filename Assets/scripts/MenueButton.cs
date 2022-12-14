using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueButton : MonoBehaviour
{
    //This is Button Controlling Script

    GameObject Data;


    // Start is called before the first frame update
    void Start()
    {
        Data = GameObject.Find("Data");
        
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
// For Level 1........
    public void Easy()
    {
        SceneManager.LoadScene(1);   
        Data.GetComponent<Data>().medium = false;
        Data.GetComponent<Data>().hard = false;     
    }

    public void medium()
    {
        Data.GetComponent<Data>().medium = true;
        Data.GetComponent<Data>().hard = false;
        SceneManager.LoadScene(1);
    }

    public void Hard()
    {
        Data.GetComponent<Data>().medium = false;
        Data.GetComponent<Data>().hard = true;
        SceneManager.LoadScene(1);
    }

// For Level 2
    public void Easy2()
    {
        SceneManager.LoadScene(4);   
        Data.GetComponent<Data>().medium = false;
        Data.GetComponent<Data>().hard = false;     
    }

    public void medium2()
    {
        Data.GetComponent<Data>().medium = true;
        Data.GetComponent<Data>().hard = false;
        SceneManager.LoadScene(4);
    }

    public void Hard2()
    {
        Data.GetComponent<Data>().medium = false;
        Data.GetComponent<Data>().hard = true;
        SceneManager.LoadScene(4);
    }
//................


    public void Replay()
    {
            Time.timeScale = 1f;
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    public void Menu()
    {
        Destroy(Data);
            Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
