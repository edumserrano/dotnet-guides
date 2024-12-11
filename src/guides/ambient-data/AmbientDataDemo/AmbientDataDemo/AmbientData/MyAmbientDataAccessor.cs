using System.Threading;

namespace AmbientDataDemo.AmbientData
{
    public class MyAmbientDataAccessor : IMyAmbientDataAccessor
    {
        private static readonly AsyncLocal<MyAmbientDataHolder> _myAmbientDataCurrent = new AsyncLocal<MyAmbientDataHolder>();

        // In many cases, this could probably be just a simple getter/setter like in https://github.com/edumserrano/dotnet-guides/blob/main/docs/guides/share-data-with-async-local.md#example-2. 
        // However, this implementation follows the guidance from the HttpContextAccessor implementation https://github.com/dotnet/aspnetcore/blob/3e08b597894891f05556dc0bee23da53cb1b3e11/src/Http/Http/src/HttpContextAccessor.cs.
        public MyAmbientData? MyAmbientData
        {
            get
            {
                return _myAmbientDataCurrent.Value?.Context;
            }
            set
            {
                var holder = _myAmbientDataCurrent.Value;
                if (holder != null)
                {
                    // Clear current HttpContext trapped in the AsyncLocals, as its done.
                    holder.Context = null;
                }

                if (value != null)
                {
                    // Use an object indirection to hold the HttpContext in the AsyncLocal,
                    // so it can be cleared in all ExecutionContexts when its cleared.
                    _myAmbientDataCurrent.Value = new MyAmbientDataHolder { Context = value };
                }
            }
        }

        private class MyAmbientDataHolder
        {
            public MyAmbientData? Context;
        }
    }
}
