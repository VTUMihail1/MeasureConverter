using Converter.Models.MeasureModels.Abstraction;

namespace Converter.Models.MeasureModels.Concrete
{
	public class Length
	{
        public float Value { get; set; }
		public IMeasureUnit MeasureBasedOn { get; set; }
	}

}
