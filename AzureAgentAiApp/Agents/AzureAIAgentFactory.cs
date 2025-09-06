using Azure.AI.Agents.Persistent;
using Azure.Identity;
using Microsoft.SemanticKernel.Agents.AzureAI;

namespace AzureAgentAiApp.Agents
{
    public class AzureAIAgentFactory
    {
        private const string AgentName = "Agent1";
        public async Task<AzureAIAgent> CreateSimpleAgentAsync(string modelName, string endpoint)
        {
            PersistentAgentsClient agentsClient = AzureAIAgent.CreateAgentsClient(endpoint, new AzureCliCredential());

            // 1. Define an agent on the Azure AI agent service
            PersistentAgent definition = await agentsClient.Administration.CreateAgentAsync(
                modelName,
                name: AgentName,
                description: "This is a simple agent just for converstaion",
                instructions: """
                You are a helpful assistant that helps people find information.
                You should answer as helpfully as possible.
                If you don't know the answer, just say you don't know. Don't try to make up an answer.
                Your answers should be concise and to the point.
                And all your resonse should be withing 100 words.
                """);

            // 2. Create a Semantic Kernel agent based on the agent definition
            AzureAIAgent agent = new(definition, agentsClient);

            return agent;
        }

        //TODO: Implement other agents

        #region other agents
        public async Task<AzureAIAgent> CreateCodeInterpreterAgentAsync(string modelName, string endpoint)
        {
            PersistentAgentsClient agentsClient = AzureAIAgent.CreateAgentsClient(endpoint, new AzureCliCredential());

            // 1. Define an agent on the Azure AI agent service
            PersistentAgent definition = await agentsClient.Administration.CreateAgentAsync(
                modelName,
                name: AgentName,
                description: "This is a simple agent just for converstaion",
                instructions: """
                You are a helpful assistant that helps people find information.
                You should answer as helpfully as possible.
                If you don't know the answer, just say you don't know. Don't try to make up an answer.
                Your answers should be concise and to the point.
                And all your resonse should be withing 100 words.
                """);

            // 2. Create a Semantic Kernel agent based on the agent definition
            AzureAIAgent agent = new(definition, agentsClient);

            return agent;
        }

        public async Task<AzureAIAgent> CreateFileSearchAgentAsync(string modelName, string endpoint)
        {
            PersistentAgentsClient agentsClient = AzureAIAgent.CreateAgentsClient(endpoint, new AzureCliCredential());

            // 1. Define an agent on the Azure AI agent service
            PersistentAgent definition = await agentsClient.Administration.CreateAgentAsync(
                modelName,
                name: AgentName,
                description: "This is a simple agent just for converstaion",
                instructions: """
                You are a helpful assistant that helps people find information.
                You should answer as helpfully as possible.
                If you don't know the answer, just say you don't know. Don't try to make up an answer.
                Your answers should be concise and to the point.
                And all your resonse should be withing 100 words.
                """);

            // 2. Create a Semantic Kernel agent based on the agent definition
            AzureAIAgent agent = new(definition, agentsClient);

            return agent;
        }

        public async Task<AzureAIAgent> CreateOpenApiAgentAsync(string modelName, string endpoint)
        {
            PersistentAgentsClient agentsClient = AzureAIAgent.CreateAgentsClient(endpoint, new AzureCliCredential());

            // 1. Define an agent on the Azure AI agent service
            PersistentAgent definition = await agentsClient.Administration.CreateAgentAsync(
                modelName,
                name: AgentName,
                description: "This is a simple agent just for converstaion",
                instructions: """
                You are a helpful assistant that helps people find information.
                You should answer as helpfully as possible.
                If you don't know the answer, just say you don't know. Don't try to make up an answer.
                Your answers should be concise and to the point.
                And all your resonse should be withing 100 words.
                """);

            // 2. Create a Semantic Kernel agent based on the agent definition
            AzureAIAgent agent = new(definition, agentsClient);

            return agent;
        }

        public async Task<AzureAIAgent> CreateAzureAiSearchAgentAsync(string modelName, string endpoint)
        {
            PersistentAgentsClient agentsClient = AzureAIAgent.CreateAgentsClient(endpoint, new AzureCliCredential());

            // 1. Define an agent on the Azure AI agent service
            PersistentAgent definition = await agentsClient.Administration.CreateAgentAsync(
                modelName,
                name: AgentName,
                description: "This is a simple agent just for converstaion",
                instructions: """
                You are a helpful assistant that helps people find information.
                You should answer as helpfully as possible.
                If you don't know the answer, just say you don't know. Don't try to make up an answer.
                Your answers should be concise and to the point.
                And all your resonse should be withing 100 words.
                """);

            // 2. Create a Semantic Kernel agent based on the agent definition
            AzureAIAgent agent = new(definition, agentsClient);

            return agent;
        }

        public async Task<AzureAIAgent> CreateBingAgentAsync(string modelName, string endpoint)
        {
            PersistentAgentsClient agentsClient = AzureAIAgent.CreateAgentsClient(endpoint, new AzureCliCredential());

            // 1. Define an agent on the Azure AI agent service
            PersistentAgent definition = await agentsClient.Administration.CreateAgentAsync(
                modelName,
                name: AgentName,
                description: "This is a simple agent just for converstaion",
                instructions: """
                You are a helpful assistant that helps people find information.
                You should answer as helpfully as possible.
                If you don't know the answer, just say you don't know. Don't try to make up an answer.
                Your answers should be concise and to the point.
                And all your resonse should be withing 100 words.
                """);

            // 2. Create a Semantic Kernel agent based on the agent definition
            AzureAIAgent agent = new(definition, agentsClient);

            return agent;
        }

        #endregion
    }
}
