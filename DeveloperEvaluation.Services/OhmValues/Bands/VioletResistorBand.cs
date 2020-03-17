using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class VioletResistorBand : IResistorBand
	{
		public string Name => BandColors.Violet;

		public string Code => "VT";

		public string RAL => "4005";

		public int? SignificantFigures => 7;

		public double? Tolerance => 0.1d;

		public int? TemperatureCoefficient => 5;
	}
}
