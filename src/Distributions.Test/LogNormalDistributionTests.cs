namespace Distributions.Test;

public class LogNormalDistributionTests
{
    [Fact]
    public void Constructor_WithInvalidSigmaSquared_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new LogNormalDistribution(0, 0));
        Assert.Throws<ArgumentException>(() => new LogNormalDistribution(0, -1));
    }

    [Fact]
    public void PDF_WithValueLessThanZero_ThrowsArgumentException()
    {
        var distribution = new LogNormalDistribution(3, 1.5);
        Assert.Throws<ArgumentException>(() => distribution.PDF(-1));
        Assert.Throws<ArgumentException>(() => distribution.PDF(0));
    }

    [Fact]
    public void LogNormalDistribution_WithMu3SigmaSquared1Point5_HasCorrectMean()
    {
        var distribution = new LogNormalDistribution(3, 1.5);
        var result = distribution.Mean;
        Assert.Equal(42.5211, result, 4);
    }

    [Fact]
    public void LogNormalDistribution_WithMu3SigmaSquared1Point5_HasCorrectVariance()
    {
        var distribution = new LogNormalDistribution(3, 1.5);
        var result = distribution.Variance;
        Assert.Equal(6295.0415, result, 4);
    }

    [Fact]
    public void LogNormalDistribution_WithMu3SigmaSquared1Point5_PDF3Point6_Returns0Point0338()
    {
        var distribution = new LogNormalDistribution(3, 1.5);
        var result = distribution.PDF(3.6);
        Assert.Equal(0.0338, result, 4);
    }
}