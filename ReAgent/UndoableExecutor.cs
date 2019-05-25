using System;
using System.Collections.Generic;
using System.Text;

namespace ReAgent
{
    public abstract class UndoableExecutor<C> : Executor<C> where C : ICommand
    {
        internal abstract void Unexecute(C command);

        internal virtual void Reexecute(C command)
        {
            Execute(command);
        }
    }
}
