using UnityEngine;
using System.Collections;

public class ActionMove : ActionBase {
    public string tag = "";
    public bool isLoop = false;
    public float radius = 4.0f;
    GameObject[] trObjs;
    Vector3[] positions;
    NavMeshAgent navAgent;
    bool actionCond = false;
    bool arrived = false;
    int c = 0;
    

    void Start()
    {
        trObjs = GameObject.FindGameObjectsWithTag(tag);
        positions = new Vector3[trObjs.Length];
        foreach(GameObject obj in trObjs)
        {
            positions[int.Parse(obj.name)] = obj.transform.position;
        }
        navAgent = transform.root.GetComponent<NavMeshAgent>();
    }
	// Update is called once per frame
	void Update () {
        if (actionCond)
        {
            if (Vector3.Distance(transform.root.position, positions[c]) < navAgent.stoppingDistance+0.5)
            {
                Debug.Log("point " + c);
                c++;
            }
            if (c > trObjs.Length - 1)
            {
                if (isLoop)
                {
                    Debug.Log("new lap");
                    c = 0;
                } 
                else
                {
                    Debug.Log("arrived"+c);
                    arrived = true;
                    actionCond = false;
                }
                    
            }
                
            if(!arrived)   
                navAgent.SetDestination(positions[c]);
        }  
	}

    //void OnTriggerEnter(Collider other)
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
    //    foreach (Collider hitCOllider in hitColliders)
    //    {
    //        if (hitCOllider.tag == "Zombunny")
    //        {
    //            hitCOllider.SendMessage("CarCollided", SendMessageOptions.DontRequireReceiver);
    //        }
    //    }
    //}
    public override void action()
    {
        actionCond = true;
    }

}
