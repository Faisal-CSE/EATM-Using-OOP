using System;
using System.Collections.Generic;

namespace E_ATM
{
    public class EatmMachine
    {
        private readonly Dictionary<int, int> _transaction;
        private readonly List<Account> _acc; 

        public EatmMachine()
        {
            _acc = new List<Account>();
            _transaction = new Dictionary<int, int>();
            var client1 = new Account(1, 123, 500);
            var client2 = new Account(2, 234, 350);
            var client3 = new Account(3, 345, 1200);
            
            _acc.Add(client1);
            _acc.Add(client2);
            _acc.Add(client3);

            //Store the card numbers 
            _transaction.Add(client1.cardNumber,0);
            _transaction.Add(client2.cardNumber,0);
            _transaction.Add(client3.cardNumber,0);
        }
        
        public bool CardValidation(int cardNumber)
        {
            foreach (var getCustmoerCardNumber in _acc)
            {

                if (getCustmoerCardNumber.cardNumber == cardNumber)
                {
                    return true;
                }
                
            }
            return false;
        }

        public bool CheckPinNumber(int pinNumber,int cardNumber)
        {
            foreach (var i in _acc)
            {
                if (i.cardNumber == cardNumber && i.pinNumber == pinNumber)
                {
                    return true;
                }
                
            }
            return false;
        }

        public void CheckBalance(int cardNumber)
        {
            Account customInfo = _acc[cardNumber];
            Console.WriteLine("Your current balance is : " +customInfo.balance);
        }

        public void balanceWithdrawal(int cardNumber)
        {
            bool flag = true;
            int tries = 0;

            while (flag)
            {
                if (_transaction[cardNumber] < 3)
                {
                    Console.Write("Enter amount : ");
                    double amount = Double.Parse(Console.ReadLine());

                    if (amount <= 1000)
                    {
                        flag = false;
                        tries++;

                        var customerInfo = _acc[cardNumber];
                        var availableBalance = customerInfo.balance;

                        if (availableBalance >= amount)
                        {
                            int tempCustomerTransaction = _transaction[cardNumber];
                            
                            ++tempCustomerTransaction;
                            _transaction[cardNumber] = tempCustomerTransaction;
                            
                            availableBalance = availableBalance - amount;
                            _acc[cardNumber].balance = availableBalance;
                            Console.WriteLine("Withdraw Successfull.\nCurrent Balance : "+_acc[cardNumber].balance);
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Insufficient Balance !");
                        }
                    }
                    else
                    {
                        flag = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not allow to withdraw more than 1000 at a time !");
                    }

                }
                else
                {
                    flag = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Transaction Limit Over !");

                }
            }
        }



    }
}