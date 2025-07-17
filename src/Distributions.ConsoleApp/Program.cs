namespace Distributions.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: Distributions.Console <mu> <sigma_squared> <x>");
            Console.WriteLine("Example: Distributions.Console 3 1.5 3.6");
            return;
        }

        if (!double.TryParse(args[0], out double mu))
        {
            Console.WriteLine("Error: mu must be a valid number");
            return;
        }

        if (!double.TryParse(args[1], out double sigmaSquared))
        {
            Console.WriteLine("Error: sigma squared must be a valid number");
            return;
        }

        if (!double.TryParse(args[2], out double x))
        {
            Console.WriteLine("Error: x must be a valid number");
            return;
        }

        try
        {
            var normalDistribution = new NormalDistribution(mu, sigmaSquared);
            var normalPdf = normalDistribution.PDF(x);
            Console.WriteLine($"Normal({x};{mu},{sigmaSquared}) = {normalPdf:F4} (Mean : {normalDistribution.Mean:F4}, Variance : {normalDistribution.Variance:F4})");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error evaluating Normal distribution: {ex.Message}");
        }

        try
        {
            var logNormalDistribution = new LogNormalDistribution(mu, sigmaSquared);
            var logNormalPdf = logNormalDistribution.PDF(x);
            Console.WriteLine($"Log-normal({x};{mu},{sigmaSquared}) = {logNormalPdf:F4} (Mean : {logNormalDistribution.Mean:F4}, Variance : {logNormalDistribution.Variance:F4})");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error evaluating Log-normal distribution: {ex.Message}");
        }
    }
}
