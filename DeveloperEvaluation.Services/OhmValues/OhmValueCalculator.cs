using DeveloperEvaluation.Common;
using System;

namespace DeveloperEvaluation.Services.OhmValues
{
	/// <summary>
	/// The electronic color code is used to indicate the values of ratings of electronic components. 
	/// Most often, this system is used for thru-hole resistors. 
	/// <see cref="https://en.wikipedia.org/wiki/Electronic_color_code#Resistors"/>
	/// </summary>
	public class OhmValueCalculator : ICalculateOhmValues
	{
		/// <summary>
		/// Gets a set of resistor band values based on the band's color
		/// </summary>
		/// <param name="color">The color of the resistor band (ex: Red, Brown, etc.)</param>
		/// <returns>The set of resistor values associated with the resistor band color</returns>
		public IResistorBand GetBandDataByColor(string color)
		{
			switch (color)
			{
				default:
				case nameof(BandColors.Default):	return new DefaultResistorBand();
				case nameof(BandColors.Black):		return new BlackResistorBand();
				case nameof(BandColors.Blue):		return new BlueResistorBand();
				case nameof(BandColors.Brown):		return new BrownResistorBand();
				case nameof(BandColors.Gold):		return new GoldResistorBand();
				case nameof(BandColors.Green):		return new GreenResistorBand();
				case nameof(BandColors.Gray):		return new GreyResistorBand();
				case nameof(BandColors.Orange):		return new OrangeResistorBand();
				case nameof(BandColors.Pink):		return new PinkResistorBand();
				case nameof(BandColors.Red):		return new RedResistorBand();
				case nameof(BandColors.Silver):		return new SilverResistorBand();
				case nameof(BandColors.Violet):		return new VioletResistorBand();
				case nameof(BandColors.White):		return new WhiteResistorBand();
				case nameof(BandColors.Yellow):		return new YellowResistorBand();
			}
		}

		/// <summary>
		/// Calculates the Ohm value of a resistor based on the band colors.
		/// </summary>
		/// <param name="bandAColor">The color of the first significant figure of component value (left side).</param>
		/// <param name="bandBColor">The color of the second significant figure of component value.</param>
		/// <param name="bandCColor">The color of the decimal muliplier band (number of trailing zeroes).</param>
		/// <param name="bandDColor">The color of the tolerance value band in percent (no band means 20%).</param>
		/// <exception cref="InvalidOperationException">
		/// 1. <paramref name="bandAColor"/> is null. OR
		/// 2. <paramref name="bandAColor"/>Is not "Black" AND either:
		///		<paramref name="bandBColor"/> is null OR
		///		<paramref name="bandCColor"/> is null
		/// </exception>
		/// <returns>
		/// A <see langword="Touple{double lower,double upper}"> representing the lower and upper bounds of the resistor's in Ohms
		/// </returns>
		public (double ohmValue, double tolerance) CalculateOhmValue(
			string bandAColor, 
			string bandBColor, 
			string bandCColor, 
			string bandDColor)
		{
			
			var bandAData = GetBandDataByColor(bandAColor);
			var bandBData = GetBandDataByColor(bandBColor);
			var bandCData = GetBandDataByColor(bandCColor);
			var bandDData = GetBandDataByColor(bandDColor);
			var toleranceRanges = ICalculateOhmValues.CalculateOhmValue(
				bandAData,
				bandBData,
				bandCData,
				bandDData
			);

			return toleranceRanges;
		}
	}
}
