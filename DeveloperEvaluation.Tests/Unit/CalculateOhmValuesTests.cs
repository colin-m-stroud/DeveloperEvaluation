using DeveloperEvaluation.Common;
using DeveloperEvaluation.Services.OhmValues;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DeveloperEvaluation.Tests.Unit
{
	[TestFixture]
	public class CalculateOhmValuesTests
	{
		#region Failure Case Tests

		[TestCase("Blue", Category = "Invalid Single Band Colors")]
		[TestCase("Brown", Category = "Invalid Single Band Colors")]
		[TestCase("Default", Category = "Invalid Single Band Colors")]
		[TestCase("Gold", Category = "Invalid Single Band Colors")]
		[TestCase("Green", Category = "Invalid Single Band Colors")]
		[TestCase("Grey", Category = "Invalid Single Band Colors")]
		[TestCase("None", Category = "Invalid Single Band Colors")]
		[TestCase("Orange", Category = "Invalid Single Band Colors")]
		[TestCase("Pink", Category = "Invalid Single Band Colors")]
		[TestCase("Red", Category = "Invalid Single Band Colors")]
		[TestCase("Silver", Category = "Invalid Single Band Colors")]
		[TestCase("Violet", Category = "Invalid Single Band Colors")]
		[TestCase("White", Category = "Invalid Single Band Colors")]
		[TestCase("Yellow", Category = "Invalid Single Band Colors")]
		[TestCase("Black", null, "Blue", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Brown", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Default", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Gold", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Green", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Grey", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "None", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Orange", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Pink", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Red", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Silver", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Violet", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "White", Category = "Null Second Significant Digit")]
		[TestCase("Black", null, "Yellow", Category = "Null Second Significant Digit")]
		[TestCase("Black", "Blue", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Brown", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Default", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Gold", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Green", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Grey", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "None", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Orange", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Pink", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Red", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Silver", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Violet", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "White", null, Category = "Null Multiplier Values")]
		[TestCase("Black", "Yellow", null, Category = "Null Multiplier Values")]
		public void CalculateOhmValues_WhenInvalidSetOfColorsProvided_ThrowsInvalidOperationException(
			string bandAColor,
			string bandBColor = null,
			string bandCColor = null)
		{
			// Arrange
			var ohmValueCalculator = new OhmValueCalculator();

			// Act
			Action testCalculatorAction = () => ohmValueCalculator.CalculateOhmValue(
				bandAColor,
				bandBColor,
				bandCColor,
				null);

			// Assert
			testCalculatorAction.Should().Throw<InvalidOperationException>(because: $"Values of: BandA = {bandAColor}, BandB = {bandBColor}, BandC = {bandCColor} is invalid.");
		}

		#endregion

		#region Happy Path Tests
		
		[TestCase]
		public void CalculateOhmValues_WhenResistorIsZeroOhmResistor_ShouldReturnZeroLowerAndUpperBounds()
		{
			// Arrange
			var ohmValueCalculator = new OhmValueCalculator();

			// Act
			var ohmValue = ohmValueCalculator.CalculateOhmValue(
				BandColors.Black,
				null,
				null,
				null);

			// Assert
			ohmValue.Should().Be((0.0d, 0.0d));
		}

		[TestCase("Red", "Red", "Orange", "Gold", 22000.0d, 5.0d, Category ="Valid Color Values")]
		[TestCase("Yellow", "Violet", "Brown", "Gray", 470.0d, 0.01d, Category ="Valid Color Values")]
		[TestCase("Blue", "Gray", "Black", "Violet", 68.0d, 0.1d, Category ="Valid Color Values")]
		[TestCase("Brown", "Black", "Yellow", null, 100000.0d, 20.0d, Category ="Valid Color Values")]
		[TestCase("Green", "Blue", "Brown", "Silver", 560.0d, 10.0d, Category ="Valid Color Values")]
		[TestCase("Brown", "Gray", "Yellow", "Brown", 180000.0d, 1.0d, Category ="Valid Color Values")]
		[TestCase("Orange", "White", "Black", "Red", 39.0d, 2.0d, Category ="Valid Color Values")]
		[TestCase("Brown", "Gray", "Brown", "Orange", 180.0d, 0.05d, Category ="Valid Color Values")]
		[TestCase("Orange", "White", "Red", "Blue", 3900.0d, 0.25d, Category ="Valid Color Values")]
		[TestCase("Yellow", "Violet", "Orange", "Green", 47000.0d, 0.5d, Category ="Valid Color Values")]
		[TestCase("Brown", "Black", "Green", "Yellow", 1000000.0d, 0.02d, Category ="Valid Color Values")]
		public void CalculateOhmValues_WhenColorsAreValid_ShouldReturnExpectedTolerance(
			string bandAColor,
			string bandBColor,
			string bandCColor,
			string bandDColor,
			double expectedOhmValue, 
			double expectedTolerance
		)
		{
			// Arrange
			var ohmValueCalculator = new OhmValueCalculator();

			// Act
			var ohmValue = ohmValueCalculator.CalculateOhmValue(
				bandAColor,
				bandBColor,
				bandCColor,
				bandDColor);

			// Assert
			ohmValue.Should().Be((expectedOhmValue, expectedTolerance));
		}

		#endregion
	}
}
