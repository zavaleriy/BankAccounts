using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAcc
{
    internal class Bank
    {
        private readonly int id; // Номер счета
        private readonly string name; // ФИО владельца
        private float money; // Сумма денег на счету

        public Bank(int id, string name, float money)
        {
            this.id = id;
            this.name = name;
            this.money = money;
        }

        // Вывод информации
        public void Out() =>
            Console.WriteLine($"Номер счета: {id}\n" +
                $"ФИО: {name}\n" +
                $"Сумма на счету: {Math.Round(money,2)}\n");
        
        // Положить деньги на счет
        public void AddMoney(float sum) => money += sum;

        // Снять со счета
        public void WithdrawMoney(float sum)
        {
            if (money >= sum) money -= sum;
            else 
            { 
                Console.WriteLine("\nНедостаточно денег на счету");
                Console.ReadLine();
            }
        }

        // Обналичить счет
        public void CashOut() => money = 0;

        // Перевести деньги на другой счет
        public void Transfer(Bank account, float sum)
        {
            if (money >= sum && account.id != id)
            {
                money -= sum;
                account.AddMoney(sum);
            }
            else if (account.id == id)
            {
                Console.Write("\nНельзя перевести деньги самому себе");
                Console.ReadLine();
            }
            else
            {
                Console.Write("\nНедостаточно денег для перевода");
                Console.ReadLine();
            }
        }
    }
}
