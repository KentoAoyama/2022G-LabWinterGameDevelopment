using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject helpOptions;
    [SerializeField] GameObject helpCursor;

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    case 0://�Q�[���𑱂���
                        helpMenu.SetActive(false);
                        helpCursor.SetActive(false);
                        break;
                    case 1://�Q�[������߂�
                        break;
                    case 2://�w���v
                        break;
                    case 3://�^�C�g���ɖ߂�
                        break;
                    case 4://�������
                        break;
                    default:
                        break;
                }
            }
        }
        else if (!helpMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseManager.Instance.OnPause?.Invoke();
                counter = 0;
                helpMenu.SetActive(true);
                helpCursor.SetActive(true);
            }
        }
    }
}
