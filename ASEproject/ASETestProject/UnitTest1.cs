using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ASEproject;

namespace aseTest
{
    [TestClass]
    public class aseTest
    {
        /// <summary>
        /// circle command tests.
        /// </summary>
        [TestMethod]
        public void Circle()

        {
            Pen pen = new Pen(Color.Red, 1);
            Canvas canvas = new Canvas(300, 300);
            string command = "circle 50";
            // Execute the circle command.
            CommandParser parser = new CommandParser(command, pen, canvas);
            //Check command has been run and assert True if it has.
            List<string> executedCommands = canvas.GetExecutedCommands();
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }
            Assert.IsTrue(executedCommands.Any(command => command.Contains("Circle")));
        }

        /// <summary>
        /// rectangle command tests.
        /// </summary>
        [TestMethod]
        public void Rectangle_Test()
        {

            Pen pen = new Pen(Color.Black, 1);
            Canvas canvas = new Canvas(300, 300);
            string command = "rectangle 30 40";
            // Executes the rectangle command
            CommandParser parser = new CommandParser(command, pen, canvas);
            List<string> executedCommands = canvas.GetExecutedCommands();
            //Check command has been run and assert True if it has.
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }
            Assert.IsTrue(executedCommands.Any(command => command.Contains("Rectangle")));
        }

        /// <summary>
        /// Triangle command tests.
        /// </summary>
        [TestMethod]
        public void Triangle_Test()
        {
            Pen pen = new Pen(Color.Black, 1);
            Canvas canvas = new Canvas(300, 300);
            string command = "triangle 30";
            // Executes the triangle command
            CommandParser parser = new CommandParser(command, pen, canvas);
            List<string> executedCommands = canvas.GetExecutedCommands();
            //Check command has been run and assert True if it has.
            Console.WriteLine("Executed Commands:");
            foreach (string executedCommand in executedCommands)
            {
                Console.WriteLine(executedCommand);
            }
            Assert.IsTrue(executedCommands.Any(command => command.Contains("Triangle")));
        }

        /// <summary>
        /// runBTN test.
        /// </summary>
        [TestMethod]
        public void RunButton_Test()
        {
            Pen pen = new Pen(Color.Black, 1);
            Canvas canvas = new Canvas(300, 300);
            string command = "drawto 30 30" + Environment.NewLine + "rectangle 20 20";
            string[] commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var cmd in commands)
            {
                CommandParser parser = new CommandParser(cmd, pen, canvas);
            }
            //Check command has been run and assert True if it has.
            List<string> executedCommands = canvas.GetExecutedCommands();
            Assert.IsTrue(executedCommands.Count > 0, "No commands were executed on run button click.");
        }

        /// <summary>
        /// Moveto command test.
        /// </summary>
        [TestMethod]
        public void MoveTo_Test()
        {
            Pen pen = new Pen(Color.Red, 1);
            Canvas canvas = new Canvas(350, 300);
            int x = 50;
            int y = 100;
            string command = $"moveto {x} {y}";
            CommandParser parser = new CommandParser(command, pen, canvas);
            canvas.MoveTo(x, y);
            Point currentLocation = canvas.GetCurrentLocation();
            //Compare cursor position to moveto parameters given.
            Assert.AreEqual(new Point(x, y), currentLocation, "Cursor should move to the specified location");
        }
