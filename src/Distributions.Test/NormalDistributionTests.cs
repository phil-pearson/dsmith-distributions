namespace Distributions.Test;

public class NormalDistributionTests
{
    [Fact]
    public void Constructor_WithInvalidSigmaSquared_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new NormalDistribution(0, 0));
        Assert.Throws<ArgumentException>(() => new NormalDistribution(0, -1));
    }

    [Fact]
    public void NormalDistribution_WithMu3SigmaSquared1Point5_HasCorrectMean()
    {
        var distribution = new NormalDistribution(3, 1.5);
        Assert.Equal(3, distribution.Mean);
    }

    [Fact]
    public void NormalDistribution_WithMu3SigmaSquared1Point5_HasCorrectVariance()
    {
        var distribution = new NormalDistribution(3, 1.5);
        Assert.Equal(1.5, distribution.Variance);
    }

    [Fact]
    public void NormalDistribution_WithMu3SigmaSquared1Point5_PDF3Point6_Returns0Point2889()
    {
        var distribution = new NormalDistribution(3, 1.5);
        var result = distribution.PDF(3.6);
        Assert.Equal(0.2889, result, 4);
    }
}