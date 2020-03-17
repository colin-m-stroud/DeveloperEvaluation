using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class GreenResistorBand : IResistorBand
	{
		public string Name => BandColors.Green;

		public string Code => "GN";

		public string RAL => "6018";

		public int? SignificantFigures => 5;

		public double? Tolerance => 0.5d;

		public int? TemperatureCoefficient => 20;
	}
}
