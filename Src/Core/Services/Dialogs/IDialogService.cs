using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Src.Core.Services.Dialogs
{
    public interface IDialogService
    {
        public Task ShowDialog(string title, string messege, string button);
    }
}
