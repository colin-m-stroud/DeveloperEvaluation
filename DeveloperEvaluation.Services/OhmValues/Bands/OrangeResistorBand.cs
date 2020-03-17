using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class OrangeResistorBand : IResistorBand
	{
		public string Name => BandColors.Orange;

		public string Code => "OG";

		public string RAL => "2003";

		public int? SignificantFigures => 3;

		public double? Tolerance => 0.05d;

		public int? TemperatureCoefficient => 15;
	}
}
