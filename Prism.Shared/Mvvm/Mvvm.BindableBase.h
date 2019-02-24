#pragma once

#include "Mvvm.BindableBase.g.h"

namespace winrt::Prism::Mvvm::implementation
{
	struct BindableBase : BindableBaseT<BindableBase>
	{
		BindableBase() = default;

		void RaisePropertyChanged(hstring const& propertyName);
		winrt::event_token PropertyChanged(Windows::UI::Xaml::Data::PropertyChangedEventHandler const& handler);
		void PropertyChanged(winrt::event_token const& token) noexcept;

	private:
		winrt::event<winrt::Windows::UI::Xaml::Data::PropertyChangedEventHandler> _propertyChanged;
	};
}

namespace winrt::Prism::Mvvm::factory_implementation
{
	struct BindableBase : BindableBaseT<BindableBase, implementation::BindableBase>
	{
	};
}
