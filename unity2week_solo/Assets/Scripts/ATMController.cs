using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour
{
    public TMP_Text balanceText; // 잔액을 표시할 텍스트 UI
    public TMP_Text cashText; // 현금을 표시할 텍스트 UI
    public TMP_InputField withdrawInput; // 출금할 금액을 입력할 InputField
    public TMP_InputField depositInput; 

    private int balance = 50000; // 초기 잔액 설정 (50,000원)
    private int cash = 100000; // 초기 현금 설정 (100,000원)

    [SerializeField] private GameObject NotEnoughMoneyPopUp;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        balanceText.text = "Balance: " + " " + balance.ToString("N0"); // 잔액 표시
        cashText.text = "현금 \n" + cash.ToString("N0"); // 현금 표시
        withdrawInput.text = ""; // 출금 입력 필드 초기화
        depositInput.text = "";
    }

    // 금액 버튼을 눌렀을 때 해당 금액을 입금하는 함수
    public void DepositAmount(int amount)
    {
        if(amount >= 0)
        {
            if (cash >= amount)
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
        
    }

    // 금액 버튼을 눌렀을 때 해당 금액을 출금하는 함수
    public void WithdrawAmount(int amount)
    {
        if(amount >= 0)
        {
            if (balance >= amount)
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




