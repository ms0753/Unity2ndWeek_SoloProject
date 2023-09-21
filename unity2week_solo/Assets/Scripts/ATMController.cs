using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour
{
    public TMP_Text balanceText; // �ܾ��� ǥ���� �ؽ�Ʈ UI
    public TMP_Text cashText; // ������ ǥ���� �ؽ�Ʈ UI
    public TMP_InputField withdrawInput; // ����� �ݾ��� �Է��� InputField
    public TMP_InputField depositInput; 

    private int balance = 50000; // �ʱ� �ܾ� ���� (50,000��)
    private int cash = 100000; // �ʱ� ���� ���� (100,000��)

    [SerializeField] private GameObject NotEnoughMoneyPopUp;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        balanceText.text = "Balance:"+ "   " + balance.ToString(); // �ܾ� ǥ��
        cashText.text = "���� \n" + cash.ToString(); // ���� ǥ��
        withdrawInput.text = ""; // ��� �Է� �ʵ� �ʱ�ȭ
        depositInput.text = "";
    }

    // �ݾ� ��ư�� ������ �� �ش� �ݾ��� �Ա��ϴ� �Լ�
    public void DepositAmount(int amount)
    {
        if (cash >= amount)
        {
            cash += amount;
            balance -= amount;
            UpdateUI();
        }
        else
        {
            NotEnoughMoneyPopUp.SetActive(true);
        }
    }

    // �ݾ� ��ư�� ������ �� �ش� �ݾ��� ����ϴ� �Լ�
    public void WithdrawAmount(int amount)
    {
        if (balance >= amount)
        {
            cash -= amount;
            balance += amount;
            UpdateUI();
        }
        else
        {
            NotEnoughMoneyPopUp.SetActive(true);
        }
    }

    public void OnclickedSendBtn()
    {
        int value = GetInputValue(withdrawInput);
        WithdrawAmount(value);
       
    }

    public void OnclickedOutBtn()
    {
        int value = GetInputValue(depositInput);
        DepositAmount(value);
    }

    private int GetInputValue(TMP_InputField inputField)
    {
        int inputValue = 0;
        if (int.TryParse(inputField.text, out inputValue))
        {
            return inputValue;
        }
        return 0;
    }
    

    
}




