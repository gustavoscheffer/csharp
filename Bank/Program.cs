using Bank;

BankAccount acc1, acc2;

try
{
    acc1 = new BankAccount("Gustavo", 1000);
    Console.WriteLine($"Client: {acc1.Owner}, Initial Balance: {acc1.Balance}, Acc Number: {acc1.Number}"); 

    acc2 = new BankAccount("Naides", 1100);
    Console.WriteLine($"Client: {acc2.Owner}, Initial Balance: {acc2.Balance}, Acc Number: {acc2.Number}"); 

}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    throw;
}


Console.WriteLine("");
acc1.MakeDeposit(50,DateTime.Now, "Saving");
acc1.MakeWithdrawal(40, DateTime.Now, "Netflix");

Console.WriteLine($"Client: {acc1.Owner}");
Console.WriteLine(acc1.GetAccountHistory());

Console.WriteLine($"Client: {acc2.Owner}");
Console.WriteLine(acc2.GetAccountHistory());