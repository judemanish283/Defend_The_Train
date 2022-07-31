using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldreward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if(bank == null) { return; }
        bank.Deposit(goldreward);
    }

    public void StealGold()
    {
        if(bank == null) { return; }
        bank.Withdrawal(goldPenalty);
    }
}
