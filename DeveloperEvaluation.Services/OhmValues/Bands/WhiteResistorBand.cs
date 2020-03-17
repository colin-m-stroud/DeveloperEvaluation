using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class WhiteResistorBand : IResistorBand
	{
		public string Name => BandColors.White;

		public string Code => "WH";

		public string RAL => "1013";

		public int? SignificantFigures => 9;

		public double? Tolerance => default;

		public int? TemperatureCoefficient => default;
	}
}
