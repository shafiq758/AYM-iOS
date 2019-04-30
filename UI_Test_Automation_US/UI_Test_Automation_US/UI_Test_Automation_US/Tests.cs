using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace UI_Test_Automation_US
{
    [TestFixture]
    public class Tests
    {
        private readonly string path = "../../../iOS/bin/iPhoneSimulator/Debug/pampers-rewards-ios-us-cal.app";
        iOSApp app;
        public static string EmailFinal;
        RandomGenerator generator = new RandomGenerator();

        
        [SetUp]
        public void BeforeEachTest()
        {
            Environment.SetEnvironmentVariable("UITEST_FORCE_IOS_SIM_RESTART", "1"); // Restart simulator

            app = ConfigureApp.iOS.PreferIdeSettings().AppBundle(path).StartApp(AppDataMode.Clear);
            //DeviceIdentifier("7D1171C1-1463-4B6A-8A17-3A792301214C"); 
        }

        public class RandomGenerator
        {

            public string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }

            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

        }
        //[Test]
        public void Repl()
        {
            app.Repl();
        }
       [Test]
        public void A_Register()
        {
            string str = generator.RandomString(3, false);
            int rand = generator.RandomNumber(3, 100);
            string randomnumber = rand.ToString();
            string email = String.Concat(str, randomnumber);
            string remain = "@pampers.com";
            EmailFinal = String.Concat("james.", email, remain);
            Thread.Sleep(20000);
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            Thread.Sleep(7000);
            //app.Flash("I’m already a member");
            app.Tap("Let’s get started!");
            Thread.Sleep(3000);
            app.Tap(x => x.TextField().Index(0));
            app.EnterText("James");
            app.Tap(x => x.TextField().Index(1));
            app.EnterText(EmailFinal);
            app.Tap(x => x.TextField().Index(2));
            app.EnterText("magicA123");
            app.DismissKeyboard();
            app.Tap("I'd love to join!");
            Thread.Sleep(15000);
            app.Tap("Let me add the date");
            Thread.Sleep(5000);
            app.Tap("Done");
            app.Tap("Save and continue");
            Thread.Sleep(5000);
            app.Tap("Let's lock this down");
            Thread.Sleep(3000);
            Console.Write("--- Register Success ---");
            //B_Login();
        }
        [Test]
        public void B_Login()
        {
            Thread.Sleep(20000);
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            app.SwipeRightToLeft();
            Thread.Sleep(7000);
            app.Tap("I’m already a member");
            Thread.Sleep(3000);
            app.Tap(x => x.TextField().Index(0));
            app.EnterText(EmailFinal);
            app.Tap(x => x.TextField().Index(1));
            app.EnterText("magicA123");
            app.DismissKeyboard();
            app.Tap("Sign me in!");
            Thread.Sleep(20000);
            var isDia = app.Query("Continue").Any();
            if(isDia == true)
            {
                app.Tap("Not now");
            }
            var isDiaSec = app.Query(x => x.Id("icon_security")).Any();
            if(isDiaSec == true)
            {
                app.Tap("I'll skip this");
            }
            Console.Write("--- Login Success ---");
            Thread.Sleep(3000);
            Details();
            Baby();
            History();
            FeaturedRewards();
            GetMorePoints();
            ParentsHub();
            Notifications();
            Logout();
            Console.Write("--- UI TEST AUTOMATION SUCCESS ---");
        }
        public void Details()
        {
            app.Tap(x => x.Id("icon-tab_bar-menu"));
            app.Tap(x => x.Marked("Pampers Account"));
            app.Tap(x => x.Marked("My Details"));
            app.Tap(x => x.Id("icon_edit_white"));
            Thread.Sleep(5000);
            app.Tap(x => x.All().Index(20));
            app.Tap("Done");
            app.Tap(x => x.TextField().Index(1));
            app.EnterText("Smith");
            app.DismissKeyboard();
            app.Tap(x => x.All().Index(62));
            Thread.Sleep(2000);
            app.Tap("Done");
            app.Tap(x => x.Id("icon_accept_white"));
            Thread.Sleep(10000);
            app.Tap(x => x.Id("navigation_bar_back_button"));
            var isCodeDia = app.Query(x => x.Text("Add code now")).Any();
            if(isCodeDia == true) 
            { 
            app.Tap("Not now");
            }
            Console.Write("--- My Details Success ---");
            Thread.Sleep(3000);
        }
        public void Baby()
        {
            app.Tap("My Baby");
            Thread.Sleep(2000);
            app.Tap("What is your baby's name?");
            app.Tap(x => x.TextField().Index(0));
            app.EnterText("Alica");
            app.Tap(x => x.All().Index(28));
            app.Tap("Done");
            app.Tap("Save");
            Thread.Sleep(10000);
            var isCodeDia = app.Query(x => x.Text("Add code now")).Any();
            if (isCodeDia == true)
            {
                app.Tap("Not now");
            }
            app.Tap(x => x.Id("navigation_bar_back_button"));
            Console.Write("---My Baby Success---");
            Thread.Sleep(3000);
        }
        public void History()
        {
            app.Tap(x => x.Id("icon-tab_bar-menu"));
            app.Tap(x => x.Text("History"));
            Thread.Sleep(5000);
            app.Tap(x => x.Id("navigation_bar_back_button"));
            Console.Write("--- History Success ---");
            Thread.Sleep(3000);
        }
        public void FeaturedRewards()
        {
            app.Tap(x => x.Text("Featured Rewards"));
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            app.Tap(x => x.Text("See Rewards Here"));
            Thread.Sleep(5000);
            app.Tap(x => x.Text("Shutterfly Prints Package"));
            Thread.Sleep(5000);
            app.Tap(x => x.Text("Redeem now"));
            Thread.Sleep(5000);
            app.Tap(x => x.Id("navigation_bar_back_button"));
            app.Tap(x => x.Id("navigation_bar_back_button"));
            app.Tap(x => x.Id("icon-tab_bar-home"));
            Console.Write("--- Featured Rewards Success ---");
            Thread.Sleep(3000);
        }
        public void GetMorePoints()
        {
            //Random Code Generation 
            Random random = new Random();
            var Codes = new List<string>
            {
                "TESTKEYCODE6",
                "TESTKEYCODE7",
                "TESTKEYCODE8",
                "TESTKEYCODE9"
            };
            int index = random.Next(Codes.Count);
            int index2 = random.Next(Codes.Count);

            app.Tap("Get More Points");
            app.Tap("Scan Code Now");
            app.Tap("Diapers");
            app.Tap("Diapers or Easy Ups bag");
            app.Tap("Diapers or Easy Ups bag");
            app.Tap("Diapers or Easy Ups box");
            app.Tap("Diapers or Easy Ups box");
            app.Tap("Let's start");
            Thread.Sleep(3000);
            app.Query();
            Thread.Sleep(3000);
            app.Tap(x => x.Id("code_scanning-capture-manual_entry-button"));
            app.EnterText(Codes[index]);           
            app.Tap(x => x.Text("Done!"));
            Thread.Sleep(30000);
           // app.Query(x => x.Text("This looks familiar . . ."));
            app.Tap(x => x.Id("icon_cross_white"));
            app.Tap("Scan Code Now");
            app.Tap(x => x.Text("Wipes"));
            Thread.Sleep(7000);
            var isWipesDia = app.Query(x => x.Id("artwork_teddy_blocks")).Any();
            if (isWipesDia == true)
            {
                app.Tap("I'll type in codes");
                app.Tap("Let's start");
            }
            else
            {
                app.Tap("Let's start");
            }
            app.EnterText(Codes[index]);
            app.Tap(x => x.Text("Done!"));
            Thread.Sleep(30000);
            app.Tap(x => x.Id("icon_cross_white"));
            app.Tap(x => x.Id("navigation_bar_back_button"));
            Console.Write("--- Get More Points Success ---");
            Thread.Sleep(3000);

        }
        public void ParentsHub()
        {
            app.Tap("Parents' Hub");
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            app.SwipeRightToLeft();
            Thread.Sleep(5000);
            Console.Write("--- Parents Hub Success ---");
            Thread.Sleep(3000);
        }
        public void Notifications()
        {
            Thread.Sleep(7000);
            app.Tap(x => x.Id("icon-tab_bar-notification"));
            app.ScrollDown();
            Console.Write("--- Notification Success ---");
            Thread.Sleep(3000);
            History();
        }
        public void Logout()
        {
            app.Tap(x => x.Id("icon-tab_bar-menu"));
            app.Tap(x => x.Marked("Pampers Account"));
            app.Tap(x => x.Id("profile-profile_view-icon_sign_out"));
            Thread.Sleep(3000);
            Console.Write("--- Logout Success ---");
        }


    }
}

