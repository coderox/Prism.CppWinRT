#include "pch.h"
#include "Mvvm.BindableBase.h"

namespace winrt::Prism::Mvvm::implementation
{
	void BindableBase::RaisePropertyChanged(hstring const& propertyName)
	{
		_propertyChanged(*this, Windows::UI::Xaml::Data::PropertyChangedEventArgs(propertyName));
	}

	winrt::event_token BindableBase::PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& handler)
	{
		return _propertyChanged.add(handler);
	}

	void BindableBase::PropertyChanged(winrt::event_token const& token) noexcept
	{
		_propertyChanged.remove(token);
	}
}