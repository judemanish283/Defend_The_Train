using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost = 20;

    public bool CreateDefender(Defender defender, Vector3 position)
    {
        Bank bank =  FindObjectOfType<Bank>();
        if(bank == null)
        {
            return false;
        }
        if(bank.CurrentBalance >= cost)
        {
            Instantiate(defender, position, Quaternion.identity);
            bank.Withdrawal(cost);
            return true;
        }

        return false;
    }
}
