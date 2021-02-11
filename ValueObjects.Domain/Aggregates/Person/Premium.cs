using System;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class Premium
    {
        private static readonly float _USDZARExchange = 14.62f;
        private static readonly float _EURZARExchange = 17.74f;
        private static readonly float _GBPZARExchange = 20.19f;

        private readonly float _amountZAR;

        private Premium(float amountZAR)
        {
            if (amountZAR < 0f)
                throw new Exception("Invalid premium amount");
            _amountZAR = amountZAR;
        }

        public float AsZAR() => _amountZAR;
        public float AsUSD() => _amountZAR / _USDZARExchange;
        public float AsEUR() => _amountZAR / _EURZARExchange;
        public float AsGBP() => _amountZAR / _GBPZARExchange;

        public static Premium OfZAR(float amountZAR)
        {
            return new Premium(amountZAR);
        }

        public static Premium OfUSD(float amountUSD)
        {
            return new Premium(amountUSD * _USDZARExchange);
        }
    }
}




