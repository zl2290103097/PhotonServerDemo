using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour {

    public GameObject cube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BiggerButtonAction()
    {
       // Debug.Log("变大按钮");
        //cube.transform.localScale = new Vector3(3, 3, 3);
    }

    public void SmallerButtonAction()
    {
        Debug.Log("变小按钮");
        cube.transform.localScale = new Vector3(1, 1, 1);
    }

}
