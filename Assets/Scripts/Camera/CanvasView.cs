using UnityEngine;
using System.Collections;

public class CanvasView : MonoBehaviour {
    RectTransform tr;
	// Use this for initialization
	void Start () {
        tr = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        tr.rotation = Camera.main.transform.rotation;
        
	}
}
