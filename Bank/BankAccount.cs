namespace Bank;

public class BankAccount
{

    private static int s_accountNumberSeed = 123456789;
    public string Number { get; }
    public string Owner { get; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }


    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Intial balance");

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        _allTransactions.Add(new Transaction(amount, date, note));
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (Balance - amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Not sufficient funds for this withdrawal");
        }
        _allTransactions.Add(new Transaction(-amount, DateTime.Now, note));

    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }
}