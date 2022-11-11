using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Dimention���Ǘ�����static�N���X
/// </summary>
public class DimentionManager
{
    //�N���X��Singleton�ɂ���
    private static DimentionManager _instance = new ();
    public static DimentionManager Instance
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
    private DimentionManager() { }


    /// <summary>
    /// Dimention���s���I�u�W�F�N�g�̃��X�g
    /// </summary>
    private List<GameObject> _dimentionObjectHolder = new ();
    /// <summary>
    /// Dimention���s���I�u�W�F�N�g�̃��X�g�̃v���p�e�B
    /// </summary>
    public List<GameObject> DimentionObjectHolder { get => _dimentionObjectHolder; set => _dimentionObjectHolder = value; }

    /// <summary>
    /// Dimention���s���L�����N�^�[�̃��X�g
    /// </summary>
    private List<GameObject> _dimentionCharactorHolder = new();
    /// <summary>
    /// Dimention���s���I�u�W�F�N�g�̃��X�g�̃v���p�e�B
    /// </summary>
    public List<GameObject> DimentionCharactorHolder { get => _dimentionCharactorHolder; set => _dimentionCharactorHolder = value; }

    /// <summary>
    /// �V�[���̑J�ڂ��s���O��State��ۑ����Ă����p�̕ϐ�
    /// </summary>
    GameStateManager.InGameState _beforeState;

    /// <summary>
    /// �V�[���̑J�ڂ��J�n���邽�߂̃N���X
    /// </summary>
    /// <param name="sceneName">�J�ڂ���V�[���̖��O</param>
    /// <param name="changeInterval">�V�[���̑J�ڂɂ����鎞��</param>
    /// <returns></returns>
    public IEnumerator DimentionChangeStart(string sceneName, float changeInterval = 1.0f)
    {
        Debug.Log("DimentionChange�X�^�[�g");

        //���݂̃X�e�[�g��2D3D�؂�ւ��̂��߂ɕۑ�
        _beforeState = GameStateManager.Instance.GameState;
        //�|�[�Y�̏��������s
        PauseManager.Instance.OnPause();
        //�V�[���J�ڎ��̏����̂��߃X�e�[�g��ύX
        GameStateManager.Instance.GameStateChange(GameStateManager.InGameState.DimentionChange);

        yield return new WaitForSeconds(changeInterval);

        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// �V�[���̕ύX������̏���
    /// </summary>
    /// <param name="finishInterval">�V�[���J�ڌ�̉��o�ɂ����鎞��</param>
    public IEnumerator DimentionChangeFinish(float finishInterval = 1.0f)
    {
        //GameState��3D2D��؂�ւ���
        if (_beforeState == GameStateManager.InGameState.Game2D)
        {
            GameStateManager.Instance.GameStateChange(GameStateManager.InGameState.Game3D);
        }
        else if (_beforeState == GameStateManager.InGameState.Game3D)
        {
            GameStateManager.Instance.GameStateChange(GameStateManager.InGameState.Game2D);
        }
        //�J�ڂ��Ă����|�[�Y�����s
        PauseManager.Instance.OnPause();

        yield return new WaitForSeconds(finishInterval);

        //���o�I����|�[�Y������
        PauseManager.Instance.OnResume();

        Debug.Log("DimentionChange�I��");
    }
}
