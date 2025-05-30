﻿
using Application.Interfaces;
using Application.Services.Email;
using Application.Validators.Users;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;


namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IEntityRepository<User> _entityRepository;

        private IEnumerable<IUserCreationValidator> _validators;

        private IEmailService _emailService;
        
        public UserService(IEntityRepository<User> entityRepository, IEnumerable<IUserCreationValidator> validators,
            IEmailService emailService)
        {
            _entityRepository = entityRepository;
            _validators = validators;
            _emailService = emailService;
        }

        public async Task<User> CreateUserAsync(string name, string email, string password, Gender gender)
        {
            User user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Gender = gender
            };

            foreach (IUserCreationValidator validator in _validators)
            {
                await validator.Validate(user); 
            }

            await _entityRepository.AddAsync(user);
            await _entityRepository.SaveChangesAsync();
            await _emailService.SendEmail(email, new EmailMessage("Perfil criado no Oralytics",
                "Seu perfil foi criado com sucesso no Oralytics"));
            
            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            User user = await GetUserByIdAsync(userId);

            _entityRepository.Remove(user);
            await _entityRepository.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int userID)
        {
            User user = await _entityRepository.GetByIdAsync(userID);
            if (user == null)
                throw new EntityNotFoundException("User doesn't exist");    
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(int pageNumber, int pageSize)
        {
            return await _entityRepository.GetAllAsync(pageNumber, pageSize);
        }
    }
}
