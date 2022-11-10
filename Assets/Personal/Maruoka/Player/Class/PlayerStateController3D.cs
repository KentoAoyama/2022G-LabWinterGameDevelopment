using UnityEngine;

[System.Serializable]
public class PlayerStateController3D : PlayerStateController
{
    private Rigidbody _rb = default;

    //[SerializeField]
    //private RailControl3D _railControler3D = default;

    public void Init(Rigidbody rb)
    {
        _rb = rb;
    }
    public override void Update()
    {
        FacingDirectionUpdate();
        StateUpdate();
    }
    private void FacingDirectionUpdate()
    {
        // �����Ă���������X�V����
        if (!Mathf.Approximately(_rb.velocity.x, 0f))
        {
            if (_rb.velocity.x > 0f)
            {
                FacingDirection = FacingDirection.RIGHT;
            }
            else if (_rb.velocity.x < 0f)
            {
                FacingDirection = FacingDirection.LEFT;
            }
        }
    }
    private void StateUpdate()
    {
        // �����ɃX�e�[�g���X�V���鏈�����L�q����
    }
}