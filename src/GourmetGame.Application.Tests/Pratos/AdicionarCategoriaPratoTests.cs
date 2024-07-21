using FluentAssertions;
using GourmetGame.Application.Pratos.Commands.AdicionarCategoriaPrato;
using GourmetGame.Application.Pratos.Repositories;
using NSubstitute;

namespace GourmetGame.Application.Tests.Pratos
{
    public class AdicionarCategoriaPratoTests
    {
        [Fact(DisplayName = "Deve retornar erro quando a CategoriaAssociada informada não existir.")]
        public async Task Deve_Retornar_Erro_Quando_A_CategoriaAssociada_Informada_Nao_Existir()
        {
            // Arrange            
            var command = new AdicionarCategoriaPratoCommand()
            {
                CategoriaAssociadaId = int.MinValue,
                NomeCategoria = "Cereal",
                NomePrato = "Arroz"
            };

            var repository = Substitute.For<ICategoriaPratoRepository>();
            repository.CategoriaPratoExistsAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).Returns(false);

            var handler = new AdicionarCategoriaPratoCommandHandler(repository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.HasSuccess.Should().BeFalse();
            result.Errors.Should().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "Não deve retornar erro quando a CategoriaAssociada informada existir.")]
        public async Task Nao_Deve_Retornar_Erro_Quando_A_CategoriaAssociada_Informada_Existir()
        {
            // Arrange            
            var command = new AdicionarCategoriaPratoCommand()
            {
                CategoriaAssociadaId = int.MinValue,
                NomeCategoria = "Cereal",
                NomePrato = "Arroz"
            };

            var repository = Substitute.For<ICategoriaPratoRepository>();
            repository.CategoriaPratoExistsAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).Returns(true);

            var handler = new AdicionarCategoriaPratoCommandHandler(repository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.HasSuccess.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [Fact(DisplayName = "Deve retornar erro quando a o nome do prato informado existir para outro prato.")]
        public async Task Deve_Retornar_Erro_Quando_O_Nome_Do_Prato_Informado_Ja_Existir()
        {
            // Arrange            
            var command = new AdicionarCategoriaPratoCommand()
            {
                NomeCategoria = "Cereal",
                NomePrato = "Arroz"
            };

            var repository = Substitute.For<ICategoriaPratoRepository>();
            repository.IsNomePratoJaUtilizadoAsync(Arg.Any<string>(), Arg.Any<CancellationToken>()).Returns(true);

            var handler = new AdicionarCategoriaPratoCommandHandler(repository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.HasSuccess.Should().BeFalse();
            result.Errors.Should().NotBeNullOrEmpty();
        }
        
        [Fact(DisplayName = "Não deve retornar erro quando a o nome do prato informado não existir para outro prato.")]
        public async Task Nao_Deve_Retornar_Erro_Quando_O_Nome_Do_Prato_Informado_Ainda_Nao_Existir()
        {
            // Arrange            
            var command = new AdicionarCategoriaPratoCommand()
            {
                NomeCategoria = "Cereal",
                NomePrato = "Arroz"
            };

            var repository = Substitute.For<ICategoriaPratoRepository>();
            repository.IsNomePratoJaUtilizadoAsync(Arg.Any<string>(), Arg.Any<CancellationToken>()).Returns(false);

            var handler = new AdicionarCategoriaPratoCommandHandler(repository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.HasSuccess.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
