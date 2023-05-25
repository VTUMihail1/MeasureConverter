using Converter.Models.MeasureModels.Concrete;

namespace Converter.Models.MeasureModels.Abstraction
{
	public interface IMeasureUnit
	{
		string Name { get; }

		Length Length { get; }
	}

}
