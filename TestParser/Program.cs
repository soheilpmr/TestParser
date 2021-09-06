using Microsoft.EntityFrameworkCore;
using MySqlLibrary;
using System;
using System.Collections.Generic;
using TestParser.Core;


namespace TestParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var args1 = new string[]
            {
                //@"/of:D:\results.xlsx",
                //@"F:\Soheil\RaveshMand\TestParser-master\TestParser\bin\Debug\TestParser.exe",
                
                @"Your Address Of Trx File In Your Computer",
                "The Name Of The Test"

                ////@"D:\test.xml"

                ///*@"/of:D:\results.xlsx"*/
                ////"UnitTest",
                //@"C:\Users\Amir\source\repos\UnitTestProject1\TestResults"
                //////@"D:\test.xml"
            };
            try
            {
                var cla = new CommandLineArguments(args1);
                if (cla.ErrorMessage != null)
                {
                    Console.Error.WriteLine(cla.GetUsageMessage());
                    Environment.Exit(1);
                }

                var resultsFactory = new TestResultFactory();
                var results = resultsFactory.CreateResultsFromTestFiles(cla.TestFiles);

                #region MyCodes
                double percebtPassed = results.SummaryByAssembly.PercentPassed * 100;
                string datetimeDuration = results.SummaryByAssembly.TotalDurationInSecondsHuman;
                int totalTests = results.SummaryByAssembly.TotalTests;
                int passed = results.SummaryByAssembly.TotalPassed;

                Context context = new Context();
                var items = context.TestTimes.ToListAsync();

                MethodsOfDataBase methodsOfDataBase = new MethodsOfDataBase(context);

                methodsOfDataBase.AddTestDetailToDatabase(args1[1], DateTime.Now, percebtPassed, datetimeDuration, totalTests, passed);

                var listitem = results.ResultLines.SortedByFailedOtherPassed;
                var listitem2 = results.ResultLines.SortedByFileAndClass;


                string assembelyfilename = null;
                string className = null;
                string testName = null;
                string outcome = null;
                double durationSecond;
                string errorMessage = null;
                DateTime startTime;
                DateTime endTime;

                foreach (var item in listitem)
                {
                    assembelyfilename = item.AssemblyFileName;
                    className = item.ClassName;
                    testName = item.TestName;
                    outcome = item.Outcome;
                    durationSecond = Math.Round(item.DurationInSeconds, 4);
                    errorMessage = item.ErrorMessage;
                    startTime = Convert.ToDateTime(item.StartTime);
                    endTime = Convert.ToDateTime(item.EndTime);

                    methodsOfDataBase.AddToDetailOfEveryTest(assembelyfilename, className, testName, durationSecond, outcome, startTime, endTime, errorMessage);
                }

                int i = 0;
                string fullClassName = null;
                IEnumerable<SlowestTest> SlowTests = results.SlowestTests;
                foreach (var item in SlowTests)
                {

                    durationSecond = Math.Round(item.DurationInSeconds, 4);
                    fullClassName = item.FullClassName;
                    className = item.ClassName;
                    testName = item.TestName;
                    methodsOfDataBase.AddFiveShowestTest(durationSecond, fullClassName, className, testName);
                    i++;
                    if (i > 5)
                        break;
                }
                #endregion

                //var optionsBuilder = new DbContextOptionsBuilder<Context>();
                //optionsBuilder.use("Data Source=blog.db");

                //using (var context = new BloggingContext(optionsBuilder.Options))
                //{
                //    // do stuff
                //}


                //ParsedDataOutputter outputCreator = new ParsedDataOutputter();
                //outputCreator.OutputResults(results, cla);
            }
            catch (Exception ex)
            {
                // Handy to put a breakpoint here :-)
                string msg = ex.Message;
                Console.Error.WriteLine(msg);
                Console.Error.WriteLine();
                Console.Error.WriteLine(ex.StackTrace);
                Environment.Exit(1);
            }
        }
    }
}
