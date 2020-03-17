using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class GoldResistorBand : IResistorBand
	{
		public string Name => BandColors.Gold;

		public string Code => "GD";

		public string RAL => "-";

		public int? SignificantFigures => -1;

		public double? Tolerance => 5.0d;

		public int? TemperatureCoefficient => default;
	}
}
