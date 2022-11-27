using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject cursor;

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�w���v�{�^������������
        //�w���v�̉�ʂ̑���
        //�L�[�̈ړ��@
        //�I����̓�

        if (helpMenu.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.S) && counter < helpMenu.transform.childCount-1)
            {
                counter++;
            }
            else if(Input.GetKeyDown(KeyCode.W) && counter > 0)
            {
                counter--;
            }
            cursor.transform.position = helpMenu.transform.GetChild(counter).position;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //�w���v��ʕ\��
                helpMenu.SetActive(false);
                cursor.SetActive(false);
            }
        }
        else if (!helpMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                counter = 0;
                //�w���v��ʕ\��
                helpMenu.SetActive(true);
                cursor.SetActive(true);
            }
        }
    }
}
