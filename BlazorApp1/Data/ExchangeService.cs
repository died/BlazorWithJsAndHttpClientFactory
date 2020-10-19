
namespace BlazorApp1.Data
{
    public class ExchangeService
    {
        private readonly IFxbitService _fxbit;
        public ExchangeService(IFxbitService fxbit)
        {
            _fxbit = fxbit;
        }

        public string GetRawRate()
        {
            return _fxbit.RateRaw;
        }

        public FxbitExchangeRate GetExchangeRate(string curFrom, string curTo)
        {
            var rate = new FxbitExchangeRate();
            var dict = _fxbit.RateDict;
            if (dict.ContainsKey(curFrom) && dict[curFrom].ContainsKey(curTo))
                rate = dict[curFrom][curTo];
            return rate;
        }
    }
}
