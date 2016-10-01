using UnityEngine;
using System.Collections;

public class CondTrigger : ConditionBase {
    public GameObject target;
    public bool isArrived = false;

    public override bool checkCondition()
    {
        
        return isArrived;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            if (isArrived == false) isArrived = true;
            else isArrived = false;
            //GetComponent<NavMeshAgent>().enabled = false;
            Debug.Log("arrrrrrived");
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            if (isArrived == true) isArrived = false;
            else isArrived = true;
        }
    }

    void CarCollided()
    {
        isArrived = true;
    }
}
