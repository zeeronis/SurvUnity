using UnityEngine;

namespace Survive
{
    public class InputController : MonoBehaviour
    {
        #region Variables
        [SerializeField] 
        private float _minThreshold;
        
        private static InputController instance;

        private bool _isTouchMoving;
        private bool _isKeyboardMoving;
        private Vector3 _moveDirection;
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        #endregion
    
        #region Properties
        public static InputController Instance => instance;

        public Vector3 MoveDirection => _moveDirection;
        #endregion
    
        #region Unity Lifecycle
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }
        
        private void Update()
        {
            if(Input.touchSupported)
            {
                if(Input.touches.Length > 0)
                {
                    if (Input.touches[0].phase == TouchPhase.Began)
                    {
                        _isTouchMoving = true;
                        _startPosition = Input.touches[0].position;
                    }
                    else if (Input.touches[0].phase == TouchPhase.Ended)
                    {
                        _isTouchMoving = false;
                    }
                    
                    _currentPosition = Input.touches[0].position;
                }
            }
            else
            {

                if (Input.GetMouseButtonDown(0))
                {
                    _isTouchMoving = true;
                    _startPosition = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    _isTouchMoving = false;
                }               
                _currentPosition = Input.mousePosition;
                

                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    _isTouchMoving = false;
                    _isKeyboardMoving = true;
                }
                else
                {
                    _isKeyboardMoving = false;
                }
            }

            if (_isTouchMoving)
            {
                if (Vector3.Distance(_currentPosition, _startPosition) > _minThreshold)
                {
                    Vector3 direction = (_currentPosition - _startPosition).normalized;

                    if (direction != Vector3.zero)
                    {
                        _startPosition = _currentPosition;
                        _moveDirection = direction;
                    }
                }
            }
            else if (_isKeyboardMoving)
            {
                _moveDirection = new Vector3(Input.GetAxis("Horizontal"),
                    Input.GetAxis("Vertical")).normalized;

            }
            else
            {
                _moveDirection = Vector3.zero;
            }
            

            
        }
        #endregion
    }
}
