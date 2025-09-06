using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents.AzureAI;
using Microsoft.SemanticKernel.ChatCompletion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAgentAiApp
{
    public class AgentIntercationHandler
    {
        public AgentIntercationHandler()
        {
        }

        public async Task RunSimpleResponseAsync(string input, AzureAIAgent agent)
        {
            AzureAIAgentThread agentThread = new(agent.Client);
            try
            {
                ChatMessageContent message = new(AuthorRole.User, input);
                Console.WriteLine("Response:");
                await foreach (ChatMessageContent response in agent.InvokeAsync(message, agentThread))
                {
                    Console.WriteLine(response.Content);
                }
            }
            finally
            {
                await agentThread.DeleteAsync();
            }

        }

        public async Task RunStreamedResponseAsync(string input, AzureAIAgent agent)
        {
            AzureAIAgentThread agentThread = new(agent.Client);
            try
            {
                ChatMessageContent message = new(AuthorRole.User, input);
                await foreach (StreamingChatMessageContent response in agent.InvokeStreamingAsync(message, agentThread))
                {
                    Console.Write(response.Content);
                }
            }
            finally
            {
                await agentThread.DeleteAsync();
            }

        }

        public async Task<AzureAIAgentThread> RunSimpleResponseAsync(string input,AzureAIAgent agent, AzureAIAgentThread azureAIAgentThread = null, bool useHistory = false)
        {
            AzureAIAgentThread agentThread;

            if (azureAIAgentThread == null)
            {
                agentThread = new(agent.Client);
            }else
            {
                agentThread = azureAIAgentThread;
            }

            try
            {
                ChatMessageContent message = new(AuthorRole.User, input);
                await foreach (ChatMessageContent response in agent.InvokeAsync(message, agentThread))
                {
                    Console.WriteLine(response.Content);
                }
            }
            finally
            {
                if (!useHistory)
                    await agentThread.DeleteAsync();
            }

            return agentThread;

        }

        public async Task RunStreamedResponseAsync(string input, AzureAIAgent agent, AzureAIAgentThread azureAIAgentThread = null, bool useHistory = false)
        {
            AzureAIAgentThread agentThread;

            if (azureAIAgentThread == null)
            {
                agentThread = new(agent.Client);
            }
            else
            {
                agentThread = azureAIAgentThread;
            }

            try
            {
                ChatMessageContent message = new(AuthorRole.User, input);
                await foreach (StreamingChatMessageContent response in agent.InvokeStreamingAsync(message, agentThread))
                {
                    Console.Write(response.Content);
                }
            }
            finally
            {
                if (!useHistory)
                    await agentThread.DeleteAsync();
            }

        }
    }
}
