using Converter.Models.MeasureModels.Abstraction;

namespace Converter.Models.MeasureModels.Concrete
{
    public class Centimeter : IMeasureUnit
	{
		public string Name { get; set; }

		public Length Length { get; set; }
	}

}
