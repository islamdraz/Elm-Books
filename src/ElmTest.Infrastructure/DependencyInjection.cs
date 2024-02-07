
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ElmTest.Application.Common.Interfaces;
using ElmTest.Domain.BookAggregate;
using ElmTest.Infrastructure.Repositories;
using ElmTest.Infrastructure.Settings;
using ElmTest.Infrastructure.Settings.DapperCustomHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ElmTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {


        string dbConnectionString = configuration.GetConnectionString(DbSettings.ElmDbConnection)!;

        // Inject IDbConnection, with implementation from SqlConnection class.
        services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

        SqlMapper.AddTypeHandler(typeof(BookInfo), new JsonObjectTypeHandler<BookInfo>());
        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }






}