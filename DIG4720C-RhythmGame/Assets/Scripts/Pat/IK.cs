using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour {

    // Use this for initialization
    #region Data   
    [SerializeField]
    Transform P1LeftFoot;
    [SerializeField]
    Transform P1RightFoot;
    [SerializeField]
    Transform P2LeftFoot;
    [SerializeField]
    Transform P2RightFoot;
    [SerializeField]
    Transform Floor;
    #endregion

    Animator anim;

    private void Awake()
    {
  //      anim = GetComponent<Animator>;
    }
    private void OnAnimatorIK()
    {
        //set base pos
        anim.SetIKPosition(AvatarIKGoal.LeftFoot,Vector3.zero);
        //set str of pull
        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
    }
    private void LateUpdate()
    {
        
    }
}
