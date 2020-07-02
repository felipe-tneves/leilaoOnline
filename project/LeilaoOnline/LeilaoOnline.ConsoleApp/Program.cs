using System;
using System.Runtime.InteropServices;
using LeilaoOnline;

namespace LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TESTE FALHOU! Esperado: {esperado}, Obtido: {obtido}");
            }
            Console.ForegroundColor = cor;
        }
        private static void LeilaoComVariosLances()
        {
            //Arraje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObitido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObitido);

            //Console.WriteLine(leilao.Ganhador.Valor);

        
    }
        private static void LeiLaoComApenasUmLance()
        {
            //Arraje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            

            leilao.RecebeLance(fulano, 800);
            

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObitido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObitido);

            //Console.WriteLine(leilao.Ganhador.Valor);
        }
        static void Main()
        {
            LeilaoComVariosLances();
            LeiLaoComApenasUmLance();
        }
    }
}
