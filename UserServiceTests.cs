using Xunit;
using Moq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs.UserDtos;
using movie_rating_backend.Services.Implementations;
using movie_rating_backend.Mappings;
using System;
using System.Threading.Tasks;
using movie_rating_backend.Helpers;

namespace movie_rating_backend.test
{
    public class UserServiceTests
    {
        //[Theory]
        //[InlineData("user1")]
        //[InlineData("user2")]
        //[InlineData("user3")]

         [Fact]
        public async Task DeleteUserByUsername_Deletes_Correct_User()//string username)
        {
            
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var context = new AppDbContext(options);
            {
                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "user1",
                    Email = "user1@example.com",
                    Password = "password1"
                });

                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "user2",
                    Email = "user2@example.com",
                    Password = "password2"
                });

                context.SaveChanges();
            }



            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMapperProfile());
            });
            var mapper = config.CreateMapper();

            var service = new UserService(context, mapper, new TokenGenerator(null));


            var delete = await service.DeleteUserByUsername("user1");


            Assert.True(delete);
            var user = await service.GetUserByUsername("user1");
            Assert.Null(user);


        }

        [Fact]
        public async Task Add_User_Should_Add_User_ToDb()
        {
            
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

                var context = new AppDbContext(options);
            
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new UserMapperProfile());
                });
                var mapper = config.CreateMapper();

                var userService = new UserService(context, mapper, new TokenGenerator(null));

                var userDto = new CreateUserDto
                {
                    Username = "Test",
                    Password = "1234",
                    Email = "test@example.com"
                };

                
                var createdUserDto = await userService.CreateUser(userDto);

                var getAll = await userService.GetAllUsers();

                //Assert.NotNull(createdUserDto);

                Assert.Equal("Test", createdUserDto.Username);
                Assert.Single(getAll);

                
              
            }

        [Fact]
        public async Task Update_User_By_Username_Should_Update_User_Details()
        {
            
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var context = new AppDbContext(options);
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new UserMapperProfile());
                });
                var mapper = config.CreateMapper();

                

               
                var initialUser = new User
                {
                    Id = Guid.NewGuid(),
                    Username = "initialUser",
                    Password = "initialPassword",
                    Email = "initialEmail"
                };
                context.Users.Add(initialUser);
                await context.SaveChangesAsync();

                
                var updateUserDto = new CreateUserDto
                {
                    Username = "updateTest",
                    Password = "updatedPassword",
                    Email = "updatedEmail"
                };

                var userService = new UserService(context, mapper, new TokenGenerator(null));

                var result = await userService.UpdateUserByUsername("initialUser", updateUserDto);
                
               
                var updatedUser = await context.Users.FirstOrDefaultAsync(u => u.Username == "updateTest");
                Assert.NotNull(updatedUser);
                Assert.Equal("updatedEmail", updatedUser.Email);
            }
        }
    }
}
        
    


    