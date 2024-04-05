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