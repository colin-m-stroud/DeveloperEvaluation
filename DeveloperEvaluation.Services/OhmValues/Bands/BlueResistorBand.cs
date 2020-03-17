using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class BlueResistorBand : IResistorBand
	{
		public string Name => BandColors.Blue;

		public string Code => "BU";

		public string RAL => "5015";

		public int? SignificantFigures => 6;

		public double? Tolerance => 0.25;

		public int? TemperatureCoefficient => 10;
	}
}
