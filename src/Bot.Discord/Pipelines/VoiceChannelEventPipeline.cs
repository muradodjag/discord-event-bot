using Color_Chan.Discord.Commands;
using Color_Chan.Discord.Commands.Models.Contexts;
using Color_Chan.Discord.Core.Common.Models.Interaction;
using Color_Chan.Discord.Core.Results;

namespace Bot.Discord.Pipelines;

public class VoiceChannelEventPipeline : IInteractionPipeline
{
    public async Task<Result<IDiscordInteractionResponse>> HandleAsync(IInteractionContext context, InteractionHandlerDelegate next)
    {
       return await next();
    }
}