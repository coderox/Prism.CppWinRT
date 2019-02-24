#pragma once

#include "Commands.DelegateCommand.g.h"

namespace winrt::Prism::Commands::implementation
{
	struct DelegateCommand : DelegateCommandT<DelegateCommand>
	{
		DelegateCommand() = delete;
		DelegateCommand(Prism::Commands::ExecuteDelegate const& executeDelegate);
		DelegateCommand(Prism::Commands::ExecuteDelegate const& executeDelegate, Prism::Commands::CanExecuteDelegate const& canExecuteDelegate);

		void RaiseCanExecuteChanged();
		winrt::event_token CanExecuteChanged(Windows::Foundation::EventHandler<Windows::Foundation::IInspectable> const& handler);
		void CanExecuteChanged(winrt::event_token const& token) noexcept;
		bool CanExecute(Windows::Foundation::IInspectable const& parameter);
		void Execute(Windows::Foundation::IInspectable const& parameter);

		void Execute();
		bool CanExecute();

	private:
		event<Windows::Foundation::EventHandler<Windows::Foundation::IInspectable>> _canExecuteChanged;
		Prism::Commands::ExecuteDelegate _executeDelegate;
		Prism::Commands::CanExecuteDelegate  _canExecuteDelegate;
		bool _lastCanExecute = true;
	};
}

namespace winrt::Prism::Commands::factory_implementation
{
	struct DelegateCommand : DelegateCommandT<DelegateCommand, implementation::DelegateCommand>
	{
	};
}
