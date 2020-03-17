using System;

namespace DeveloperEvaluation.Common
{
	public interface ICalculateOhmValues
    {
		/// <summary>
		/// Calculates the Ohm value of a resistor based on the band colors.
		/// </summary>
		/// <param name="bandAColor">The color of the first figure of component value band.</param>
		/// <param name="bandBColor">The color of the second significant figure band.</param>
		/// <param name="bandCColor">The color of the decimal muliplier band.</param>
		/// <param name="bandDColor">The color of the tolerance value band.</param>
		/// <exception cref="ArgumentNullException"><paramref name="bandAColor"/> is null.</exception>
		/// <exception cref="InvalidOperationException">
		/// <paramref name="bandAColor"/>Is not black AND either:
		///		1. <paramref name="bandBColor"/> is null OR
		///		2. <paramref name="bandCColor"/> is null
		/// </exception>
		/// <returns>
		/// A <see langword="Touple{double lower,double upper}"> representing the lower and upper bounds of the resistor's in Ohms
		/// </returns>
		(double ohmValue, double tolerance) CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);

		/// <summary>
		/// Calculates the Ohm value of a resistor based on the band colors.
		/// </summary>
		/// <param name="bandAColor">An instance of IResistorBand representing the of the first significant figure of component value (left side).</param>
		/// <param name="bandBColor">An instance of IResistorBand representing the color of the second significant figure of component value.</param>
		/// <param name="bandCColor">An instance of IResistorBand representing the color of the decimal muliplier band (number of trailing zeroes).</param>
		/// <param name="bandDColor">An instance of IResistorBand representing the color of the tolerance value band in percent (no band means 20%).</param>
		/// <exception cref="ArgumentNullException"><paramref name="bandAColor"/> is null.</exception>
		/// <exception cref="InvalidOperationException">
		/// <paramref name="bandAColor"/>Is not black AND either:
		///		1. <paramref name="bandBColor"/> is null OR
		///		2. <paramref name="bandCColor"/> is null
		/// </exception>
		/// <returns>
		/// A <see langword="Touple{double lower,double upper}"> representing the lower and upper bounds of the resistor's in Ohms
		/// </returns>
		public static (double ohmValue, double tolerance) CalculateOhmValue(
			IResistorBand firstSignificantDigitBand,
			IResistorBand secondSignificantDigitBand,
			IResistorBand decimalMultiplierBand,
			IResistorBand percentToleranceBand)
		{
			if (firstSignificantDigitBand == null)
				throw new ArgumentNullException($"Parameter {nameof(firstSignificantDigitBand)} can not be null.");

			if (firstSignificantDigitBand?.Name != BandColors.Black)
			{
				var notBlackError = $"can not be null if {nameof(firstSignificantDigitBand)} is not {nameof(BandColors.Black)}";

				if (secondSignificantDigitBand == null)
					throw new InvalidOperationException($"Parameter {nameof(secondSignificantDigitBand)} {notBlackError}");

				if (decimalMultiplierBand == null)
					throw new InvalidOperationException($"Parameter {nameof(decimalMultiplierBand)} {notBlackError}");
			}
			else if (secondSignificantDigitBand?.Name == BandColors.None)
			{
				// NOTE: This is a special case for 0 Ohm resistors used in PCBs, for more information see:
				// Electronic Color Codes: https://en.wikipedia.org/wiki/Electronic_color_code#cite_ref-NZO_NIC_12-0
				// Zero Ohm Resistors: https://en.wikipedia.org/wiki/Zero_ohm_resistor
				return (ohmValue: IResistorBand.DefaultSignificantFigures,
						tolerance: IResistorBand.DefaultSignificantFigures);
			}

			int firstDigit = (int)firstSignificantDigitBand.SignificantFigures;
			int secondDigit = (int)secondSignificantDigitBand.SignificantFigures;
			double multiplier = (double)decimalMultiplierBand.SignificantFigures;
			double toleranceValue = percentToleranceBand?.Tolerance ?? IResistorBand.DefaultTolerancePercent;

			double ohmValue = firstDigit * 10d
							+ secondDigit;
			ohmValue *= Math.Pow(10.0d, multiplier);

			return (ohmValue: ohmValue,
					tolerance: toleranceValue);
		}
	}
}
