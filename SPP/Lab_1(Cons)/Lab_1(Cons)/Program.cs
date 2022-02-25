Thread thread = new Thread(Calc);

static void Calc()
{
    double a;
    double sum = 0;
    long i = 1;

    double X, N;

    Console.WriteLine("Введите X: ");
    X = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Введите N: ");
    N = Convert.ToDouble(Console.ReadLine());

    static long Fact(long n)
    {
        if (n == 0)
            return 1;
        else
            return n * Fact(n - 1);
    }


    while (i <= N)
    {
        long fact = Fact(i);
        a = (Math.Pow(X, i)) / (fact);
        sum += a;
        i++;
    }
    Console.WriteLine(sum+1);
}


thread.Start();
try
{
    thread.Interrupt();

}
catch(ThreadInterruptedException)
{ }

