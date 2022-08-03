using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance {get { return  currentBalance;} }

    [SerializeField] TextMeshProUGUI goldText;
    
    void Awake() 
    {
        currentBalance = startingBalance;
        UpdateText();   
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateText();
    }

    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateText();
        if(currentBalance < 0)
        {
           Invoke("ReloadScene",3f);
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void UpdateText()
    {
        goldText.text = "Gold :" + currentBalance;
    }
}
