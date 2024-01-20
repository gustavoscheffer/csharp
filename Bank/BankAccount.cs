namespace Bank;

public abstract class BankAccount
{

    private static int s_accountNumberSeed = 123456789;
    private List<Transaction> _allTransactions = new List<Transaction>();
    private readonly decimal _minimumBalance;

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


    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        Owner = name;
        if (initialBalance > 0)
        {
            MakeDeposit(initialBalance, DateTime.Now, "Intial balance");
        }

    }

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
        if (amount <= _minimumBalance)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Not sufficient funds for this withdrawal");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);

        Transaction? withdrawal = new(-amount, date, note);
        _allTransactions.Add(withdrawal);

        if (overdraftTransaction != null)
            _allTransactions.Add(overdraftTransaction);


    }
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        else
        {
            return default;
        }
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

    public virtual void PerformMonthEndTransactions()
    {

    }
}