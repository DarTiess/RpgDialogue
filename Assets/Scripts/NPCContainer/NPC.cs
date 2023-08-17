using System.Collections;
using DG.Tweening;
using DialogueSystem;
using UI;
using UnityEngine;

namespace NPCContainer
{
    [RequireComponent(typeof(NPCAnimator))]
    [RequireComponent(typeof(NPCAudio))]
    [RequireComponent(typeof(SphereCollider))]
    public class NPC : MonoBehaviour, IAnswer
    {
        private Dialog _dialog;
        private int _currentNode=0;
        private bool _showDialogue;
        private float _rotationSpeed;
        private NPCAnimator _npcAnimator;
        private NPCAudio _npcAudio;
        private IDialogueWindow _dialogueWindow;
        private IFinishDialogueEvent _dialogueEvent;
        private SphereCollider _triggerCollider;
        public void Init(NPCConfig config, IDialogueWindow dialogueWindow, IFinishDialogueEvent dialogueEvent)
        {
            _npcAnimator = GetComponent<NPCAnimator>();
            _npcAudio = GetComponent<NPCAudio>();
            _triggerCollider = GetComponent<SphereCollider>();
            _npcAudio.Init(config.AudioClips);
            _rotationSpeed = config.RotationSpeed;
            _dialog = Dialog.Load (config.TextAsset);

            _dialogueWindow = dialogueWindow;
            _dialogueEvent = dialogueEvent;
            _dialogueEvent.FinishDialogue += EndDialogue;
        }

        private void OnDisable()
        {
            _dialogueEvent.FinishDialogue -= EndDialogue;
        }

        public void StartDialogue(Transform target)
        {
            var look = Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position);
          
            transform.DORotateQuaternion(look, _rotationSpeed)
                     .OnPlay(() =>
                     {
                         _npcAnimator.IdleAnimation();
                         _showDialogue = true;
                         _triggerCollider.enabled = false;

                     }). OnComplete(()=>
                     {
                         _npcAnimator.SayHello();
                         DisplayNode();
                     });
          
        }

        public void MakeAnswer(int index)
        {
            if (_dialog.Nodes[_currentNode].Answers[index].End == "true")
            {
                _showDialogue = false;
                _dialogueWindow.EndDialogue();
            }
            _currentNode = _dialog.Nodes[_currentNode].Answers[index].NextNode;
            DisplayNode();
        }

        private void EndDialogue()
        {
            _npcAnimator.EndTalking();
            StartCoroutine(EnableTriggerArea());
        }

        private IEnumerator EnableTriggerArea()
        {
            yield return new WaitForSeconds(3f);
            _triggerCollider.enabled = true;
        }

        private void DisplayNode()
        {
            if (_showDialogue)
            {
                _dialogueWindow.StartDialogue(_dialog.Nodes[_currentNode].NpcText,_dialog.Nodes [_currentNode].Answers, this );
                _npcAudio.PlayAudio(_currentNode);
            }
        }
    }
}