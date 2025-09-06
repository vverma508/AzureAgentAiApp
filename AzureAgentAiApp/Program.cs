// See https://aka.ms/new-console-template for more information
using AzureAgentAiApp;
using Microsoft.SemanticKernel.Agents.AzureAI;

Console.WriteLine("Hello, Select the AI Agent you want to use!");

Console.WriteLine("1. Simple Azure AI Agent");

int agentSelected = Convert.ToInt32(Console.ReadKey());

AzureAIAgent azureAIAgent = null;

string modelName = "gpt-4o";
string openAiEndpoint = ""; // Add your Azure OpenAI endpoint here

switch (agentSelected)
{
    case 1:
        azureAIAgent = await new AzureAgentAiApp.Agents.AzureAIAgentFactory().CreateSimpleAgentAsync(modelName, openAiEndpoint);
        break;
    default:
        Console.WriteLine("Invalid selection. Exiting...");
        break;
}

Console.WriteLine("To run in question/answer mode, enter 'Y', for contextual mode enter 'N'");
char mode = Convert.ToChar(Console.ReadKey());

if (azureAIAgent != null && (mode.Equals('Y') || mode.Equals('y')))
{
    AgentIntercationHandler agentIntercationHandler = new();

    bool continueChat = true;
    while (continueChat)
    {
        Console.WriteLine("\nEnter your input (or type 'exit' to quit): ");
        var input = Console.ReadLine();

        if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            continueChat = false;
            break;
        }

        await agentIntercationHandler.RunSimpleResponseAsync(input, azureAIAgent);
        Console.WriteLine("\n");
    }
}

if (azureAIAgent != null && (mode.Equals('N') || mode.Equals('n')))
{
    AgentIntercationHandler agentIntercationHandler = new();
    AzureAIAgentThread azureAIAgentThread = null;

    bool continueChat = true;

    while (continueChat)
    {
        Console.WriteLine("\nEnter your input (or type 'exit' to quit): ");
        var input = Console.ReadLine();

        if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            continueChat = false;
            break;
        }

        azureAIAgentThread = await agentIntercationHandler.RunSimpleResponseAsync(input, azureAIAgent, azureAIAgentThread, true);
        Console.WriteLine("\n");
    }
}