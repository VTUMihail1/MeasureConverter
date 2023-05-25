using Converter.Models.MeasureModels.Abstraction;

namespace Converter.Services.Abstraction
{
	public interface IMeasureUnitServices
	{
		void AddMeasureUnit(IMeasureUnit measureUnit);

		void UpdateMeasureUnit(IMeasureUnit measureUnit);

		void RemoveMeasureUnit(IMeasureUnit measureUnit);

		float GetMeasure(IMeasureUnit measureUnit);
	}

}
