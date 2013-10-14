using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure.Static;
using Spring.Context;
using Spring.Context.Support;

namespace HLP.Comum.Modules.Infrastructure
{
    public class Contexto
    {

        private static bool _primeiroRegistro = true;

        public static void CarregaConfiguracao(string nomeContexto, params string[] modulos)
        {
            if (!ContextRegistry.IsContextRegistered(nomeContexto))
            {
                lock (ContextRegistry.SyncRoot)
                {
                    IApplicationContext context;
                   

                    if (_primeiroRegistro)
                    {
                        context = new Spring.Context.Support.XmlApplicationContext(nomeContexto, false, modulos);
                    }
                    else
                    {
                        context = new Spring.Context.Support.XmlApplicationContext(nomeContexto, false, ContextRegistry.GetContext(), modulos);
                    }
                    ContextRegistry.Clear();
                    ContextRegistry.RegisterContext(context);
                    _primeiroRegistro = false;
                }
            }

        }

        public static T GetServico<T>() where T : class
        {
            try
            {
                return ContextRegistry.GetContext().GetObject(typeof(T).Name) as T;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T GetServico<T>(string nome) where T : class
        {
            try
            {
                return ContextRegistry.GetContext().GetObject(nome) as T;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
