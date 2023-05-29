using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPetRepository PetRepository { get; }
        public IUserRepository UserRepository { get; }
        public IAddressRepository AddressRepository { get; }
        public IFormRepository FormRepository { get;}
        public IQuestionRepository QuestionRepository { get; set; }

        private AppDbContext Context;

        public UnitOfWork(IPetRepository petRepository, IUserRepository userRepository, IAddressRepository addressRepository, IFormRepository formRepository, IQuestionRepository questionRepository, AppDbContext context)
        {
            PetRepository = petRepository;
            UserRepository = userRepository;
            AddressRepository = addressRepository;
            FormRepository = formRepository;
            QuestionRepository = questionRepository;
            Context = context;
        }

        public async Task SaveAsync()
        {
            try
            {
                 await Context.SaveChangesAsync();
            }
            catch(Exception error)
            {
                throw error;
            }
               
        }
    }
}