using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class BrownResistorBand : IResistorBand
	{
		public string Name => BandColors.Brown;

		public string Code => "BN";

		public string RAL => "8003";

		public int? SignificantFigures => 1;

		public double? Tolerance => 1.0d;

		public int? TemperatureCoefficient => 100;
	}
}
