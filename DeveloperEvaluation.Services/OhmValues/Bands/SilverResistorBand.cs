using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class SilverResistorBand : IResistorBand
	{
		public string Name => BandColors.Silver;

		public string Code => "SR";

		public string RAL => "-";

		public int? SignificantFigures => -2;

		public double? Tolerance => 10.0d;

		public int? TemperatureCoefficient => default;
	}
}
