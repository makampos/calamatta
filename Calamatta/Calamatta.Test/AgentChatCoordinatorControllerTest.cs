using System;
using System.Collections.Generic;
using Calamatta.Api.Controllers;
using Calamatta.Application.Dtos;
using Calamatta.Application.Interfaces;
using Calamatta.Domain.Constants;
using Calamatta.Domain.Enums;
using Calamatta.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Calamatta.Test
{
    public class AgentChatCoordinatorControllerTest
    {
        [Fact]
        public void AssignChat_ShouldReturnOkResult()
        {
            // Arrange
            var agentChatCoordinatorService = new Mock<IAgentChatCoordinatorService>();
            var logger = new Mock<ILogger<AgentChatCoordinatorController>>();
            var controller = new AgentChatCoordinatorController(logger.Object, agentChatCoordinatorService.Object);
            
            //1. Create Queue
            var queueService = new Mock<IQueueService<Session>>(); 
            queueService.Setup(x => x.Get()).Returns(new Queue<Session>());
            
            //2. Create Session
            var sessionService = new Mock<ISessionService>();
            sessionService.Setup(x => x.Create()).Returns(Session.Create);
            
            //3. Create Agent
            var agentService = new Mock<IAgentService>();
            var agentDto = AgentDto.Create("Will", Seniority.Junior);
            var agentDomain = Agent.Create(agentDto.Name, agentDto.Seniority, SeniorityMultiplier.Junior); 
            agentService.Setup(x => x.Create(agentDto)).Returns(agentDomain);
            
            //4. Create Team
            var teamService = new Mock<ITeamService>();
            var team = Team.Create("XYZ",new List<Agent>{agentDomain}, 4 );
            teamService.Setup(x => x.Create(new List<Guid>{agentDomain.Id}, "TEAM_XYZ"))
                .Returns(team);
            
            //5. Assign Chat
            agentChatCoordinatorService.Setup(x => x.AssignChat(4));
            
            // Act
            var result = controller.AssignChat(4);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}