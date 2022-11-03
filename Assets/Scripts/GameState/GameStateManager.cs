using UnityEngine;
using System;

public class GameStateManager
{
    //�N���X��Singleton�ɂ���
    private static GameStateManager _instance = new();
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private GameStateManager() { }

    private static InGameState _gameState;

    /// <summary>
    /// �O������State���Q�ƁA�ύX����p�̃v���p�e�B
    /// </summary>
    public InGameState GameState { get => _gameState; set => _gameState = value; }

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
        /// �����̕ύX���ł��邱�Ƃ�\��
        /// </summary>
        DimentionChange,

        /// <summary>
        /// �v���C���[���S�[�����Ă����Ԃ�\��
        /// </summary>
        Goal
    }
}
