using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour, IMoveAnimation
{
    private Animator _animator;
    private static readonly int IS_MOVE = Animator.StringToHash("IsMove");
   
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(float speed)
    {
       // _animator.SetFloat(IS_MOVE, speed);
    }

}
