//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySqlLibrary
{
    public class MethodsOfDataBase
    {
        private readonly Context _dbcontext;
        //private IConfiguration configuration;
        public MethodsOfDataBase(Context dbcontext)
        {
            _dbcontext = dbcontext;
        }


        //private static void OpenSqlConnection()
        //{
        //    string connectionString = GetConnectionString();

        //    using (SqlConnection connection = new SqlConnection())
        //    {
        //        connection.ConnectionString = connectionString;

        //        connection.Open();

        //        Console.WriteLine("State: {0}", connection.State);
        //        Console.WriteLine("ConnectionString: {0}",
        //            connection.ConnectionString);
        //    }
        //}

        //public void Configureservice(IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddDbContext<Context>(options =>
        //    {
        //        options.UseSqlServer(configuration.GetConnectionString("Server=.;Database=TestResult;User ID =sa;Password = 123456"));
        //    });
        //}

        public void AddTestTimeToDatabase(TestTime model)
        {
            _dbcontext.TestTimes.Add(model);
            _dbcontext.SaveChanges();
        }

        public void AddTestKindToDatabase(string testKind, DateTime date1)
        {
            TestKind kindTable = new TestKind();
            kindTable.KindOfTest = testKind;


            TestTime timeTable = new TestTime();
            timeTable.Date = date1;
            timeTable.TestKind.Add(kindTable);

            _dbcontext.TestTimes.Add(timeTable);
            _dbcontext.SaveChanges();
        }

        private int idDetail;
        public void AddTestDetailToDatabase(string testKind, DateTime date1, double percaentPassed, string dateTimeDuration, int totalTests, int Passed)
        {
            TestTime testTime = new TestTime();
            testTime.Date = date1;
            TestTime testTime1 = _dbcontext.TestTimes.Add(testTime);
            _dbcontext.SaveChanges();
            int idtest = testTime1.Id;

            TestKind kindTable = new TestKind();
            kindTable.KindOfTest = testKind;

            kindTable.TestTime_Id = idtest;
            TestKind testKind1 = _dbcontext.TestKinds.Add(kindTable);
            _dbcontext.SaveChanges();
            int idkind = testKind1.Id;

            TestDetail detailTable = new TestDetail();
            detailTable.PercentPassed = percaentPassed;
            detailTable.DateTimeDuration = dateTimeDuration;
            detailTable.TotalTests = totalTests;
            detailTable.Passed = Passed;
            detailTable.TestKind_Id = idkind;
            TestDetail testDetail1 = _dbcontext.TestDetails.Add(detailTable);
            _dbcontext.SaveChanges();
            idDetail = testDetail1.Id;

            _dbcontext.SaveChanges();
        }


        public void AddToDetailOfEveryTest(string assembliName, string className, string testName, double duration, string outCome, DateTime startTime, DateTime endTime, string errorMessage = null)
        {
            TestDetailOfEveryTest testDetailOfEveryTest = new TestDetailOfEveryTest();

            testDetailOfEveryTest.AssembelyFileName = assembliName;
            testDetailOfEveryTest.ClassName = className;
            testDetailOfEveryTest.TestName = testName;
            testDetailOfEveryTest.Outcome = outCome;
            testDetailOfEveryTest.ErrorMessage = errorMessage;
            testDetailOfEveryTest.DurationInSeconds = duration;
            testDetailOfEveryTest.StartTime = startTime;
            testDetailOfEveryTest.EndTime = endTime;
            testDetailOfEveryTest.TestDetail_Id = idDetail;
            _dbcontext.TestDetailOfEveryTests.Add(testDetailOfEveryTest);
            _dbcontext.SaveChanges();
        }

        public void AddFiveShowestTest(double durationSecond, string fullClassName, string className, string testName)
        {
            FiveShowestTest fiveShowestTest = new FiveShowestTest();

            fiveShowestTest.DurationSecond = durationSecond;
            fiveShowestTest.FullClassName = fullClassName;
            fiveShowestTest.ClassName = className;
            fiveShowestTest.TestName = testName;
            fiveShowestTest.TestDetail_Id = idDetail;
            _dbcontext.FiveShowestTests.Add(fiveShowestTest);
            _dbcontext.SaveChanges();
        }

    }
}
