using UnityEngine;

public class JumpCube : MonoBehaviour
{
    public Animator animator;
    
    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
}
