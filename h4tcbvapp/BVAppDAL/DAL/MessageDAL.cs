using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BVAppDAL.Models;

namespace BVAPP.DAL
{
    public class MessageDAL
    {
        public void SendMessage(string msgText, int senderPartyId, int msgGroupId, string sendToClass, 
            List<int> parentPartyIds, List<int> studentPartyIds, List<int> teacherPartyIds)
        {
            try
            {
                var context = new bvappContext();

                Message msg = new Message();
                msg.MessageText = msgText;
                msg.SenderPartyId = senderPartyId;
                msg.MessageGroupId = msgGroupId;
                msg.SentToClass = sendToClass;
                msg.CreatedDate = DateTime.Now;
                msg.CreatedBy = "Admin";
                msg.ModifiedDate = DateTime.Now;
                msg.ModifiedBy = "Admin";

                context.Message.Add(msg);
                context.SaveChanges();

                AddRecipients(msg.MessageId, parentPartyIds, studentPartyIds, teacherPartyIds);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void AddRecipients(int msgId, List<int> parentPartyIds, List<int> studentPartyIds, List<int> teacherPartyIds)
        {
            try
            {
                using (var ctx = new bvappContext())
                {
                    int counter = 0;
                    if (parentPartyIds != null && parentPartyIds.Count() > 0)
                    {
                        foreach (var value in parentPartyIds)
                        {
                            MessageRecipient msgRecipient = new MessageRecipient();
                            msgRecipient.MessageId = msgId;

                            msgRecipient.ParentPartyId = value;
                            if (studentPartyIds != null && studentPartyIds.Count >= counter)
                                msgRecipient.StudentPartyId = studentPartyIds[counter];

                            msgRecipient.CreatedDate = DateTime.Now;
                            msgRecipient.CreatedBy = "Admin";
                            msgRecipient.ModifiedDate = DateTime.Now;
                            msgRecipient.ModifiedBy = "Admin";

                            ctx.MessageRecipient.Add(msgRecipient);
                            counter++;
                        }
                        ctx.SaveChanges();
                    }
                    else if (teacherPartyIds != null && teacherPartyIds.Count() > 0)
                    {
                        foreach (var value in teacherPartyIds)
                        {
                            MessageRecipient msgRecipient = new MessageRecipient();
                            msgRecipient.MessageId = msgId;

                            msgRecipient.TeacherPartyId = value;

                            msgRecipient.CreatedDate = DateTime.Now;
                            msgRecipient.CreatedBy = "Admin";
                            msgRecipient.ModifiedDate = DateTime.Now;
                            msgRecipient.ModifiedBy = "Admin";

                            ctx.MessageRecipient.Add(msgRecipient);
                            counter++;
                        }
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void updatedReadMsg(int msgId, int recipientId)
        {
            try
            {
                var context = new bvappContext();
                var result = context.MessageRecipient.SingleOrDefault(b => b.MessageId == msgId && b.ParentPartyId == recipientId);
                if (result != null)
                {
                    result.ReadDate = DateTime.Now;
                    result.ModifiedDate = DateTime.Now;
                    result.ModifiedBy = "Admin";

                    context.SaveChanges();
                }
                else
                {
                    var result1 = context.MessageRecipient.SingleOrDefault(b => b.MessageId == msgId && b.TeacherPartyId == recipientId);
                    if (result1 != null)
                    {
                        result1.ReadDate = DateTime.Now;
                        result1.ModifiedDate = DateTime.Now;
                        result1.ModifiedBy = "Admin";

                        context.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string ReadMessage(int recipientId)
        {
            string json = string.Empty;

            try
            {
                using (var context = new bvappContext())
                {
                    var query = (from a in context.Message
                                 join p in context.MessageRecipient on a.MessageId equals p.MessageId
                                 where p.ParentPartyId == recipientId || p.TeacherPartyId == recipientId || a.SenderPartyId == recipientId
                                 orderby a.CreatedDate descending
                                 select a);

                    json = JsonConvert.SerializeObject(query);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return json;
        }
    }
}
