using System;
using System.Collections.Generic;
using System.Text;

namespace ReAgent
{
    public class ExecutionRecord : IComparable<ExecutionRecord>
    {
        public ICommand Command { get; }
        public Operations Operation { get; }
        public long Timestamp { get; }

        public ExecutionRecord(ICommand command, Operations operation) 
            : this(command, operation, new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds())
        {
        }

        public ExecutionRecord(ICommand command, Operations operation, long timestamp)
        {
            Command = command;
            Operation = operation;
            Timestamp = timestamp;
        }

        public int CompareTo(ExecutionRecord other)
        {
            // Equivalent of CompareTo for long
            int result = Timestamp == other.Timestamp ? 0 : Timestamp < other.Timestamp ? -1 : 1;
            if (Timestamp == other.Timestamp)
            {
                result = string.Compare(Command.GetName(), other.Command.GetName());
            }
            if (result == 0)
            {
                result = Operation.CompareTo(other.Operation);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (!(obj is ExecutionRecord)) return false;
            ExecutionRecord other = obj as ExecutionRecord;
            return Timestamp == other.Timestamp
                && Command.Equals(other.Command)
                && Operation.Equals(other.Operation);
        }

        public enum Operations
        {
            DO,
            UNDO,
            REDO
        }
    }
}
