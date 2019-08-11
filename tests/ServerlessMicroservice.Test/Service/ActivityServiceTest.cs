using Autofac.Extras.Moq;
using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServerlessMicroservice.Test.Service
{
    public class ActivityServiceTest
    {
        [Fact]
        public void LoadPeople_ValidCall()
        {
            //using (var mock = AutoMock.GetLoose())
            //{
            //    mock.Mock<IActivityRepository>()
            //        .Setup(x => x.GetAllData<Activity>("select * from Person"))
            //        .Returns(GetSamplePeople());

            //    var cls = mock.Create<Activity>();
            //    var expected = GetSamplePeople();

            //    var actual = cls.GetSamplePeople();

            //    Assert.True(actual != null);
            //    Assert.Equal(expected.Count, actual.Count);

            //    for (int i = 0; i < expected.Count; i++)
            //    {
            //        Assert.Equal(expected[i].FirstName, actual[i].FirstName);
            //        Assert.Equal(expected[i].LastName, actual[i].LastName);
            //    }
            //}
        }



        private List<Activity> GetSamplePeople()
        {
            List<Activity> output = new List<Activity>
            {
                new Activity
                {
                    Id = 1,
                    UserId = 1,
                    ApplicationId = 1,
                    ActionId =1,
                    ApplicationUrl = "https",
                    ActivityRemarks = "code just copy"
                },
                new Activity
                {
                   Id = 2,
                    UserId = 1,
                    ApplicationId = 1,
                    ActionId =1,
                    ApplicationUrl = "https",
                    ActivityRemarks = "code just copy"
                },
                new Activity
                {
                   Id = 3,
                    UserId = 2,
                    ApplicationId = 2,
                    ActionId =2,
                    ApplicationUrl = "https",
                    ActivityRemarks = "code just copy"
                },
                new Activity
                {
                   Id = 4,
                    UserId = 3,
                    ApplicationId = 3,
                    ActionId =2,
                    ApplicationUrl = "https only",
                    ActivityRemarks = "code just copy"
                }
            };

            return output;
        }
    }
}
