using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core.Models;
using System.Data;
using System.Configuration;

namespace LifeLine.Infrastructure.Implementation
{
    public class MessagesRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["BloodDonorContext"].ConnectionString;
        
        public IEnumerable<Camp> GetAllMessages()
        {
            var messages = new List<Camp>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [Id] ,[Name] ,[Where] ,[When] FROM [dbo].[Camp]", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messages.Add(item: new Camp { Id = (Guid)reader["Id"],
                                                        Name = (string)reader["Name"],
                                                        Where = (string)reader["Where"],
                                                        When = (string)reader["When"] });
                    }
                }

            }
            return messages;


        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SignalR.MessagesHub.SendMessages();
            }
        }
    }
}
