using Exercises___Fundamentals;
using System;
using System.Collections.Generic;

public class program
{
    static void Main(string[] args)
    {

 SuperMarket supermarket = new SuperMarket();
        Product prod = new Product("",8.8);
    
        var listacatalogo = supermarket.ListCatalog();

    }
    

    public class Cinema
    {
        public readonly HashSet<string> _allSeats = BuildAllSeats();
        private readonly Dictionary<string, string> _taken = new();

        public int TotalSeats => _allSeats.Count;

        static HashSet<string> BuildAllSeats()
        {
            var set = new HashSet<string>();
            for (char row = 'A'; row <= 'J'; row++)
                for (int n = 1; n <= 10; n++)
                    set.Add($"{row}{n}");
            return set;
        }

        public bool IsValidSeat(string seatId)
        {
            return _allSeats.Contains(seatId);
        }

        public bool PurchaseTicket(string cpf, string seatId)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;
            if (!IsValidSeat(seatId)) return false;
            if (_taken.ContainsKey(seatId)) return false; // já ocupado
            _taken[seatId] = cpf;
            return true;
        }



    }

    public class Car
    {
        public double Speed { get; set; }                 // km/h
        public double FuelLiters { get; private set; }    // L
        public double ConsumptionKmPerLiter { get; set; } = 12; // km/L
        public int Seats { get; init; } = 5;

        private readonly List<string> _passengers = new();
        public IReadOnlyList<string> Passengers => _passengers;
        public Car(double speed, double fuelLiters)
        {
            Speed = speed;
            FuelLiters = fuelLiters;
        }
        // 1) double: usa properties e retorna cálculo
        public double RangeKm()
        {
            double range = FuelLiters * ConsumptionKmPerLiter;
            return range;
        }

        // 2) bool: recebe parâmetro e decide
        public bool IsSpeeding(int limit)
        {
            bool speeding = Speed > limit;
            return speeding;
        }

        // 3) int: recebe params e retorna total
        public int AddPassengers(params string[] names)
        {
            foreach (var n in names)
            {
                if (!string.IsNullOrWhiteSpace(n) && _passengers.Count < Seats)
                    _passengers.Add(n);
            }
            return _passengers.Count;
        }

        // 4) List<string>: monta lista de avisos com base nas properties
        public List<string> GetAlerts()
        {
            var alerts = new List<string>();
            if (FuelLiters <= 5) alerts.Add("Combustível baixo");
            if (Speed > 120) alerts.Add("Acima de 120 km/h");
            if (_passengers.Count > Seats) alerts.Add("Passageiros além do limite");
            return alerts;
        }

        // 5) (double, int): analisa amostras e retorna média + contagem acima do limite
        public (double average, int aboveLimitCount) AnalyzeSpeeds(List<double> samples, double limit)
        {
            if (samples == null || samples.Count == 0) return (0, 0);
            double sum = 0; int above = 0;
            foreach (var s in samples)
            {
                sum += s;
                if (s > limit) above++;
            }
            double avg = sum / samples.Count;
            return (avg, above);
        }

        // 6) string: descreve o estado atual usando properties e outro método
        public string Describe()
        {
            string text = $"Speed={Speed} km/h, Fuel={FuelLiters:0.##} L, Range≈{RangeKm():0.0} km, Pax={_passengers.Count}/{Seats}";
            return text;
        }

        // 7) static List<Car>: recebe lista por parâmetro e filtra por alcance mínimo
        public static List<Car> FilterByMinRange(List<Car> cars, double minRange)
        {
            var result = new List<Car>();
            foreach (var c in cars)
                if (c.RangeKm() >= minRange) result.Add(c);
            return result;
        }

        // 8) int: compara com outra instância (-1, 0, 1)
        public int CompareSpeed(Car other)
        {
            if (other == null) return 1;
            if (this.Speed < other.Speed) return -1;
            if (this.Speed > other.Speed) return 1;
            return 0;
        }

        // 9) bool + out: tenta consumir combustível; retorna sucesso e “out” com litros usados
        public bool TryConsume(double km, out double fuelUsed)
        {
            fuelUsed = km / ConsumptionKmPerLiter;
            if (fuelUsed <= FuelLiters)
            {
                FuelLiters -= fuelUsed;
                return true;
            }
            return false;
        }

        // 10) double: reabastece e retorna novo nível
        public double Refuel(double liters)
        {
            FuelLiters += liters;
            return FuelLiters;
        }
    }
}