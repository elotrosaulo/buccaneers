using System.Collections;
using Rewired;
using UnityEngine;

namespace Behaviors
{
    public class PlayerActionsBehaviour : MonoBehaviour
    {

        [SerializeField] 
        public int playerId; // rewired player Id of this character
        [SerializeField] 
        public float moveSpeed = 15.0f;
        
        private Player _player;
        private float _moveDirection;
        private Vector3 _moveVector;
        private bool _isAttacking, _actionAttack, _animationComplete;
        private Rigidbody _playerRigidBody;
        private Animator _animator;
        private string _currentState;


        /*Animations assigned as const*/
        private const string JUMP = "jump";
        private const string IDLE = "Idle";
        private const string WALKLEFT = "walkLeft";
        private const string WALKRIGHT = "walkRight";
        private const string WALKUP = "walkUp";
        private const string WALKDOWN = "walkDown";
        private const string SLASHDOWN = "slashDown";
        private const string SLASHUP = "slashUp";
        private const string SLASHRIGHT = "slashRight";
        private const string SLASHLEFT = "slashLeft";
        
        /*regular vars*/
        private byte _statusDirection;
        
        /* coroutines*/
        private IEnumerator coroutine;


        #region MonoBehaviour Functions from unity
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _player = ReInput.players.GetPlayer(playerId);
            _playerRigidBody = GetComponent<Rigidbody>();

            var spawnPlayers = GameObject.Find("SpawnPlayers");
            if (spawnPlayers)
            {
                transform.parent = spawnPlayers.transform;
            }
        }

        private void FixedUpdate()
        {
            if (_moveVector != Vector3.zero)
            {
                ProcessMovementInput();
            }
            
        }

        private void Update()
        {
            GetInput();
        }

        #endregion
        
        #region Functions created for the actions of the player

        private void GetInput()
        {
            /*moveVector.x = player.GetAxis("Move Horizontal");
            moveVector.y = player.GetAxis("Vertical");*/
            _moveVector = Vector3.zero;
            _moveVector.x = Input.GetAxis("Horizontal");
            _moveVector.y = Input.GetAxis("Vertical");
            switch (_moveVector.x)
            {
                case > 0 when _moveVector.y is 0: // movimiento horizontal
                    _statusDirection = 0;
                    ChangeAnimationState(WALKRIGHT);
                    break;
                case < 0 when _moveVector.y is 0: // movimiento horizontal
                    _statusDirection = 1;
                    ChangeAnimationState(WALKLEFT);
                    break;
                case > 0 when _moveVector.y is > 0: // movimiento vertical/ horizontal derecha direccion arriba
                    _statusDirection = 2;
                    ChangeAnimationState(WALKUP);
                    break;
                case < 0 when _moveVector.y is > 0: // movimiento vertical/ horizontal izquierda direccion arriba
                    _statusDirection = 2;
                    ChangeAnimationState(WALKUP);
                    break;
                case > 0 when _moveVector.y is < 0: // movimiento vertical/ horizontal derecha direccion abajo
                    _statusDirection = 0;
                    ChangeAnimationState(WALKRIGHT);
                    break;
                case < 0 when _moveVector.y is < 0: // movimiento vertical/ horizontal derecha direccion abajo
                    _statusDirection = 1;
                    ChangeAnimationState(WALKLEFT);
                    break;
                default:
                    switch (_moveVector.y)
                    {
                        case > 0 when _moveVector.x is 0: // movimiento arriba
                            _statusDirection = 2;
                            ChangeAnimationState(WALKUP);
                            break;
                        case < 0 when _moveVector.x is 0: // movimiento abajo
                            _statusDirection = 3;
                            ChangeAnimationState(WALKDOWN);
                            break;
                        default:
                            if (!_isAttacking)
                            {
                                _animator.speed = 0;
                            }
                            break;
                    }

                    break;
            }
           

            //moveVector.y = player.GetAxis("Move Vertical");
            _actionAttack =_player.GetButtonDown("Action");
            if (_actionAttack && !_isAttacking)
            {
                _isAttacking = true;

                switch (_statusDirection)
                {
                    case 0:
                        ChangeAnimationState(SLASHRIGHT);
                        break;
                    case 1:
                        ChangeAnimationState(SLASHLEFT);
                        break;
                    case 2:
                        ChangeAnimationState(SLASHUP);
                        break;
                    case 3:
                        ChangeAnimationState(SLASHDOWN);
                        break;
                    default: 
                        _animator.speed = 0;
                        break;
                }
                
                AnimatorStateInfo animState = _animator.GetCurrentAnimatorStateInfo(0);
                float currentTime = animState.normalizedTime % 1;
                
                Invoke(nameof(AttackComplete), .51f);
            }

        }

        private void AttackComplete()
        {
            _isAttacking = false;
        }

        private void ProcessMovementInput()
        {
            _playerRigidBody.MovePosition(
                transform.position + _moveVector * (moveSpeed * Time.deltaTime));
        }

        #endregion
        
        // change the animation and reassign the current one
        private void ChangeAnimationState(string newState)
        {
            _animator.speed = 1;
            if (_currentState == newState) return;
            
            _animator.Play(newState);

            _currentState = newState;
        }
        
    }
}
