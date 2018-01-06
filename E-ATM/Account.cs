namespace E_ATM
{
    public class Account
    {
        public int id;
        public int cardNumber;
        public int pinNumber;
        public double balance;

        public Account()
        {

        }

        public Account(int cardnumber, int pin, double balance)
        {
            this.cardNumber = cardnumber;
            this.pinNumber = pin;
            this.balance = balance;
        }
        

        public Account(int id, int cardnumber, int pin, double balance)
        {
            this.id = id;
            this.cardNumber = cardnumber;
            this.pinNumber = pin;
            this.balance = balance;
        }

    }
}