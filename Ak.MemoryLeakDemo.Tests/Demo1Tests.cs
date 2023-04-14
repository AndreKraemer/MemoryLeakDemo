using Ak.MemoryLeakDemo.ViewModels;
using JetBrains.dotMemoryUnit;
using System;
using System.Threading;
using System.Windows;
using JetBrains.dotMemoryUnit.Properties;
using NUnit.Framework;


namespace Ak.MemoryLeakDemo.Tests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class Demo1Tests
    {
        private App _app;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            _app = new App();
            _app.InitializeComponent();
          //  MainWindow window = new MainWindow();
        }


        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false, SavingStrategy = SavingStrategy.OnAnyFail)]
        public void Window1_ShouldNotBeInMemory()
        {

            //var window = new MainWindow();

            //var checkpoint = dotMemory.Check();

            // Öffnet das Fenster Demo1Window und schließt es direkt wieder
            // Das öffnen muss in einer separaten Methode erledigt werden, damit die Testmethode
            // keine lokale Variable vom Typ Demo1Window hält. Dies würde sonst das Ergebnis verfälschen
            CreateAndCloseWindow1();

            //dotMemory.Check(memory =>
            //    Assert.That(memory.GetDifference(checkpoint)
            //        .GetSurvivedObjects(where => where.Type.Is<Logfile>())
            //        .ObjectsCount, Is.EqualTo(0)));

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

        [Test]
        [DotMemoryUnit(FailIfRunWithoutSupport = false, SavingStrategy = SavingStrategy.OnAnyFail)]
        public void NoByteArrays_ShuoldBeInLOH()
        {
            // Öffnet das Fenster Demo1Window und schließt es direkt wieder
            // Das öffnen muss in einer separaten Methode erledigt werden, damit die Testmethode
            // keine lokale Variable vom Typ Demo1Window hält. Dies würde sonst das Ergebnis verfälschen
            CreateAndCloseWindow1();

            // Prüft, ob kein ByteArray im Large Object Heap (LOH)
            // LogFile Objekte werden innerhalb von Demo1Window erzeugt. 
            // Wenn Demo1Window nicht korrekt zerstört wird, z. B. weil der WPF Dispatcher nicht lief, oder weil die registrierten
            // Events nicht abgemeldet wurden, dann schlägt dieser Test fehl.
            dotMemory.Check(memory =>
            Assert.That(memory.GetObjects(where => where.Type.Is<Byte[]>())
                               .GetObjects(where => where.Generation.Is(Generation.LOH))
                        .ObjectsCount, Is.EqualTo(0)));
        }

        private void CreateAndCloseWindow1()
        {
            Window window = new Demo1Window();
            window.Close();
            DispatcherUtil.DoEvents();
        }
    }
}
