﻿
using Prism.Mvvm;
using System.ComponentModel;

namespace Prism.Tests.Mocks.ViewModels
{
    public class MockViewModel : BindableBase
    {
        private int mockProperty;

        public int MockProperty
        {
            get
            {
                return this.mockProperty;
            }

            set
            {
                if(this.mockProperty != value)
                {
                    this.mockProperty = value;
                    RaisePropertyChanged(nameof(MockProperty));
                }
            }
        }

        internal void InvokeOnPropertyChanged()
        {
            RaisePropertyChanged(nameof(MockProperty));
        }
    }
}