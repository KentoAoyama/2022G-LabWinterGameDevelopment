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
        //ヘルプボタンを押したら
        //ヘルプの画面の操作
        //キーの移動　
        //選択後の動

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
                //ヘルプ画面表示
                helpMenu.SetActive(false);
                cursor.SetActive(false);
            }
        }
        else if (!helpMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                counter = 0;
                //ヘルプ画面表示
                helpMenu.SetActive(true);
                cursor.SetActive(true);
            }
        }
    }
}
