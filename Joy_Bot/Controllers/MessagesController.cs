using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using Joy_Bot.Controllers;
using System.Collections.Generic;
namespace Joy_Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                var resp1 = "";
                // calculate something for us to return
                //int length = (activity.Text ?? string.Empty).Length;
                // return our reply to the user
                //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                //await connector.Conversations.ReplyToActivityAsync(reply);
                if (activity.Text?.Any() == true)
                {
                    var name = activity.Text;
                    var resp = "";
                    if (name.Equals("hi"))
                    {
                        resp = "Hello!! Welcome to 'Scout Bot'. Here you can get every query answered regarding EAMCET ranks and colleges";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    if (name.Equals("Good Colleges In Hyderabad") || name.Equals("Best Colleges In Hyderabad"))
                    {
                        resp = "some of the best colleges in Hyderabad are : JNTUH, VASAVI, CBIT, BVRITH, BVRITN, VNRVJIET";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Colleges I can get into with 10,000 rank?"))
                    {
                        resp = "These are some colleges you can try with your rank : VNR VJIET, NARAYANAMMA, MGIT";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);


                    }
                    else if (name.Equals("thankyou") || name.Equals("thanks") || name.Equals("tq")|| name.Equals("tx"))
                    {
                        resp = "No problem!";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);

                    }
                    
                    else if (name.Equals("Best Women's collegs in Hyderabad?"))
                    {
                        resp = "Narayanamma, BVRITH, SriDevi are some best women's colleges in Hyderabad";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);

                    }

                    else if (name.Equals("Highest Placements?") || name.Equals("Colleges with best placements?"))
                    {
                        resp = "JNTUH, CBIT, BVTITH, VNR VJIET, VASAVI, BVRITN, NARAYANAMMA, SRIDEVI";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Can I know more about BVRITN!"))
                    {
                        resp = "sure! Visit this link : http://www.bvrit.ac.in/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Can I know more about jntuh!"))
                    {
                        resp = "sure! Visit this link : https://www.jntuh.ac.in/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Can I know more about VNR VJIET!"))
                    {
                        resp = "sure! Visit this link : http://www.vnrvjiet.ac.in/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Can I know more about Vasavi!"))
                    {
                        resp = "sure! Visit this link : http://www.vce.ac.in/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Can I know more about Sridevi!"))
                    {
                        resp = "sure! Visit this link : http://www.srideviengg.com/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Can I know more about narayanamma!"))
                    {
                        resp = "sure! Visit this link : http://www.gnits.ac.in/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("Can I know more about BVRITH!"))
                    {
                        resp = "sure! Visit this link : http://www.bvrithyderabad.ac.in/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                    else if (name.Equals("Can I know more about CBIT!"))
                    {
                        resp = "sure! Visit this link : http://www.cbit.ac.in/";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                }
                else
                {
                    resp1 = "Cannot understand!";
                    Activity reply = activity.CreateReply(resp1);
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
            return null;
        }
    }
}