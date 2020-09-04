﻿using MicroFeel.YonYou.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace YongYouEFLib.Test
{
    public class TestBase
    {
        protected readonly ServiceProvider serviceProvider;
        public IConfiguration Configuration { get; }

        public TestBase()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<TestBase>();
            Configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddHttpClient("queue", (q) =>
            {
                q.BaseAddress = new Uri("https://cmq-queue-sh.api.qcloud.com");
            });
            services.AddHttpClient("topic", (t) =>
            {
                t.BaseAddress = new Uri("https://cmq-topic-sh.api.qcloud.com");
            });

            services.AddDbContext<U8DbContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("U8Db"))
                );

            serviceProvider = services.BuildServiceProvider();
        }

    }
}
