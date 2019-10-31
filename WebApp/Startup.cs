using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Swashbuckle.Application;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    /// <summary>
    ///  Classe responsavel inciar a aplicacao
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///  Adicionando configuracoes
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            /// <summary>
            ///  responsavel por receber as configuracoes
            /// </summary>
            var config = new HttpConfiguration();
            
            config.MapHttpAttributeRoutes();

            /// <summary>
            ///  Removendo XML e adicionando Json como saida padrao 
            /// </summary>
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;

            /// <summary>
            ///  Configurando as rotas da API
            /// </summary>
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            /// <summary>
            ///  Adicionando swagger para documentacao 
            /// </summary>
            config.EnableSwagger(c => {
                c.SingleApiVersion("v1", "Documentando API");
                c.IncludeXmlComments(AppDomain.CurrentDomain.BaseDirectory + @"\bin\WebAPI.xml");
                
            });

            /// <summary>
            ///  Habilitando cors
            /// </summary>
            app.UseCors(CorsOptions.AllowAll);

            /// <summary>
            ///  usando as configuracoes definidas
            /// </summary>
            app.UseWebApi(config);

            
        }

       
    }
}
