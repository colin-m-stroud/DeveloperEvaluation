using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class GreyResistorBand : IResistorBand
	{
		public string Name => BandColors.Gray;

		public string Code => "GY";

		public string RAL => "7000";

		public int? SignificantFigures => 8;

		public double? Tolerance => 0.01d;

		public int? TemperatureCoefficient => 1;
	}
}
