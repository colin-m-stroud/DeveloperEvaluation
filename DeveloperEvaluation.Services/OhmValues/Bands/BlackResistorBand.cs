using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class BlackResistorBand : IResistorBand
	{
		public string Name => BandColors.Black;

		public string Code => "BK";

		public string RAL => "9005";

		public int? SignificantFigures => 0;

		public double? Tolerance => null;

		public int? TemperatureCoefficient => 250;
	}
}
