using Converter.Models.MeasureModels.Abstraction;

namespace Converter.Models.MeasureModels.Concrete
{
	public class Meter : IMeasureUnit
	{
		public string Name { get; set; }

		public Length Length { get; set; }
	}

}
