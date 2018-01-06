using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ATM
{
    class Index
    {
        private EatmMachine eatm = new EatmMachine();

        public void SystemTitle()
        {
            Console.WriteLine(" WELCOME TO OUR EATM SYSTEM !! ");
        }

        public void EATMSystem()
        {
            bool cardFlag = true;

            while (cardFlag)
            {
                Console.Write("Enter your card number : ");
                int cardNumber = Convert.ToInt32(Console.ReadLine());
                if (eatm.CardValidation(cardNumber))
                {
                    cardFlag = false;
                    bool pinFlag = true;

                    while (pinFlag)
                    {
                        MainOptions(cardNumber,pinFlag);
                    }
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Card Number !");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        private void MainOptions(int cardNumber,bool pinFlag)
        {
            int withdrawLimit = 0;
            {
                Console.Write("Enter pin number : ");
                var pin = Convert.ToInt32(Console.ReadLine());
                if (eatm.CheckPinNumber(pin, cardNumber))
                {
                    pinFlag = false;

                    bool optionFlag = true;

                    while (optionFlag)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press => [1] for Balance Check, [2] for Withdraw Balance, [3] for Exit.");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("What you want to do ? : ");
                        var choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                eatm.CheckBalance(cardNumber);
                                break;

                            case 2:
                                //int tempCardNumber = cardNumber;
                                if (withdrawLimit <= 3)
                                {
                                    eatm.balanceWithdrawal(cardNumber);
                                    withdrawLimit++;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Limit over !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;

                            case 3:
                                optionFlag = false;
                                EATMSystem();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Key !");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Pin Number !");
                    Console.ForegroundColor = ConsoleColor.White;
                    //pinFlag = false;
                    eatm.CheckPinNumber(pin, cardNumber);
                }
            }
        }
    }
}
