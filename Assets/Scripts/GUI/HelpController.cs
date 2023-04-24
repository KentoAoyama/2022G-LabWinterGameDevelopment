using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpController : MonoBehaviour
{
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject helpOptions;
    [SerializeField] GameObject helpCursor;

    [SerializeField] GameObject _helpMenu;

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        helpMenu.SetActive(false);
        helpCursor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (helpMenu.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.S) && counter < helpOptions.transform.childCount-1)
            {
                counter++;
            }
            else if(Input.GetKeyDown(KeyCode.W) && counter > 0)
            {
                counter--;
            }
            helpCursor.transform.position = helpOptions.transform.GetChild(counter).position;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseManager.Instance.OnResume?.Invoke();
                helpMenu.SetActive(false);
                helpCursor.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (counter)
                {
                    case 0://ゲームを続ける
                        helpMenu.SetActive(false);
                        helpCursor.SetActive(false);
                        break;
                    case 1://ヘルプ
                        _helpMenu.SetActive(true);
                        break;
                    case 2://タイトルに戻る
                        SceneManager.LoadScene("TitleScene");
                        break;
                    default:
                        break;
                }
            }
        }
        else if (!helpMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButton(1))
            {
                PauseManager.Instance.OnPause?.Invoke();
                counter = 0;
                helpMenu.SetActive(true);
                helpCursor.SetActive(true);
            }
        }

        if (_helpMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _helpMenu.SetActive(false);
            }
        }
    }
}
