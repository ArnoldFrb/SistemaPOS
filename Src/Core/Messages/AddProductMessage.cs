using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SistemaPOS.Src.Core.Messages;

public class AddProductMessage(int count) : ValueChangedMessage<int>(count)
{
}

