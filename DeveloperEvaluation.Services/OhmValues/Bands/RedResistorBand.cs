using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class RedResistorBand : IResistorBand
	{
		public string Name => BandColors.Red;

		public string Code => "RD";

		public string RAL => "3000";

		public int? SignificantFigures => 2;

		public double? Tolerance => 2.0d;

		public int? TemperatureCoefficient => 50;
	}
}
