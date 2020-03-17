namespace DeveloperEvaluation.Common
{
	public interface IResistorBand
	{
		static int DefaultSignificantFigures => 0;
		static double DefaultTolerancePercent => 20.0d;

		/// <summary>
		/// The common name for the color (ex: Pink, Silver, Black, etc.)
		/// </summary>
		string Name { get; }
		/// <summary>
		/// The two digit electronic color code
		/// </summary>
		string Code { get; }
		/// <summary>
		/// The value of the RAL color matching standard (used in Europe)
		/// </summary>
		string RAL { get; }
		/// <summary>
		/// The decimal multiplier (number of trailing zeroes)
		/// </summary>
		int? SignificantFigures { get; }
		/// <summary>
		/// Indicates tolerance of value in percent
		/// </summary>
		double? Tolerance { get; }
		/// <summary>
		/// The temperature coefficient which describes the relative change of a 
		/// resistor's temperature in units of ppm/K.
		/// </summary>
		int? TemperatureCoefficient { get; }
	}
}
