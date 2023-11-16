using System.Collections;
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
    public class AgentControllerTest
    {
        [Fact]
        public void GetAll_ShouldReturnOkObjectResult()
        {
            // Arrange
            var agentService = new Mock<IAgentService>();
            var logger = new Mock<ILogger<AgentController>>();
            var controller = new AgentController(logger.Object, agentService.Object);

            var lstAgents = new List<Agent>
            {
                Agent.Create("Will", Seniority.Junior, SeniorityMultiplier.Junior)
            };

            agentService.Setup(x => x.GetAll()).Returns(lstAgents);
            
            // Act
            var result = controller.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Create_ShouldReturnOkObjectResult()
        {
            // Arrange
            var agentService = new Mock<IAgentService>();
            var logger = new Mock<ILogger<AgentController>>();
            var controller = new AgentController(logger.Object, agentService.Object);
            var agentDto = AgentDto.Create("Will", Seniority.Junior);
            var agent = Agent.Create(agentDto.Name, agentDto.Seniority, SeniorityMultiplier.Junior);

            agentService.Setup(x => x.Create(agentDto)).Returns(agent);
            
            // Act
            var result = controller.Create(agentDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Agent>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Update_ShouldReturnNoContentResult()
        {
            // Arrange
            var agentService = new Mock<IAgentService>();
            var logger = new Mock<ILogger<AgentController>>();
            var controller = new AgentController(logger.Object, agentService.Object);
            var agentDto = AgentDto.Create("Will", Seniority.Junior);
            var agent = Agent.Create(agentDto.Name, agentDto.Seniority, SeniorityMultiplier.Junior);
            
            agent.EndShift(false);
            
            agentService.Setup(x => x.UpdateShift(agent.Id, false));
            
            // Act
            var result = controller.UpdateShift(agent.Id, false);
            
            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}