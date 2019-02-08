#include "pch.h"
#include "Commands.DelegateCommand.h"

using namespace winrt;
using namespace Windows::Foundation;

namespace winrt::Prism::Commands::implementation
{
	DelegateCommand::DelegateCommand(Prism::Commands::ExecuteDelegate const& executeDelegate)
	{
		if (executeDelegate == nullptr) {
			throw hresult_invalid_argument();
		}
		_executeDelegate = executeDelegate;
	}

	DelegateCommand::DelegateCommand(Prism::Commands::ExecuteDelegate const& executeDelegate, Prism::Commands::CanExecuteDelegate const& canExecuteDelegate)
	{
		if (executeDelegate == nullptr || canExecuteDelegate == nullptr) {
			throw hresult_invalid_argument();
		}
		_canExecuteDelegate = canExecuteDelegate;
	}

	void DelegateCommand::RaiseCanExecuteChanged()
	{
		_canExecuteChanged(*this, IInspectable());
	}

	event_token DelegateCommand::CanExecuteChanged(EventHandler<IInspectable> const& handler)
	{
		return _canExecuteChanged.add(handler);
	}

	void DelegateCommand::CanExecuteChanged(event_token const& token) noexcept
	{
		_canExecuteChanged.remove(token);
	}

	bool DelegateCommand::CanExecute(IInspectable const& parameter)
	{
		if (_canExecuteDelegate == nullptr) {
			return true;
		}

		bool canExecute = _canExecuteDelegate(parameter);

		if (_lastCanExecute != canExecute) {
			_lastCanExecute = canExecute;
			RaiseCanExecuteChanged();
		}

		return _lastCanExecute;
	}

	void DelegateCommand::Execute(IInspectable const& parameter)
	{
		if (_executeDelegate != nullptr) {
			_executeDelegate(parameter);
		}
	}

	void DelegateCommand::Execute() {
		Execute(nullptr);
	}

	bool DelegateCommand::CanExecute() {
		return CanExecute(nullptr);
	}
}
