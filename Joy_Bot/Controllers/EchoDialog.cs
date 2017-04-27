using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
namespace Joy_Bot.Controllers
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            string msg = message.Text;
            if (msg.ToLower().Contains("hi"))
            {
                await context.PostAsync("Hi , You can get the details of the B.Tech colleges here.Please tell me your Priority one by one and we will suggest some colleges which will help you");
                context.Wait(MessageReceivedAsync);
            }
            else if (msg.ToLower().Contains("thanks") || msg.ToLower().Contains("thank") || msg.ToLower().Contains("thx")||msg.ToLower().Contains("tq"))
            {
                await context.PostAsync("No problem!");
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                await context.PostAsync("Can you say that again...");
                context.Wait(MessageReceivedAsync);
            }
        }
    }
}