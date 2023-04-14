using Ak.MemoryLeakDemo.ViewModels;
using JetBrains.dotMemoryUnit;
using JetBrains.dotMemoryUnit.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;


namespace Ak.MemoryLeakDemo.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class Demo1Tests
    {

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            var app = new App();
            app.InitializeComponent();
        }


        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false, SavingStrategy = SavingStrategy.OnAnyFail)]
        public void Demo1Test()
        {

            // Öffnet das Fenster Demo1Window und schließt es direkt wieder
            // Das öffnen muss in einer separaten Methode erledigt werden, damit die Testmethode
            // keine lokale Variable vom Typ Demo1Window hält. Dies würde sonst das Ergebnis verfälschen
            CreateAndCloseWindow1();

            // Prüft, ob kein LogFile Objekt mehr im Speicher ist.
            // LogFile Objekte werden innerhalb von Demo1Window erzeugt. 
            // Wenn Demo1Window nicht korrekt zerstört wird, z. B. weil der WPF Dispatcher nicht lief, oder weil die registrierten
            // Events nicht abgemeldet wurden, dann schlägt dieser Test fehl.
            dotMemory.Check(memory =>
                Assert.That(memory.GetObjects(where => where.Type.Is<Logfile>())
                                  .ObjectsCount, 
                            Is.EqualTo(0)));

            dotMemory.Check(memory =>
                Assert.That(memory.GetObjects(where => where.Type.Is<Demo1Window>())
                                  .ObjectsCount, 
                            Is.EqualTo(0)));
        }

        private void CreateAndCloseWindow1()
        {
            Window window = new Demo1Window();
            window.Close();
            DispatcherUtil.DoEvents();
        }
    }
}
