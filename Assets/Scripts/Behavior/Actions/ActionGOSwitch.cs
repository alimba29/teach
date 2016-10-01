using UnityEngine;
using System.Collections;

public class ActionGOSwitch : ActionBase {
    public GameObject go;
    
	// Use this for initialization
	
    public override void  action(){
        go.SetActive(!go.activeSelf);
    }
}
