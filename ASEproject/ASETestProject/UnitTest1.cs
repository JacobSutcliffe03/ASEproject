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

        /// <summary>
        /// Drawto command test.
        /// </summary>
        [TestMethod]
        public void DrawTo_Test()
        {
            var canvas = new Canvas(300, 300);
            int startX = 10, startY = 10;
            int endX = 50, endY = 50;
            canvas.MoveTo(startX, startY);
            canvas.DrawTo(endX, endY);
            //Compare cursor position to drawto parameters given.
            var currentLocation = canvas.GetCurrentLocation();
            Assert.AreEqual(new Point(endX, endY), currentLocation, "Cursor should move to the specified location");
        }

        /// <summary>
        /// clear command test.
        /// </summary>
        [TestMethod]
        public void Clear_Test()
        {
            Pen pen = new Pen(Color.Red, 1);
            Canvas canvas = new Canvas(300, 300);
            canvas.MoveTo(50, 100);
            canvas.DrawTo(100, 150);
            canvas.Clear();
            // Checks if command history is empty.
            List<string> executedCommands = canvas.GetExecutedCommands();
            Assert.IsTrue(executedCommands.Count == 0, "Canvas should have no executed commands after clearing");
        }

        /// <summary>
        /// reset command test
        /// </summary>
        [TestMethod]
        public void Reset_Test()
        {
            Pen pen = new Pen(Color.Black, 1);
            Canvas canvas = new Canvas(300, 300);
            canvas.MoveTo(50, 100);
            canvas.Reset();
            // Check position of cursor returns to origin after being moved then reset.
            Point currentLocation = canvas.GetCurrentLocation();
            Assert.AreEqual(new Point(0, 0), currentLocation, "Cursor Reset");
        }

        /// <summary>
        /// colour command test.
        /// </summary>
        [TestMethod]
        public void ChangePenColor_Test()
        {
            Pen pen = new Pen(Color.Black, 1);
            Canvas canvas = new Canvas(300, 300);
            string command = "colour red";
            CommandParser parser = new CommandParser(command, pen, canvas);
            // Check pen's colour attribute after using command.
            Color updatedPenColor = pen.Color;
            Assert.AreEqual(Color.Red, updatedPenColor, "Pen color changed.");
        }
