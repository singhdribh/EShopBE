using EShopBE.Graphql.Base;
using HotChocolate.Execution.Configuration;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace EShopBE
{
    public static class GraphqlInstaller
    {
        public static IRequestExecutorBuilder AddGraphqlService(this IRequestExecutorBuilder graphqlBuilder, IServiceCollection services)
        {




            graphqlBuilder
                .AddQueryType(p => p.Name("Query"))
                .AddMutationType(p => p.Name("Mutation"))
                .AddRavenFiltering()
                .AddRavenProjections()
                .AddRavenSorting()
                .AddAuthorization()
                .AddRavenPagingProviders();
                //.AddFluentValidation(o => o.UseDefaultErrorMapper())
                //.AddHttpRequestInterceptor<HeaderRequestInterceptor>();


            Assembly.GetExecutingAssembly().GetTypes()
                  .Where(x => (x.IsAssignableTo(typeof(QueryBase))
                  || x.IsAssignableTo(typeof(MutationBase))
                  || x.IsAssignableTo(typeof(SubscriptionBase))) && !x.IsAbstract).ToList().ForEach(x =>
                  {
                      graphqlBuilder.AddType(x);
                  });


            return graphqlBuilder;
        }
    }
}
