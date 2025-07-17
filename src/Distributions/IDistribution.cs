namespace Distributions;

public interface IDistribution
{
    double Mean { get; }
    double Variance { get; }
    double PDF(double x);
}