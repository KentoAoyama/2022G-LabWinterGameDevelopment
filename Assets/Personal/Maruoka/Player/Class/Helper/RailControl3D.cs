using System;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class RailControl3D
{
    /// <summary>
    /// ���[���̍ő�{�� : <br/>
    /// ���[���̐������ɂ��� <br/>
    /// ���[���͍ł����̃��[����0�ԖڂŁA<br/>
    /// ��̃��[���ɍs���ق�1�������Ă䂭 <br/>
    /// </summary>
    [Tooltip("���[���̍ő�{��"), SerializeField]
    private int _maxRails = 1;
    [InputName, SerializeField]
    private string _upStepButtonName = default;
    [InputName, SerializeField]
    private string _downStepButtonName = default;
    [Tooltip("���[���Ԃ̕�"), SerializeField, Range(1f, 10f)]
    private float _widthBetweenRails = 1f;
    [SerializeField]
    private float _jumpPower = 1f;
    [Tooltip("�X�e�b�v�Ɋ|���鎞��"), SerializeField]
    private float _stepDuration = 1.5f;
    [SerializeField]
    private bool _isReadyStep = true;

    private Transform _transform = default;
    private bool _isStepNow = false;
    public bool IsStepNow => _isStepNow;

    private PlayerStateController _stateController = null;

    public bool IsReadyStep
    {
        get => _isReadyStep;
        set
        {
            if (value)
            {
                Debug.Log("�X�e�b�v�\�ɂ��܂�");
            }
            else
            {
                Debug.LogWarning("�X�e�b�v�s�ɂ��܂�");
            }
            _isReadyStep = value;
        }
    }

    /// <summary>
    /// ���݂��郌�[���̈ʒu
    /// </summary>
    private int _nowPos = 0;

    public void Init(Transform transform, PlayerStateController stateController)
    {
        _transform = transform;
        _stateController = stateController;
    }
    public void Update()
    {
        if (IsRun())
        {
            if (Input.GetButtonDown(_upStepButtonName))
            {
                MovementOrder(MovementDirection.MOVE_UP);
            }
            else if (Input.GetButtonDown(_downStepButtonName))
            {
                MovementOrder(MovementDirection.MOVE_DOWN);
            }
        }
    }
    private void MovementOrder(MovementDirection direction)
    {
        if (direction == MovementDirection.MOVE_UP)
        {
            Debug.Log("�u��v�̃��[���ֈړ����܂�");
            if ((_nowPos + 1) >= _maxRails)
            {
                Debug.LogWarning("����ȏ��փX�e�b�v�ł��Ȃ���");
            }
            else
            {
                _nowPos++;
                Step(_transform.position + new Vector3(0, 0, _widthBetweenRails),
                    _stepDuration);
            }
        }
        else if (direction == MovementDirection.MOVE_DOWN)
        {
            Debug.Log("�u���v�̃��[���ֈړ����܂�");
            if ((_nowPos - 1) < 0)
            {
                Debug.LogWarning("����ȏ��փX�e�b�v�ł��Ȃ���");
            }
            else
            {
                _nowPos--;
                Step(_transform.position - new Vector3(0, 0, _widthBetweenRails),
                    _stepDuration);
            }
        }
#if UNITY_EDITOR
        else
        {
            Debug.LogError("�����Ȓl���n����܂����I�C�����Ă��������I");
        }
#endif
    }
    private void Step(Vector3 targetPos, float seconds)
    {
        _isReadyStep = false;
        _isStepNow = true;
        _transform.DOJump(targetPos, _jumpPower, 1, _stepDuration).
            OnComplete(() =>
            {
                _isReadyStep = true;
                _isStepNow = false;
            });
    }
    private bool IsRun()
    {
        bool result = false;

        result =
            _isReadyStep &&
            _stateController.CurrentState == PlayerState.IDLE ||
            _stateController.CurrentState == PlayerState.MOVE;

        return result;
    }
}
public enum MovementDirection
{
    MOVE_UP,
    MOVE_DOWN
}