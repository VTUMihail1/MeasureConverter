using Converter.Models.MeasureModels.Abstraction;

namespace Converter.Services.Abstraction
{
	public interface IMeasureConverter
	{
		public float Calculate(IMeasureUnit measureUnit, IMeasureUnit wantedMeasureUnit);
	}

}
