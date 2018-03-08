using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Infrastructure
{
    public class Disposable: IDisposable
    {
        private bool IsDisposed;

        ~Disposable()
        {
            Dispose(false);
        }
            
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(!IsDisposed && disposing)
            {
                DisposeCore();
            }
            IsDisposed = true;
        }
        //Override this
        protected virtual void DisposeCore()
        {

        }
    }
}
