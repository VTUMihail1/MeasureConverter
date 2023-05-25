using Converter.Models.MeasureModels.Abstraction;
using Converter.Services.Abstraction;

namespace Converter.Services.Concrete
{
	public class MeasureConverter : IMeasureConverter
	{
		private readonly IMeasureUnitServices _measureUnitServices;

		public MeasureConverter(IMeasureUnitServices measureUnitServices)
		{
			_measureUnitServices = measureUnitServices;
		}

		public float Calculate(IMeasureUnit measureUnit, IMeasureUnit wantedMeasureUnit)
		{
			var firstValue = _measureUnitServices.GetMeasure(measureUnit);
			var secondValue = _measureUnitServices.GetMeasure(wantedMeasureUnit);

			var relationship = firstValue / secondValue;

			return relationship;
		}

	}

}
