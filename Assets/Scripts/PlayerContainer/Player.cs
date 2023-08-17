using Input;
using NPCContainer;
using UnityEngine;

namespace PlayerContainer
{
  [RequireComponent(typeof(PlayerMovement))]
  [RequireComponent(typeof(PlayerAnimator))]
  public class Player : MonoBehaviour
  {
    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;
   
    private bool _onDialog;
    private IFinishDialogueEvent _dialogueEvent;

    public void Init(IInputService input, PlayerConfig config, IFinishDialogueEvent dialogueEvent)
    {
      _playerMovement = GetComponent<PlayerMovement>();
      _playerAnimator = GetComponent<PlayerAnimator>();
      _playerMovement.Init(input, config.Speed, config.RotationSpeed, _playerAnimator);
      _dialogueEvent = dialogueEvent;
      _dialogueEvent.FinishDialogue += OnFinishingDialogue;
    }

    private void OnFinishingDialogue()
    {
      _onDialog = false;
      _playerMovement.StartMove();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.TryGetComponent(out NPC npc))
      {
        if (!_onDialog)
        {
          npc.StartDialogue(gameObject.transform);
          _onDialog = true;
          _playerMovement.StopMove();
        }
       
      }
    }

   
    
  }
}