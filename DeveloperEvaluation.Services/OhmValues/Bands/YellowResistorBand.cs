using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class YellowResistorBand : IResistorBand
	{
		public string Name => BandColors.Yellow;

		public string Code => "YE";

		public string RAL => "1021";

		public int? SignificantFigures => 4;

		public double? Tolerance => 0.02d;

		public int? TemperatureCoefficient => 25;
	}
}
