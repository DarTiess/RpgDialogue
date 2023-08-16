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
    private IInputService _input;

    public void Init(IInputService input, PlayerConfig config)
    {
      _playerMovement = GetComponent<PlayerMovement>();
      _playerAnimator = GetComponent<PlayerAnimator>();
      _playerMovement.Init(input, config.Speed, config.RotationSpeed, _playerAnimator);
    }

    private void OnTriggerStay(Collider other)
    {
      if (other.gameObject.TryGetComponent(out NPC npc))
      {
        npc.StartDialogue(gameObject.transform);
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.gameObject.TryGetComponent(out NPC npc))
      {
        npc.EndDialogue();
      }
    }
  }
}