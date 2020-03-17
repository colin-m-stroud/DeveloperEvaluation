using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class DefaultResistorBand : IResistorBand
	{
		public string Name => BandColors.None;

		public string Code => "-";

		public string RAL => "-";

		public int? SignificantFigures => default;

		public double? Tolerance => 20.0d;

		public int? TemperatureCoefficient => default;
	}
}
