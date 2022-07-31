using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance {get { return  currentBalance;} }
    
    void Awake() 
    {
        currentBalance = startingBalance;    
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
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
}
