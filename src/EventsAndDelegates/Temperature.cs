namespace EventsAndDelegates;

public class Temperature
{
    public TemperatureScales Scale { get; init; }
    public float Value { get; init; }

    public Temperature(TemperatureScales scale, float value)
    {
        Scale = scale;
        Value = value;
    }

    public float ToCelsius()
    {
        if (Scale == TemperatureScales.Celsius)
            return Value;
        if (Scale == TemperatureScales.Fahrenheit)
            return (Value - 32) * 5 / 9;
        if (Scale == TemperatureScales.Kelvin)
            return Value - 273.15f;

        return Value;
    }

    public override string ToString()
    {
        return $"{Value} {Scale}";
    }
}
