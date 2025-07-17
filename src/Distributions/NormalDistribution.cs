namespace Distributions;

public class NormalDistribution : IDistribution
{
    private readonly double _mu;
    private readonly double _sigma;
    private readonly double _sigmaSquared;

    public NormalDistribution(double mu, double sigmaSquared)
    {
        if (sigmaSquared <= 0)
        {
            throw new ArgumentException("Sigma squared must be greater than 0");
        }

        _mu = mu;
        _sigmaSquared = sigmaSquared;

        _sigma = Math.Sqrt(sigmaSquared);
    }

    public double Mean => _mu;

    public double Variance => _sigmaSquared;

    public double PDF(double x)
    {
        var d = (x - _mu) / _sigma;
        return Math.Exp(-0.5 * d * d) / (Constants.Sqrt2Pi * _sigma);
    }
}