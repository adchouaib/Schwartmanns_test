using Application.Contracts;
using Application.DTOs;
using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IJobRepository _jobRepository;

        public DashboardService(IUserRepository userRepository, IClientRepository clientRepository, IProjectRepository projectRepository, IJobRepository jobRepository)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _projectRepository = projectRepository;
            _jobRepository = jobRepository;
        }

        public async Task<List<Stat>> getCountEntities()
        {
            var allUsers = await _userRepository.GetAll();
            var allClients = await _clientRepository.GetAll();
            var allProjects = await _projectRepository.GetAll();
            var allJobs = await _jobRepository.GetAll();

            List<Stat> statistics = new List<Stat>()
            {
                new Stat("Users", allUsers.Count),
                new Stat("Clients", allClients.Count),
                new Stat("Projects", allProjects.Count),
                new Stat("Jobs", allJobs.Count),
            };

            return statistics;
        }

        public async Task<List<ProjectPerClient>> GetProjectPerClients()
        {
            var projectsPerClient = await _clientRepository.ProjectPerClients();
            return projectsPerClient;
        }
    }
}

