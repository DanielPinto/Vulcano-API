// using Vulcano.Application.DTOs;
// using Vulcano.Application.UseCases.CreateEquipment;
// using Vulcano.Domain.Entities;
// using Vulcano.Domain.Exceptions;
// using Vulcano.Domain.Interfaces;

// namespace Vulcano.Tests.Application.UseCases.CreateEquipment;

// // fora da classe de teste
// public class FakeRepository : IEquipmentRepository
// {
//     public List<Equipment> Equipments { get; } = [];

//     public Task AddAsync(Equipment equipment)
//     {
//         Equipments.Add(equipment);
//         return Task.CompletedTask;
//     }

//     public Task<IEnumerable<Equipment>> GetAllAsync()
//     {
//         return Task.FromResult(Equipments.AsEnumerable());
//     }

//     public Task<Equipment?> GetByIdAsync(Guid id)
//     {
//         throw new NotImplementedException();
//     }

//     public Task UpdateAsync(Equipment equipment)
//     {
//         throw new NotImplementedException();
//     }
// }


// public class CreateEquipmentHandlerTests
// {
    

//     [Fact]
//     public async Task Should_Add_Equipment_When_Data_Is_Valid()
//     {
//         // Arrange
//         var repo = new FakeRepository();
//         var handler = new CreateEquipmentHandler(repo);

//         var dto = new CreateEquipmentDto
//         {
//             Name = "Impressora HP",
//             SerialNumber = "HP123456",
//             Type = "Impressora",
//             PurchaseDate = DateTimeOffset.Now
//         };

//         // Act
//         await handler.HandleAsync(dto);

//         // Assert
//         Assert.Single(repo.Equipments);
//         Assert.Equal("HP123456", repo.Equipments[0].SerialNumber.ToString());
//     }

//     [Fact]
//     public async Task Should_Throw_Exception_When_SerialNumber_AlreadyExists()
//     {
//         // Arrange
//         var repo = new FakeRepository();
//         var handler = new CreateEquipmentHandler(repo);

//         var dto1 = new CreateEquipmentDto
//         {
//             Name = "Notebook Dell",
//             SerialNumber = "D1234",
//             Type = "Notebook",
//             PurchaseDate = DateTime.Today
//         };

//         var dto2 = new CreateEquipmentDto
//         {
//             Name = "Outro Dell",
//             SerialNumber = "D1234", // Duplicado
//             Type = "Notebook",
//             PurchaseDate = DateTime.Today
//         };

//         await handler.HandleAsync(dto1);

//         // Act & Assert
//         var ex = await Assert.ThrowsAsync<EquipmentAlreadyExistsException>(() => handler.HandleAsync(dto2));
//         Assert.Equal("Já existe um equipamento com o número de série 'D1234'.", ex.Message);
//     }
// }