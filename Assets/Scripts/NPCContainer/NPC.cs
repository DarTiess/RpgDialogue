using DG.Tweening;
using UnityEngine;

namespace NPCContainer
{
    [RequireComponent(typeof(NPCAnimator))]
    public class NPC : MonoBehaviour
    {
        private float _rotationSpeed;
        private NPCAnimator _npcAnimator;

        public void Init(float rotationSpeed)
        {
            _rotationSpeed = rotationSpeed;
            _npcAnimator = GetComponent<NPCAnimator>();
        }

        public void StartDialogue(Transform target)
        {
            var look = Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position);

            transform.DORotateQuaternion(look, _rotationSpeed)
                     .OnPlay(() =>
                     {
                         _npcAnimator.SayHello();
                     });
        }

        public void EndDialogue()
        {
            _npcAnimator.EndTalking();
        }
    }
}