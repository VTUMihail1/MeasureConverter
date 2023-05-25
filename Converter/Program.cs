using Converter.Models.MeasureModels.Abstraction;
using Converter.Models.MeasureModels.Concrete;
using Converter.Services.Abstraction;
using Converter.Services.Concrete;


IMeasureUnit centimeter = new Centimeter() {
	Name = "centimeters", 
	Length = new Length() };

IMeasureUnit meter = new Meter(){ 
	Name = "meter", 
	Length = new Length { 
		MeasureBasedOn = centimeter, Value = 1000f} }; 

IMeasureUnit inch = new Inch(){ 
	Name = "inch", 
	Length = new Length { 
		MeasureBasedOn = meter, Value = 0.00254f } };


IDictionary<string, Length> relationships = new Dictionary<string, Length>();

IMeasureUnitServices services = new MeasureUnitServices(relationships, centimeter);

services.AddMeasureUnit(meter);
services.AddMeasureUnit(inch);

IMeasureConverter converter = new MeasureConverter(services);

Console.WriteLine(converter.Calculate(meter, inch));
Console.WriteLine(converter.Calculate(inch, meter));
Console.WriteLine(converter.Calculate(centimeter, inch));
Console.WriteLine(converter.Calculate(inch, centimeter));
Console.WriteLine(converter.Calculate(meter, centimeter));
Console.WriteLine(converter.Calculate(centimeter, meter));
