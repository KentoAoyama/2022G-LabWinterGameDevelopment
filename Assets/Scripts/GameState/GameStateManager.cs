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

    private InGameState _gameState;
    /// <summary>
    /// InGameState���O������Q�Ƃ���p�̃v���p�e�B
    /// </summary>
    public InGameState GameState => _gameState;

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

    /// <summary>
    /// GameState�̕ύX���s���ۂɌĂяo�����\�b�h
    /// </summary>
    /// <param name="gameState">�ύX����State</param>
    public void GameStateChange(InGameState gameState)
    {
        InGameState beforeState = _gameState;
        _gameState = gameState;
        Debug.Log($"GameState��{beforeState}����A{_gameState}�ɕύX����܂����B");
    }
}
