using System;

namespace StartergyPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Car car = new Sedan(new Brake());
            Console.WriteLine(car.ToString());
            car.ApplyBrake();
            car = new Suv(new BrakeWithABS());
            Console.WriteLine(car.ToString());
            car.ApplyBrake();
            car.SetStartergy(new Brake());
            Console.WriteLine(car.ToString());
            car.ApplyBrake();
        }
    }

    public interface IBrakeStratergy
    {
        void Brake();
    }

    internal class Brake : IBrakeStratergy
    {
        void IBrakeStratergy.Brake()
        {
            Console.WriteLine("Normal Brake...");
        }
    }

    internal class BrakeWithABS : IBrakeStratergy
    {
        public void Brake()
        {
            Console.WriteLine("Brake with ABS (Anti Braking system)");
        }
    }

    public abstract class Car
    {
        protected IBrakeStratergy brakeStratergy = null;

        public virtual void ApplyBrake()
        {
            brakeStratergy.Brake();
        }

        public void SetStartergy(IBrakeStratergy stratergy)
        {
            brakeStratergy = stratergy;
        }
    }

    public class Sedan : Car
    {
        public Sedan(IBrakeStratergy stratergy)
        {
            brakeStratergy = stratergy;
        }

        public override string ToString()
        {
            return "Sedan";
        }
    }

    public class Suv : Car
    {
        public Suv(IBrakeStratergy stratergy)
        {
            brakeStratergy = stratergy;
        }

        public override string ToString()
        {
            return "Suv";
        }
    }
}