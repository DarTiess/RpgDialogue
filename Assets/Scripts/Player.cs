using Scripts.Infrastructure.Input;
using UnityEngine;

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
}
