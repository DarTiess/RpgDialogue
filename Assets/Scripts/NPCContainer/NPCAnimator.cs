using UnityEngine;

namespace NPCContainer
{
    [RequireComponent(typeof(Animator))]
    public class NPCAnimator : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int SAY_HELLO = Animator.StringToHash("SayHello");
        private static readonly int IDLE = Animator.StringToHash("Idle");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SayHello()
        {
            _animator.SetBool(SAY_HELLO, true);
        }

        public void EndTalking()
        {
            _animator.SetBool(SAY_HELLO, false);
            _animator.SetBool(IDLE, false);
        }

        public void IdleAnimation()
        {
            _animator.SetBool(IDLE, true);
        }
    }
}