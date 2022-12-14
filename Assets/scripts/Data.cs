using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // This script carry the information of difficulty of levels

    public bool medium;
    public bool hard;

    // Start is called before the first frame update
    void Start()
    {
        //This Script will not destroy when new scene will load
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
