using LeilaoOnline;
using System.Reflection;
using Xunit;

namespace LeiLaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250})]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino, double valorEsperado, double[] ofertas)
        {
            //Arraje - cenário
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert - espectativa do teste 
            var valorObitido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObitido);

        }

        //se quiser passar dados de entrada 
        [Theory]
        //passando dados de entrada 
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(800, new double[] { 800})]
        public void RetornaMaiorValorDadoLeilaoComPelomenosUmLance(double valorEsperado, double[] ofertas)
        {
            //Arraje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert - espectativa do teste 
            var valorObitido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObitido);

            //Console.WriteLine(leilao.Ganhador.Valor);


        }

        [Fact]
        public void LancaInvalidOperationDadoPregaoNaoIniciado()
        {
            //Arraje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            //Testando exception
            var excecaoObitida = Assert.Throws<System.InvalidOperationException>(
                       () =>leilao.TerminaPregao()  
            );

            var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado. Utilize o método IniciaPregão()";
            Assert.Equal(msgEsperada, excecaoObitida.Message);

            //try
            //{
            //    //Act - método sob teste
            //    leilao.TerminaPregao();
            //    Assert.True(false);
            //}
            //catch (System.Exception ex)
            //{
            //    //Assert 
            //    Assert.IsType<System.InvalidOperationException>(ex);
            //}

        }

        //se não importar qual dado eu vou colocar a expectativa for sempre a mesma 
        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arraje - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            leilao.IniciaPregao();

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObitido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObitido);

            //Console.WriteLine(leilao.Ganhador.Valor);
        }

        //convenção de nome de teste dividido em três partes 
        //qual o metodo que esta sendo testado
        //quais são as condições de entrada 
        //qual a expectativa para aqule metodo comportamento 


    }
}
