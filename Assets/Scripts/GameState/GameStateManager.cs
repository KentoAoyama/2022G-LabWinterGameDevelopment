public class GameStateManager
{
    private static InGameState _gameState;

    /// <summary>
    /// �O������State���Q�Ƃ��Ċm�F����p�̃v���p�e�B
    /// </summary>
    public InGameState GameState => _gameState;

    /// <summary>
    /// �O������State��ύX����p�̃��\�b�h
    /// </summary>
    /// <param name="gameState">�ύX����State</param>
    public static void ChangeState(InGameState gameState)
    {
        _gameState = gameState;
    }

    public enum InGameState
    {
        /// <summary>
        /// �Q�[���X�^�[�g���o���ł��邱�Ƃ�\��
        /// </summary>
        Start,

        /// <summary>
        /// �Q�[���V�[�����QD�̂��̂ł��邱�Ƃ�\��
        /// </summary>
        Game2D,

        /// <summary>
        /// �Q�[���V�[�����RD�ł��邱�Ƃ�\��
        /// </summary>
        Game3D,

        /// <summary>
        /// �C�x���g���[�r�[������Ă�����
        /// </summary>
        Movie,

        /// <summary>
        /// �Q�[�����|�[�Y���ł��邱�Ƃ�\��
        /// </summary>
        Pause,

        /// <summary>
        /// �����̕ύX���ł��邱�Ƃ�\��
        /// </summary>
        DimentionChange,

        /// <summary>
        /// �v���C���[���S�[�����Ă����Ԃ�\��
        /// </summary>
        Goal
    }
}
