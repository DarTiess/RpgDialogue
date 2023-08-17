using System;
using DG.Tweening;
using UnityEngine;

namespace NPCContainer
{
    [RequireComponent(typeof(NPCAnimator))]
    [RequireComponent(typeof(NPCAudio))]
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


        public void Init(NPCConfig config, IDialogueWindow dialogueWindow, IFinishDialogueEvent dialogueEvent)
        {
            _npcAnimator = GetComponent<NPCAnimator>();
            _npcAudio = GetComponent<NPCAudio>();
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
                        
                     }). OnComplete(()=>
                     {
                         _npcAnimator.SayHello();
                         DisplayNode();
                     });
          
        }

        private void EndDialogue()
        {
            _npcAnimator.EndTalking();
        }
        
        private void DisplayNode()
        {
            if (_showDialogue)
            {
                _dialogueWindow.StartDialogue(_dialog.nodes[_currentNode].NpcText,_dialog.nodes [_currentNode].answers, this );
                _npcAudio.PlayAudio(_currentNode);
            }
        }

        public void MakeAnswer(int index)
        {
            Debug.Log(index);
            if (_dialog.nodes[_currentNode].answers[index].end == "true")
            {
                _showDialogue = false;
                _dialogueWindow.EndDialogue();
            }
            _currentNode = _dialog.nodes[_currentNode].answers[index].nextNode;
            DisplayNode();
        }
    }
}