using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int createCount;
    [SerializeField] Button buttonPrefab;

    [SerializeField] string [] titleName;
    [SerializeField] List<Button> buttons; 
    [SerializeField] Transform createPosition;

    void Start()
    {
        buttons.Capacity = 10;

        CreateButton();
        Register();
    }

    private void CreateButton()
    {
        for(int i = 0; i < createCount; i++)
        {
            Button button = Instantiate(buttonPrefab);

            button.transform.SetParent(createPosition);

            buttons.Add(button);

            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = titleName[i];
        }
    }

    private void Register()
    {
        buttons[0].onClick.AddListener(StartGame);
        buttons[1].onClick.AddListener(B);
        buttons[2].onClick.AddListener(C);
        buttons[3].onClick.AddListener(D);
    }

    public void StartGame()
    {
        GameManager.instance.StartCoroutine(GameManager.instance.StartRoutine(3));
    }

    public void B()
    {
        Debug.Log("B");
    }

    public void C()
    {
        Debug.Log("C");
    }

    public void D()
    {
        Debug.Log("D");
    }
}
