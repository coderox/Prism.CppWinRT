using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Tests.Mocks.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Prism.Tests.Mvvm
{
    [TestClass]
    public class BindableBaseFixture
    {
        CoreApplicationView currentView;
        CoreDispatcher dispatcher;

        [TestInitialize]
        public void InitializeTest()
        {
            if (dispatcher == null)
            {
                currentView = CoreApplication.MainView;
                dispatcher = currentView.Dispatcher;
            }
        }

        [TestMethod]
        public async Task SetPropertyMethodShouldSetTheNewValue()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => {
                    int value = 10;
                    MockViewModel mockViewModel = new MockViewModel();

                    Assert.AreEqual(0, mockViewModel.MockProperty);

                    mockViewModel.MockProperty = value;
                    Assert.AreEqual(value, mockViewModel.MockProperty);
                });
        }

        [TestMethod]
        public async Task SetPropertyMethodShouldNotSetTheNewValue()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => {
                    int value = 10, newValue = 10;
                    MockViewModel mockViewModel = new MockViewModel();
                    mockViewModel.MockProperty = value;

                    bool invoked = false;
                    mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockProperty")) invoked = true; };
                    mockViewModel.MockProperty = newValue;

                    Assert.IsFalse(invoked);
                    Assert.AreEqual(value, mockViewModel.MockProperty);
                });
        }

        [TestMethod]
        public async Task SetPropertyMethodShouldRaisePropertyRaised()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => {
                    bool invoked = false;
                    MockViewModel mockViewModel = new MockViewModel();

                    mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockProperty")) invoked = true; };
                    mockViewModel.MockProperty = 10;

                    Assert.IsTrue(invoked);
                });
        }

        [TestMethod]
        public async Task OnPropertyChangedShouldExtractPropertyNameCorrectly()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => {
                    bool invoked = false;
                    MockViewModel mockViewModel = new MockViewModel();

                    mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockProperty")) invoked = true; };
                    mockViewModel.InvokeOnPropertyChanged();

                    Assert.IsTrue(invoked);
                });
        }
    }
}
