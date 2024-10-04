/* 
    En el mundo de las aves hay pinguinos que pesan 5kg y aguilas que pesando 10kg y vuelan a 100km/h

    Crear una función capaz de escribir las aves y las aves que vuelan y las que no vuelan

    Crear una static class que  implemente los tres metodos
*/

namespace Aves{

    public abstract class Ave {
        public int Peso { get; init; }

        protected Ave(int peso)
        {
            Peso = peso;
        }
    }

    public abstract class AveVoladora : Ave {

        public int Velocidad {get; init;}

        protected AveVoladora (int peso, int velocidad) : base(peso)
        {
            Velocidad = velocidad;
            Peso = peso;
        }
    }

    public abstract class AveNoVoladora : Ave {

        protected AveNoVoladora (int peso) : base(peso)
        {
        }
    }

    public class Aguila : AveVoladora {

        public Aguila (int peso, int velocidad) : base(peso, velocidad)
        {
        }
    }

    public class Pinguino : AveNoVoladora {

        public Pinguino (int peso) : base(peso)
        {
        }
    }

    public static class Printer{

        public static void PrintAve(Ave ave){
            Console.WriteLine($"Ave de {ave.Peso} kg.");
        }

        public static void PrintAveVoladora(AveVoladora aveVoladora){
            Console.WriteLine($"El ave volador de {aveVoladora.Peso} kg, vuela a {aveVoladora.Velocidad} km/h.");
        }

        public static void PrintAveNoVoladora(AveNoVoladora aveNoVoladora){
            Console.WriteLine($"Ave no volador de {aveNoVoladora.Peso} kg.");
        }
    }
}

