using UnityEngine;

namespace NPCContainer
{
    [RequireComponent(typeof(Animator))]
    public class NPCAnimator : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int SAY_HELLO = Animator.StringToHash("SayHello");

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
        }
    }
}