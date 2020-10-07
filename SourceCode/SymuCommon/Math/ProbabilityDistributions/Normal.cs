#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using System;

#endregion

namespace Symu.Common.Math.ProbabilityDistributions
{
    /// <summary>
    ///     a normal (or Gaussian or Gauss or Laplace–Gauss) distribution is a type of continuous probability distribution for
    ///     a real-valued random variable
    ///     he parameter mu  is the mean or expectation of the distribution (and also its median and mode);
    ///     and sigma  is its standard deviation.
    ///     The variance of the distribution is sigma ^2.
    ///     A random variable with a Gaussian distribution is said to be normally distributed and is called a normal deviate.
    /// </summary>
    /// <remarks>Encapsulation of Math.Net.Bernoulli : https://numerics.mathdotnet.com/Probability.html</remarks>
    public static class Normal
    {
        /// <summary>
        ///     Generates a sample from the normal distribution using the Box-Muller algorithm.
        /// </summary>
        /// <param name="mean">The mean (μ) of the normal distribution.</param>
        /// <param name="stdDev">The standard deviation (σ) of the normal distribution. Range: σ ≥ 0.</param>
        /// <returns>a sample from the distribution.</returns>
        public static float Sample(float mean, float stdDev)
        {
            return System.Math.Abs(stdDev) < Constants.Tolerance
                ? mean
                : Convert.ToSingle(MathNet.Numerics.Distributions.Normal.Sample(mean, stdDev));
        }

        /// <summary>
        ///     Generates a sample from the normal distribution using the Box-Muller algorithm.
        /// </summary>
        /// <param name="mean">The mean (μ) of the normal distribution.</param>
        /// <param name="stdDev">The standard deviation (σ) of the normal distribution. Range: σ ≥ 0.</param>
        /// <param name="lowerBound"></param>
        /// <returns>a sample from the distribution always superior to lowerBound</returns>
        public static float SampleWithLowerBound(float mean, float stdDev, float lowerBound)
        {
            return System.Math.Max(lowerBound, Sample(mean, stdDev));
        }
    }
}