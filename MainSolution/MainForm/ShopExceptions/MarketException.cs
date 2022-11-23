using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.ShopExceptions
{
    [Serializable()]
    internal class MarketException : Exception
    {
        public MarketException() { }
        public MarketException(string message) : base(message) { }
        public MarketException(string message, System.Exception inner) : base(message, inner) { }
        protected MarketException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
