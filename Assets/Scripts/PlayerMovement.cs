using Scripts.Infrastructure.Input;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement: MonoBehaviour
{
   
    private Vector3 temp;
    private float _playerSpeed;
    private float _rotationSpeed;
    private IMoveAnimation _moveAnimation;
    private IInputService _inputService;
    private bool _canMove;
    private Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
        }
    }

    public void Init(IInputService inputService,float playerSpeed, float rotationSpeed, IMoveAnimation moveAnimation)
    {
        _inputService = inputService;
        _playerSpeed = playerSpeed;
        _rotationSpeed = rotationSpeed;
        _moveAnimation = moveAnimation;
        _rigidbody = GetComponent<Rigidbody>();
        _canMove = true;
    }

    private void MakeRotation(Vector3 target)
    {
        Vector3 lookDirection = target - transform.position;
        if (lookDirection != Vector3.zero)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation,
                                                       Quaternion.LookRotation(lookDirection), _rotationSpeed * Time.fixedDeltaTime);
        }
    }
    

    private void Move()
    {
        temp.x = _inputService.GetHorizontal;
        temp.z = _inputService.GetVertical;

        _moveAnimation.MoveAnimation(temp.magnitude);
      //  _navMesh.Move(temp * _playerSpeed * Time.fixedDeltaTime);
      _rigidbody.transform.Translate(temp * Time.deltaTime * _playerSpeed, Space.World);
          Vector3 tempDirect = transform.position + Vector3.Normalize(temp);
         MakeRotation(tempDirect);
    }
}