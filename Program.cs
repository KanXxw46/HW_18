using System;
using Services;
using System;
using System.Net.Mail;
using Twilio.TwiML.Voice;

namespace Hw_18
{
    class Program
    {
        static void Main(string[] args)
        {
            var newAccount = new Account();
            Console.WriteLine("Please enter your full name");
            newAccount.FullName = Console.ReadLine();
            bool menuFlag = true;

            UserChoiseServise(newAccount);

            while (menuFlag)
            {
                Console.WriteLine("Select an operation to work with the account");
                Console.WriteLine("1)AddMoney. 2)WithdrawMoney. 3)ChangeNotification. 4)Exit.");

                int userChoiseOperation = Convert.ToInt32(Console.ReadLine());
                int money;

                switch (userChoiseOperation)
                {
                    case 1:
                        money = Convert.ToInt32(Console.ReadLine());
                        newAccount.Add(money);
                        break;
                    case 2:
                        money = Convert.ToInt32(Console.ReadLine());
                        newAccount.Withdraw(money);
                        break;
                    case 3:
                        UserChoiseServise(newAccount);
                        break;
                    case 4:
                        menuFlag = false;
                        break;
                }
            }

        }

        static void UserChoiseServise(Account newAccount)
        {
            Console.WriteLine("What kind of notification do you want to have when interacting with the account?");
            Console.WriteLine("1 - Console. 2 - Sms. 3 - Email");
            int userChoise = Convert.ToInt32(Console.ReadLine());
            switch (userChoise)
            {
                case 1:
                    newAccount.messageEvent += new ConsoleMessageSender().SendMessage;
                    break;
                case 2:
                    newAccount.messageEvent += new SmsMessangeSender().SendMessage;
                    break;
                case 3:
                    newAccount.messageEvent += new EmailSender().SendMessage;
                    break;
            }
        }

    }
}
