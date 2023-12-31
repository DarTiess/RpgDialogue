using DG.Tweening;
using Input;
using UnityEngine;

namespace PlayerContainer
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement: MonoBehaviour
    {
   
        private Vector3 _temp;
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
                Movement();
            }
        }
        public void Init(IInputService inputService,float playerSpeed, float rotationSpeed, IMoveAnimation moveAnimation)
        {
            _inputService = inputService;
            _playerSpeed = playerSpeed;
            _rotationSpeed = rotationSpeed;
            _moveAnimation = moveAnimation;
            _rigidbody = GetComponent<Rigidbody>();
            
            StartMove();
        }

        public void StartMove()
        {
            _canMove = true;
        }

        public void StopMove(Transform target)
        {
            _canMove = false;
            _moveAnimation.MoveAnimation(0);
            RotateToTalk(target);
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

        private void Movement()
        {
            _temp.x = _inputService.GetHorizontal;
            _temp.z = _inputService.GetVertical;

            _moveAnimation.MoveAnimation(_temp.magnitude);
            
            _rigidbody.transform.Translate(_temp * Time.deltaTime * _playerSpeed, Space.World);
            Vector3 tempDirect = transform.position + Vector3.Normalize(_temp);
            MakeRotation(tempDirect);
        }

        private void RotateToTalk(Transform target)
        {
            var look = Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position);

            transform.DORotateQuaternion(look, _rotationSpeed);
        }
    }
}