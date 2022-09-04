using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour
{
    protected Animator animator;

    [SerializeField]
    bool ikActive = false;
    [SerializeField]
    Transform rightHandObj = null;
    [SerializeField]
    Transform leftHandObj = null;
    [SerializeField]
    Transform lookObj = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {
            
            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1f, .3f, 1f);
                    animator.SetLookAtPosition(lookObj.position);
                }


                // Set the right hand target position and rotation, if one has been assigned
                if (rightHandObj != null)
                {                   


                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
}
