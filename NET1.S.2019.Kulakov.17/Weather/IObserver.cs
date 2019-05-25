namespace WeatherSpace
{
    using System;

    public interface IObserver
    {
        void Update(IObservable sender, EventArgs info);
    }
}
