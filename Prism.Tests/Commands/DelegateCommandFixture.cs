﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Prism.Tests.Commands
{
    [TestClass]
    public class DelegateCommandFixture : BindableBase
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

        //[TestMethod]
        //public void WhenConstructedWithGenericTypeOfObject_InitializesValues()
        //{
        //    // Prepare

        //    // Act
        //    var actual = new DelegateCommand<object>(param => { });

        //    // verify
        //    Assert.NotNull(actual);
        //}

        //[Fact]
        //public void WhenConstructedWithGenericTypeOfNullable_InitializesValues()
        //{
        //    // Prepare

        //    // Act
        //    var actual = new DelegateCommand<int?>(param => { });

        //    // verify
        //    Assert.NotNull(actual);
        //}

        //[Fact]
        //public void WhenConstructedWithGenericTypeIsNonNullableValueType_Throws()
        //{
        //    Assert.Throws<InvalidCastException>(() =>
        //    {
        //        var actual = new DelegateCommand<int>(param => { });
        //    });
        //}

        //[Fact]
        //public void ExecuteCallsPassedInExecuteDelegate()
        //{
        //    var handlers = new DelegateHandlers();
        //    var command = new DelegateCommand<object>(handlers.Execute);
        //    object parameter = new object();

        //    command.Execute(parameter);

        //    Assert.Same(parameter, handlers.ExecuteParameter);
        //}

        //[Fact]
        //public void CanExecuteCallsPassedInCanExecuteDelegate()
        //{
        //    var handlers = new DelegateHandlers();
        //    var command = new DelegateCommand<object>(handlers.Execute, handlers.CanExecute);
        //    object parameter = new object();

        //    handlers.CanExecuteReturnValue = true;
        //    bool retVal = command.CanExecute(parameter);

        //    Assert.Same(parameter, handlers.CanExecuteParameter);
        //    Assert.Equal(handlers.CanExecuteReturnValue, retVal);
        //}

        //[Fact]
        //public void CanExecuteReturnsTrueWithouthCanExecuteDelegate()
        //{
        //    var handlers = new DelegateHandlers();
        //    var command = new DelegateCommand<object>(handlers.Execute);

        //    bool retVal = command.CanExecute(null);

        //    Assert.True(retVal);
        //}

        //[Fact]
        //public void RaiseCanExecuteChangedRaisesCanExecuteChanged()
        //{
        //    var handlers = new DelegateHandlers();
        //    var command = new DelegateCommand<object>(handlers.Execute);
        //    bool canExecuteChangedRaised = false;
        //    command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //    command.RaiseCanExecuteChanged();

        //    Assert.True(canExecuteChangedRaised);
        //}

        //[Fact]
        //public void CanRemoveCanExecuteChangedHandler()
        //{
        //    var command = new DelegateCommand<object>((o) => { });

        //    bool canExecuteChangedRaised = false;

        //    EventHandler handler = (s, e) => canExecuteChangedRaised = true;

        //    command.CanExecuteChanged += handler;
        //    command.CanExecuteChanged -= handler;
        //    command.RaiseCanExecuteChanged();

        //    Assert.False(canExecuteChangedRaised);
        //}

        //[Fact]
        //public void ShouldPassParameterInstanceOnExecute()
        //{
        //    bool executeCalled = false;
        //    MyClass testClass = new MyClass();
        //    ICommand command = new DelegateCommand<MyClass>(delegate (MyClass parameter)
        //    {
        //        Assert.Same(testClass, parameter);
        //        executeCalled = true;
        //    });

        //    command.Execute(testClass);
        //    Assert.True(executeCalled);
        //}

        //[Fact]
        //public void ShouldPassParameterInstanceOnCanExecute()
        //{
        //    bool canExecuteCalled = false;
        //    MyClass testClass = new MyClass();
        //    ICommand command = new DelegateCommand<MyClass>((p) => { }, delegate (MyClass parameter)
        //    {
        //        Assert.Same(testClass, parameter);
        //        canExecuteCalled = true;
        //        return true;
        //    });

        //    command.CanExecute(testClass);
        //    Assert.True(canExecuteCalled);
        //}

        //[Fact]
        //public void ShouldThrowIfAllDelegatesAreNull()
        //{
        //    Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        var command = new DelegateCommand<object>(null, null);
        //    });
        //}

        //[Fact]
        //public void ShouldThrowIfExecuteMethodDelegateNull()
        //{
        //    Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        var command = new DelegateCommand<object>(null);
        //    });
        //}

        //[Fact]
        //public void ShouldThrowIfCanExecuteMethodDelegateNull()
        //{
        //    Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        var command = new DelegateCommand<object>((o) => { }, null);
        //    });
        //}

        [TestMethod]
        public async Task DelegateCommandShouldThrowIfAllDelegatesAreNull()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    Assert.ThrowsException<ArgumentException>(() =>
                        {
                            var command = new DelegateCommand(null, null);
                        });
                });
        }

        [TestMethod]
        public async Task DelegateCommandShouldThrowIfExecuteMethodDelegateNull()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    Assert.ThrowsException<ArgumentException>(() =>
                        {
                            var command = new DelegateCommand(null);
                        });
                });
        }

        //[Fact]
        //public void DelegateCommandGenericShouldThrowIfCanExecuteMethodDelegateNull()
        //{
        //    Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        var command = new DelegateCommand<object>((o) => { }, null);
        //    });
        //}

        //[Fact]
        //public void IsActivePropertyIsFalseByDeafult()
        //{
        //    var command = new DelegateCommand<object>(DoNothing);
        //    Assert.False(command.IsActive);
        //}

        //[Fact]
        //public void IsActivePropertyChangeFiresEvent()
        //{
        //    bool fired = false;
        //    var command = new DelegateCommand<object>(DoNothing);
        //    command.IsActiveChanged += delegate { fired = true; };
        //    command.IsActive = true;

        //    Assert.True(fired);
        //}

        [TestMethod]
        public async Task NonGenericDelegateCommandExecuteShouldInvokeExecuteAction()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {

                    bool executed = false;
                    var command = new DelegateCommand((o) => { executed = true; });
                    command.Execute();

                    Assert.IsTrue(executed);
                });
        }

        [TestMethod]
        public async Task NonGenericDelegateCommandCanExecuteShouldInvokeCanExecuteFunc()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {

                    bool invoked = false;
                    var command = new DelegateCommand((o) => { }, (o) => { invoked = true; return true; });

                    bool canExecute = command.CanExecute();

                    Assert.IsTrue(invoked);
                    Assert.IsTrue(canExecute);
                });
        }

        [TestMethod]
        public async Task NonGenericDelegateCommandShouldDefaultCanExecuteToTrue()
        {
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {

                    var command = new DelegateCommand((o) => { });
                    Assert.IsTrue(command.CanExecute());
                });
        }

        //    [Fact]
        //    public void NonGenericDelegateThrowsIfDelegatesAreNull()
        //    {
        //        Assert.Throws<ArgumentNullException>(() =>
        //        {
        //            var command = new DelegateCommand(null, null);
        //        });
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandThrowsIfExecuteDelegateIsNull()
        //    {
        //        Assert.Throws<ArgumentNullException>(() =>
        //        {
        //            var command = new DelegateCommand(null);
        //        });
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandThrowsIfCanExecuteDelegateIsNull()
        //    {
        //        Assert.Throws<ArgumentNullException>(() =>
        //        {
        //            var command = new DelegateCommand(() => { }, null);
        //        });
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldObserveCanExecute()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        ICommand command = new DelegateCommand(() => { }).ObservesCanExecute(() => BoolProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        Assert.False(canExecuteChangedRaised);
        //        Assert.False(command.CanExecute(null));

        //        BoolProperty = true;

        //        Assert.True(canExecuteChangedRaised);
        //        Assert.True(command.CanExecute(null));
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldObserveCanExecuteAndObserveOtherProperties()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        ICommand command = new DelegateCommand(() => { }).ObservesCanExecute(() => BoolProperty).ObservesProperty(() => IntProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        Assert.False(canExecuteChangedRaised);
        //        Assert.False(command.CanExecute(null));

        //        IntProperty = 10;

        //        Assert.True(canExecuteChangedRaised);
        //        Assert.False(command.CanExecute(null));

        //        canExecuteChangedRaised = false;
        //        Assert.False(canExecuteChangedRaised);

        //        BoolProperty = true;

        //        Assert.True(canExecuteChangedRaised);
        //        Assert.True(command.CanExecute(null));
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldNotObserveDuplicateCanExecute()
        //    {
        //        Assert.Throws<ArgumentException>(() =>
        //        {
        //            ICommand command = new DelegateCommand(() => { }).ObservesCanExecute(() => BoolProperty).ObservesCanExecute(() => BoolProperty);
        //        });
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldObserveOneProperty()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand(() => { }).ObservesProperty(() => IntProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        IntProperty = 10;

        //        Assert.True(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldObserveMultipleProperties()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand(() => { }).ObservesProperty(() => IntProperty).ObservesProperty(() => BoolProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        IntProperty = 10;

        //        Assert.True(canExecuteChangedRaised);

        //        canExecuteChangedRaised = false;

        //        BoolProperty = true;

        //        Assert.True(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldNotObserveDuplicateProperties()
        //    {
        //        Assert.Throws<ArgumentException>(() =>
        //        {
        //            DelegateCommand command = new DelegateCommand(() => { }).ObservesProperty(() => IntProperty).ObservesProperty(() => IntProperty);
        //        });
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandObservingPropertyShouldRaiseOnEmptyPropertyName()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand(() => { }).ObservesProperty(() => IntProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        RaisePropertyChanged(null);

        //        Assert.True(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldObserveOneComplexProperty()
        //    {
        //        ComplexProperty = new ComplexType()
        //        {
        //            InnerComplexProperty = new ComplexType()
        //        };

        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand(() => { })
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.IntProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        ComplexProperty.InnerComplexProperty.IntProperty = 10;

        //        Assert.True(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandNotObservingPropertiesShouldNotRaiseOnEmptyPropertyName()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand(() => { });

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        RaisePropertyChanged(null);

        //        Assert.False(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldObserveComplexPropertyWhenRootPropertyIsNull()
        //    {
        //        bool canExecuteChangedRaise = false;

        //        ComplexProperty = null;

        //        var command = new DelegateCommand(() => { })
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.IntProperty);

        //        command.CanExecuteChanged += delegate
        //        {
        //            canExecuteChangedRaise = true;
        //        };

        //        var newComplexObject = new ComplexType()
        //        {
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                IntProperty = 10
        //            }
        //        };

        //        ComplexProperty = newComplexObject;

        //        Assert.True(canExecuteChangedRaise);
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandShouldObserveComplexPropertyWhenParentPropertyIsNull()
        //    {
        //        bool canExecuteChangedRaise = false;

        //        ComplexProperty = new ComplexType();

        //        var command = new DelegateCommand(() => { })
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.IntProperty);

        //        command.CanExecuteChanged += delegate
        //        {
        //            canExecuteChangedRaise = true;
        //        };

        //        var newComplexObject = new ComplexType()
        //        {
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                IntProperty = 10
        //            }
        //        };

        //        ComplexProperty.InnerComplexProperty = newComplexObject;

        //        Assert.True(canExecuteChangedRaise);
        //    }

        //    [Fact]
        //    public void NonGenericDelegateCommandPropertyObserverUnsubscribeUnusedListeners()
        //    {
        //        int canExecuteChangedRaiseCount = 0;

        //        ComplexProperty = new ComplexType()
        //        {
        //            IntProperty = 1,
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                IntProperty = 1,
        //                InnerComplexProperty = new ComplexType()
        //                {
        //                    IntProperty = 1
        //                }
        //            }
        //        };

        //        var command = new DelegateCommand(() => { })
        //            .ObservesProperty(() => ComplexProperty.IntProperty)
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.InnerComplexProperty.IntProperty)
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.IntProperty);

        //        command.CanExecuteChanged += delegate
        //        {
        //            canExecuteChangedRaiseCount++;
        //        };

        //        ComplexProperty.IntProperty = 2;
        //        ComplexProperty.InnerComplexProperty.InnerComplexProperty.IntProperty = 2;
        //        ComplexProperty.InnerComplexProperty.IntProperty = 2;

        //        Assert.Equal(3, canExecuteChangedRaiseCount);

        //        var innerInnerComplexProp = ComplexProperty.InnerComplexProperty.InnerComplexProperty;
        //        var innerComplexProp = ComplexProperty.InnerComplexProperty;
        //        var complexProp = ComplexProperty;

        //        ComplexProperty = new ComplexType()
        //        {
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                InnerComplexProperty = new ComplexType()
        //            }
        //        };

        //        Assert.Equal(0, innerInnerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, innerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, complexProp.GetPropertyChangedSubscribledLenght());

        //        innerInnerComplexProp = ComplexProperty.InnerComplexProperty.InnerComplexProperty;
        //        innerComplexProp = ComplexProperty.InnerComplexProperty;
        //        complexProp = ComplexProperty;

        //        ComplexProperty = null;

        //        Assert.Equal(0, innerInnerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, innerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, complexProp.GetPropertyChangedSubscribledLenght());
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldObserveCanExecute()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        ICommand command = new DelegateCommand<object>((o) => { }).ObservesCanExecute(() => BoolProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        Assert.False(canExecuteChangedRaised);
        //        Assert.False(command.CanExecute(null));

        //        BoolProperty = true;

        //        Assert.True(canExecuteChangedRaised);
        //        Assert.True(command.CanExecute(null));
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandWithNullableParameterShouldObserveCanExecute()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        ICommand command = new DelegateCommand<int?>((o) => { }).ObservesCanExecute(() => BoolProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        Assert.False(canExecuteChangedRaised);
        //        Assert.False(command.CanExecute(null));

        //        BoolProperty = true;

        //        Assert.True(canExecuteChangedRaised);
        //        Assert.True(command.CanExecute(null));
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldObserveCanExecuteAndObserveOtherProperties()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        ICommand command = new DelegateCommand<object>((o) => { }).ObservesCanExecute(() => BoolProperty).ObservesProperty(() => IntProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        Assert.False(canExecuteChangedRaised);
        //        Assert.False(command.CanExecute(null));

        //        IntProperty = 10;

        //        Assert.True(canExecuteChangedRaised);
        //        Assert.False(command.CanExecute(null));

        //        canExecuteChangedRaised = false;
        //        Assert.False(canExecuteChangedRaised);

        //        BoolProperty = true;

        //        Assert.True(canExecuteChangedRaised);
        //        Assert.True(command.CanExecute(null));
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldNotObserveDuplicateCanExecute()
        //    {
        //        Assert.Throws<ArgumentException>(() =>
        //        {
        //            ICommand command =
        //                new DelegateCommand<object>((o) => { }).ObservesCanExecute(() => BoolProperty)
        //                    .ObservesCanExecute(() => BoolProperty);
        //        });
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldObserveOneProperty()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand<object>((o) => { }).ObservesProperty(() => IntProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        IntProperty = 10;

        //        Assert.True(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldObserveMultipleProperties()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand<object>((o) => { }).ObservesProperty(() => IntProperty).ObservesProperty(() => BoolProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        IntProperty = 10;

        //        Assert.True(canExecuteChangedRaised);

        //        canExecuteChangedRaised = false;

        //        BoolProperty = true;

        //        Assert.True(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldNotObserveDuplicateProperties()
        //    {
        //        Assert.Throws<ArgumentException>(() =>
        //        {
        //            DelegateCommand<object> command = new DelegateCommand<object>((o) => { }).ObservesProperty(() => IntProperty).ObservesProperty(() => IntProperty);
        //        });
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandObservingPropertyShouldRaiseOnEmptyPropertyName()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand<object>((o) => { }).ObservesProperty(() => IntProperty);

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        RaisePropertyChanged(null);

        //        Assert.True(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandNotObservingPropertiesShouldNotRaiseOnEmptyPropertyName()
        //    {
        //        bool canExecuteChangedRaised = false;

        //        var command = new DelegateCommand<object>((o) => { });

        //        command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

        //        RaisePropertyChanged(null);

        //        Assert.False(canExecuteChangedRaised);
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldObserveComplexPropertyWhenParentPropertyIsNull()
        //    {
        //        bool canExecuteChangedRaise = false;

        //        ComplexProperty = new ComplexType();

        //        var command = new DelegateCommand<object>((o) => { })
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.IntProperty);

        //        command.CanExecuteChanged += delegate
        //        {
        //            canExecuteChangedRaise = true;
        //        };

        //        var newComplexObject = new ComplexType()
        //        {
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                IntProperty = 10
        //            }
        //        };

        //        ComplexProperty.InnerComplexProperty = newComplexObject;

        //        Assert.True(canExecuteChangedRaise);
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandShouldObserveComplexPropertyWhenRootPropertyIsNull()
        //    {
        //        bool canExecuteChangedRaise = false;

        //        ComplexProperty = null;

        //        var command = new DelegateCommand<object>((o) => { })
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.IntProperty);

        //        command.CanExecuteChanged += delegate
        //        {
        //            canExecuteChangedRaise = true;
        //        };

        //        var newComplexObject = new ComplexType()
        //        {
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                IntProperty = 10
        //            }
        //        };

        //        ComplexProperty = newComplexObject;

        //        Assert.True(canExecuteChangedRaise);
        //    }

        //    [Fact]
        //    public void GenericDelegateCommandPropertyObserverUnsubscribeUnusedListeners()
        //    {
        //        int canExecuteChangedRaiseCount = 0;

        //        ComplexProperty = new ComplexType()
        //        {
        //            IntProperty = 1,
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                IntProperty = 1,
        //                InnerComplexProperty = new ComplexType()
        //                {
        //                    IntProperty = 1
        //                }
        //            }
        //        };

        //        var command = new DelegateCommand<object>((o) => { })
        //            .ObservesProperty(() => ComplexProperty.IntProperty)
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.InnerComplexProperty.IntProperty)
        //            .ObservesProperty(() => ComplexProperty.InnerComplexProperty.IntProperty);

        //        command.CanExecuteChanged += delegate
        //        {
        //            canExecuteChangedRaiseCount++;
        //        };

        //        ComplexProperty.IntProperty = 2;
        //        ComplexProperty.InnerComplexProperty.InnerComplexProperty.IntProperty = 2;
        //        ComplexProperty.InnerComplexProperty.IntProperty = 2;

        //        Assert.Equal(3, canExecuteChangedRaiseCount);

        //        var innerInnerComplexProp = ComplexProperty.InnerComplexProperty.InnerComplexProperty;
        //        var innerComplexProp = ComplexProperty.InnerComplexProperty;
        //        var complexProp = ComplexProperty;

        //        ComplexProperty = new ComplexType()
        //        {
        //            InnerComplexProperty = new ComplexType()
        //            {
        //                InnerComplexProperty = new ComplexType()
        //            }
        //        };

        //        Assert.Equal(0, innerInnerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, innerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, complexProp.GetPropertyChangedSubscribledLenght());

        //        innerInnerComplexProp = ComplexProperty.InnerComplexProperty.InnerComplexProperty;
        //        innerComplexProp = ComplexProperty.InnerComplexProperty;
        //        complexProp = ComplexProperty;

        //        ComplexProperty = null;

        //        Assert.Equal(0, innerInnerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, innerComplexProp.GetPropertyChangedSubscribledLenght());
        //        Assert.Equal(0, complexProp.GetPropertyChangedSubscribledLenght());
        //    }

        //    public class ComplexType : TestPurposeBindableBase
        //    {
        //        private int _intProperty;
        //        public int IntProperty
        //        {
        //            get { return _intProperty; }
        //            set { SetProperty(ref _intProperty, value); }
        //        }

        //        private ComplexType _innerComplexProperty;
        //        public ComplexType InnerComplexProperty
        //        {
        //            get { return _innerComplexProperty; }
        //            set { SetProperty(ref _innerComplexProperty, value); }
        //        }
        //    }

        //    private ComplexType _complexProperty;
        //    public ComplexType ComplexProperty
        //    {
        //        get { return _complexProperty; }
        //        set { SetProperty(ref _complexProperty, value); }
        //    }

        //    private bool _boolProperty;
        //    public bool BoolProperty
        //    {
        //        get { return _boolProperty; }
        //        set { SetProperty(ref _boolProperty, value); }
        //    }

        //    private int _intProperty;
        //    public int IntProperty
        //    {
        //        get { return _intProperty; }
        //        set { SetProperty(ref _intProperty, value); }
        //    }

        //    class CanExecutChangeHandler
        //    {
        //        public bool CanExeucteChangedHandlerCalled;
        //        public void CanExecuteChangeHandler(object sender, EventArgs e)
        //        {
        //            CanExeucteChangedHandlerCalled = true;
        //        }
        //    }

        //    internal void DoNothing(object param)
        //    { }


        //    class DelegateHandlers
        //    {
        //        public bool CanExecuteReturnValue = true;
        //        public object CanExecuteParameter;
        //        public object ExecuteParameter;

        //        public bool CanExecute(object parameter)
        //        {
        //            CanExecuteParameter = parameter;
        //            return CanExecuteReturnValue;
        //        }

        //        public void Execute(object parameter)
        //        {
        //            ExecuteParameter = parameter;
        //        }
        //    }
        //}

        //internal class MyClass
        //{
        //}
    }
}
