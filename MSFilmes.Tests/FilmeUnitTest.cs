using DomainApiFilmes.DesafioTecnico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Xunit;

namespace MSFilmes.Tests
{
    [TestClass]
    public class FilmeUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [Fact]
        public void ValidaCadastroDeFilme()
        {
            var comando = new FilmeDto()
            {
                Ativo = true,
                DataDeCriacao = DateTime.Now,
                //GeneroDoFilme = new GeneroDto()
                //{
                //    Nome = "Ação",
                //    Ativo = true,
                //    DataDeCriacao = DateTime.Now
                //},
                Nome = "Novo filme teste",
                GeneroId = 1
            };

            //var mock = new Mock<>
        }
    }
}