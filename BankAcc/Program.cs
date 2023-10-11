namespace BankAcc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank[] Accounts = new Bank[5];

            Accounts[0] = new Bank(701563131, "Соболев Максим Эмирович", 3200.0F);
            Accounts[1] = new Bank(701563856, "Майоров Константин Робертович", 51727.0F);
            Accounts[2] = new Bank(701564217, "Широкова София Фёдоровна", 962527.94F);
            Accounts[3] = new Bank(701564912, "Андреев Максим Рафаэльевич", 1107.13F);
            Accounts[4] = new Bank(701565362, "Скворцова Евгения Макаровна", 31374.67F);

            while (true)
            {
                Console.Clear();
                int temp_idx = 1;
                for (int i = 0; i < Accounts.Length; i++, temp_idx++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{temp_idx}.");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Accounts[i].Out();
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Write("Ввведите номер счета, от которого будут выполняться операции: ");
                int idx = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Clear();

                Accounts[idx].Out();

                Console.WriteLine($"1. Положить деньги на счет\n" +
                    $"2. Снять деньги со счета\n" +
                    $"3. Обноличить счет\n" +
                    $"4. Перевести деньги на другой счет\n" +
                    $"5. Выбрать другой счет\n" +
                    $"6. Выход\n");

                Console.Write("Введите операцию по счету: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите сумму средств для пополнения: ");
                        Accounts[idx].AddMoney( Convert.ToSingle(Console.ReadLine()) );
                        break;
                    case "2":
                        Console.Write("Введите сумму средств для вывода: ");
                        Accounts[idx].WithdrawMoney(Convert.ToSingle(Console.ReadLine()));
                        break;
                    case "3":
                        Accounts[idx].CashOut();
                        Console.Write("Счет был обналичен");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        temp_idx = 1;
                        for (int i = 0; i < Accounts.Length; i++, temp_idx++)
                        {
                            if (idx != i)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"{temp_idx}.");
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Accounts[i].Out();
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        Console.Write("Введите номер счета на который хотите перевести деньги: ");
                        int t_idx = Convert.ToInt32(Console.ReadLine())-1;
                        Console.Write("Введите сумму средств для перевода: ");
                        float sum = Convert.ToSingle(Console.ReadLine());
                        Accounts[idx].Transfer(Accounts[t_idx], sum);
                        break;
                    case "5":
                        break;
                    case "6":
                        return;
                    default:
                        break;
                }

            }

        }
    }
}