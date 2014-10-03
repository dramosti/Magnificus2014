using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using Ninject;

namespace HLP.Comum.Infrastructure.Controllers
{
    public abstract class BaseController
    {
        public event AsynchronousSaveHandler AsynchronousSave;
        public event AsynchronousPesquisaHandler AsynchronusPesquisa;

        private IObserverAsynchronousExecution _observer;

        public void Initialize()
        {
            IKernel kernel = new StandardKernel(this.GetInstanceDIControllersModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
        }

        public void ExecuteAsynchronousSave(IObserverAsynchronousExecution observer)
        {
            // O parâmetro observer representa a interface gráfica que executará este método
            // de forma assíncrona
            if (AsynchronousSave != null)
            {
                try
                {
                    this._observer = observer;
                    observer.ConfigureBeforeAsynchronousExecution();
                    AsynchronousSave();
                    observer.AsynchronousExecutionFinished();
                }
                catch (Exception ex)
                {
                    //if (AsynchronousExecutionAborted != null)
                    //    AsynchronousExecutionAborted(ex);
                    //observer.AsynchronousExecutionAborted(ex);
                }
            }
        }

        public void ExecuteAsynchronousPesquisa(IObserverAsynchronousExecution observer)
        {
            // O parâmetro observer representa a interface gráfica que executará este método
            // de forma assíncrona
            if (AsynchronusPesquisa != null)
            {
                try
                {
                    this._observer = observer;
                    observer.ConfigureBeforeAsynchronousExecution();
                    AsynchronusPesquisa();
                    observer.AsynchronousExecutionFinished();
                }
                catch (Exception ex)
                {
                    //if (AsynchronousExecutionAborted != null)
                    //    AsynchronousExecutionAborted(ex);
                    //observer.AsynchronousExecutionAborted(ex);
                }
            }
        }

        protected void UpdateStatusAsynchronousExecution(string message)
        {
            this._observer.UpdateStatusAsynchronousExecution(message + "...");
        }

        protected abstract NinjectModule GetInstanceDIControllersModule();
    }
}
