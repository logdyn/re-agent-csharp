using System;
using System.Collections.Generic;
using System.Text;

namespace ReAgent
{
    public abstract class Executor<C> where C : ICommand
    {
        public abstract void Execute(C command);
    }
}
