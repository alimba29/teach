using UnityEngine;
using System.Collections;

public class ActionAnimate : ActionBase {

    public string animationName;
    
    Animator anim;
    
    void Start()
    {
        anim = transform.root.GetComponent<Animator>();
    }
    public override void action()
    {
        anim.SetTrigger(animationName);
    }
	
}
