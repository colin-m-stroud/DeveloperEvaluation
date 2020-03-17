using DeveloperEvaluation.Common;

namespace DeveloperEvaluation.Services.OhmValues
{
	public class PinkResistorBand : IResistorBand
	{
		public string Name => BandColors.Pink;

		public string Code => "PK";

		public string RAL => "3015";

		public int? SignificantFigures => -3;

		public double? Tolerance => default;

		public int? TemperatureCoefficient => default;
	}
}
