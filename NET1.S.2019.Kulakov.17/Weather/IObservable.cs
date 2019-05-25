﻿namespace WeatherSpace
{
    public interface IObservable
    {
        void Register(IObserver observer);

        void Unregister(IObserver observer);

        void Notify();
    }
}
