namespace Distributions;

public class LogNormalDistribution : IDistribution
{
    private readonly double _mu;
    private readonly double _sigmaSquared;
    private readonly double _sigma;
    private readonly double _mean;
    private readonly double _variance;

    public LogNormalDistribution(double mu, double sigmaSquared)
    {
        if (sigmaSquared <= 0)
        {
            throw new ArgumentException("Sigma squared must be greater than 0");
        }

        _mu = mu;
        _sigmaSquared = sigmaSquared;

        // Computed values. Depending on usage patterns this might not be optimal
        _sigma = Math.Sqrt(_sigmaSquared);
        _mean = Math.Exp(_mu + _sigmaSquared / 2);
        _variance = (Math.Exp(_sigmaSquared) - 1) * Math.Exp(2 * _mu + _sigmaSquared);
    }

    public double Mean => _mean;

    public double Variance => _variance;

    public double PDF(double x)
    {
        if (x <= 0)
        {
            throw new ArgumentException("x must be greater than 0 for log-normal distribution");
        }

        var a = (Math.Log(x) - _mu) / _sigma;
        return Math.Exp(-0.5 * a * a) / (x * _sigma * Constants.Sqrt2Pi);
    }
}