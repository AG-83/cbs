using Concepts;
using Dolittle.Events.Processing;
using Events;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyProcessor : ICanProcessEvents
    {
        private readonly IAutomaticReplies _automaticReplies;
        private readonly IAutomaticReplyKeyMessages _keyMessages;

        public AutomaticReplyProcessor(IAutomaticReplies automaticReplies, IAutomaticReplyKeyMessages keyMessages)
        {
            _automaticReplies = automaticReplies;
            _keyMessages = keyMessages;
        }

        public void Process(AutomaticReplyDefined @event)
        {
            _automaticReplies.SaveAutomaticReply(
                @event.Id,
                @event.Type,
                @event.Language,
                @event.Message,
                @event.ProjectId);
            
        }

        public void Process(AutomaticReplyRemoved @event)
        {
            _automaticReplies.DeleteOne(@event.Id);
        }

        public void Process(AutomaticReplyKeyMessageDefined @event)
        {
            _keyMessages.SaveAutomaticReplyKeyMessage(
                @event.Id,
                @event.Type,
                @event.Language,
                @event.Message,
                @event.ProjectId,
                @event.HealthRiskId);
            
        }

        public void Process(AutomaticReplyKeyMessageRemoved @event)
        {
            _keyMessages.DeleteOne(@event.Id);
        }
    }
}
